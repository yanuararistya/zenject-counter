using UnityEngine;
using System;
using System.Collections;
using Zenject;

namespace Counter {
	public class ResetValue : IInitializable, IDisposable {

		Counter.Model _model;
		Counter.OnReset _signal;

		public ResetValue (Counter.Model model, Counter.OnReset signal) {
			_model = model;
			_signal = signal;
		}

		public void Initialize () {
			_signal.Event += Reset;
		}

		public void Dispose () {
			_signal.Event -= Reset;
		}

		void Reset () {
			_model.counter.Value = 0;
		}
	}
}