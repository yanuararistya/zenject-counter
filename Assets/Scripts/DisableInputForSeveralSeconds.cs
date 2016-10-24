using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;
using Counter;

public class DisableInputForSeveralSeconds : ILoseHandler {

	InputHandler _input;

	bool isDone;

	public DisableInputForSeveralSeconds(InputHandler input) {
		_input = input;

		Reset ();
	}

	public void Execute () {
		_input.DisableInput ();

		Observable.Timer (System.TimeSpan.FromSeconds (.8f))
			.Subscribe (_ => {
				_input.EnableInput();
				isDone = true;
			});
	}

	public bool IsDone () {
		return isDone;
	}

	public void Reset () {
		isDone = false;
	}
}