using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class ResetValuePublisher : IInitializable {

		Counter.Model _model;
		Counter.Model _target;
		Settings _settings;
		Counter.OnReset.Trigger _signal;

		public ResetValuePublisher(
			Counter.Model model, 
			[Inject(Id = Counter.Model.Type.Target)] Counter.Model target, 
			Settings settings, 
			Counter.OnReset.Trigger signal) {
			_model = model;
			_target = target;
			_settings = settings;
			_signal = signal;
		}

		public void Initialize () {
//			_model.counter.ObserveEveryValueChanged (v => v.Value)
//				.Throttle (System.TimeSpan.FromSeconds (_settings.second))
//				.Subscribe(_ => _signal.Fire());

			_model.counter.ObserveEveryValueChanged (v => v.Value)
				.Where (v => v == _target.counter.Value)
				.Subscribe (_ => _signal.Fire ());
		}

		[System.Serializable]
		public class Settings {
			public float second;
		}
	}
}