using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Zenject;
using Counter;
using System.Linq;

public class LoseHandler : IInitializable, IDisposable {

	OnModelOverTarget _signal;
	OnRoundFinished.Trigger _onRoundFinished;
	List<ILoseHandler> _loseHandlers;

	public LoseHandler (OnModelOverTarget signal, OnRoundFinished.Trigger onRoundFinished, List<ILoseHandler> loseHandlers) {
		_signal = signal;
		_onRoundFinished = onRoundFinished;
		_loseHandlers = loseHandlers;
	}

	public void Initialize () {
		_signal.Event += Lose;

		WaitUntilAllLoseHandlerComplete ();
	}

	public void Dispose () {
		_signal.Event -= Lose;
	}

	void Lose () {
		for (int i = 0; i < _loseHandlers.Count; i++) {
			_loseHandlers [i].Execute ();
		}
	}

	void WaitUntilAllLoseHandlerComplete () {
		Observable.EveryUpdate ()
			.Select (_ => _loseHandlers)
			.Where (handlers => handlers.All (handler => handler.IsDone ()))
			.Subscribe(handlers => {
				_onRoundFinished.Fire();
				for (int i = 0; i < handlers.Count; i++) {
					handlers[i].Reset();
				}
			});
	}
}