using UnityEngine;
using System;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class InputHandler : IInitializable {

		ScreenOnClick.Trigger _signal;
		bool inputEnabled;

		public InputHandler (ScreenOnClick.Trigger signal) {
			_signal = signal;
			inputEnabled = true;
		}

		public void Initialize () {
			#if UNITY_EDITOR_WIN
			Observable.EveryUpdate ()
				.SelectMany (_ => new int[] { 0, 1, 2 })
				.Where (v => Input.GetMouseButtonDown(v) && inputEnabled)
//				.SkipWhile(v => !inputEnabled)
				.Subscribe (_ => _signal.Fire ());

			#elif UNITY_ANDROID
			Observable.EveryUpdate ()
				.SelectMany (_ => Input.touches)
				.Where (touch => touch.phase == TouchPhase.Began)
				.Subscribe (_ => _signal.Fire());

			#endif
		}

		public void DisableInput () {
			inputEnabled = false;
		}

		public void EnableInput () {
			inputEnabled = true;
		}
	}
}