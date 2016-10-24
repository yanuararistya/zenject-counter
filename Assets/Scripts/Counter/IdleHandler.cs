using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class IdleHandler : IInitializable {

		Counter.Model _model;
		Settings _settings;
		Counter.OnIdle.Trigger _signal;

		public IdleHandler(
			Counter.Model model, 
			Settings settings, 
			Counter.OnIdle.Trigger signal) {
			_model = model;
			_settings = settings;
			_signal = signal;
		}

		public void Initialize () {
			_model.counter.ObserveEveryValueChanged (v => v.Value)
				.Throttle (System.TimeSpan.FromSeconds (_settings.second))
				.Subscribe(_ => _signal.Fire());
		}

		[System.Serializable]
		public class Settings {
			public float second;
		}
	}
}