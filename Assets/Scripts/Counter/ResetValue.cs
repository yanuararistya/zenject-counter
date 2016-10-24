using UnityEngine;
using System;
using System.Collections;
using Zenject;

namespace Counter {
	public class ResetValue : IInitializable, IDisposable {

		Counter.Model _model;
		Counter.OnModelEqualsTarget _onModelEqualsTarget;
		OnRoundFinished _onRoundFinished;
		Counter.OnIdle _onIdle;

		public ResetValue (
			Counter.Model model, 
			Counter.OnModelEqualsTarget onModelEqualsTarget, 
			OnRoundFinished onRoundFinished,
			Counter.OnIdle onIdle) 
		{
			_model = model;
			_onModelEqualsTarget = onModelEqualsTarget;
			_onRoundFinished = onRoundFinished;
			_onIdle = onIdle;
		}

		public void Initialize () {
			_onModelEqualsTarget.Event += Reset;
			_onRoundFinished.Event += Reset;
			_onIdle.Event += Reset;
		}

		public void Dispose () {
			_onModelEqualsTarget.Event -= Reset;
			_onRoundFinished.Event -= Reset;
			_onIdle.Event -= Reset;
		}

		public void Reset () {
			_model.counter.Value = 0;
		}
	}
}