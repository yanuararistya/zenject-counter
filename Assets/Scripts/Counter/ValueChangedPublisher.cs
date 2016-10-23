using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class ValueChangedPublisher : IInitializable {

		Counter.Model _model;
		Counter.OnValueChanged.Trigger _signal;

		public ValueChangedPublisher (Counter.Model model, Counter.OnValueChanged.Trigger signal) {
			_model = model;
			_signal = signal;
		}

		public void Initialize () {
			_model.counter.ObserveEveryValueChanged (o => o.Value)
				.Subscribe (_ => _signal.Fire ());
		}
	}
}