using UnityEngine;
using System.Collections;
using Zenject;

namespace Counter {
	public class RandomizeTargetValue : IInitializable, System.IDisposable {

		Counter.Model _target;
		Settings _settings;
		OnRoundFinished _signal;

		public RandomizeTargetValue (
			[Inject(Id = Counter.Model.Type.Target)]
			Counter.Model target,
			Settings settings,
			OnRoundFinished signal) {
			_target = target;
			_settings = settings;
			_signal = signal;
		}

		public void Randomize () {
			_target.counter.Value = Random.Range (0, _settings.maximum);
		}

		public void Initialize () {
			Randomize ();

			_signal.Event += Randomize;
		}

		public void Dispose () {
			_signal.Event -= Randomize;
		}

		[System.Serializable]
		public class Settings {
			public int maximum;
		}
	}
}