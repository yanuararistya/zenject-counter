using UnityEngine;
using System;
using System.Collections;
using Zenject;
using DG.Tweening;

namespace Counter {
	public class Juice : IInitializable, IDisposable {

		OnValueChanged _signal;
		Counter.Display _display;

		Tween tween;

		public Juice (OnValueChanged signal, Counter.Display display) {
			_signal = signal;
			_display = display;
		}

		public void Initialize () {
			tween = _display.transform.DOPunchScale (new Vector3 (0.3f, 0.3f, 0.3f), 0.2f)
				.SetAutoKill (false);

			_signal.Event += DoJuice;
		}

		public void Dispose () {
			_signal.Event -= DoJuice;
		}

		void DoJuice () {
			if (tween.IsPlaying ())
				tween.Complete ();

			tween.Restart ();
		}
	}
}