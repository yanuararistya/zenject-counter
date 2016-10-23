using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Zenject;

public class ChangeBackground : IInitializable, IDisposable {

	Counter.Model _model;
	Counter.OnValueChanged _signal;
	Camera _camera;

	readonly Settings _settings;

	public ChangeBackground (Counter.Model model, Counter.OnValueChanged signal, Camera camera, Settings settings) {
		_model = model;
		_signal = signal;
		_camera = camera;
		_settings = settings;
	}

	public void Initialize () {
		_signal.Event += Change;
	}

	public void Dispose () {
		_signal.Event -= Change;
	}

	void Change () {
		_camera.backgroundColor = _settings.colors[Mathf.Abs(_model.counter.Value % _settings.colors.Count)];
	}

	[Serializable]
	public class Settings {
		public List<Color> colors;
	}
}
