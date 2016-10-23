using UnityEngine;
using System;
using System.Collections;
using Zenject;

namespace Counter {
	public class UpdateValue : IInitializable, IDisposable {

		ICountable _countable;
		ScreenOnClick _signal;

		public UpdateValue (ScreenOnClick signal, ICountable countable) {
			_countable = countable;
			_signal = signal;
		}

		public void Initialize () {
			_signal.Event += Update;
		}

		public void Dispose () {
			_signal.Event -= Update;
		}

		void Update () {
			_countable.Next ();
		}
	}
}