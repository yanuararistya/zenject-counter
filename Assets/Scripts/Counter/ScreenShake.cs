using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ScreenShake : ILoseHandler {

	Camera _camera;
	Settings _settings;

	bool isDone;

	public ScreenShake (Camera camera, Settings settings) {
		_camera = camera;
		_settings = settings;

		Reset ();
	}

	public void Execute () {
		float magnitude = Random.Range (_settings.minMagnitude, _settings.maxMagnitude);

		_camera.DOShakePosition (_settings.duration, magnitude, _settings.vibrato)
			.OnComplete(() => isDone = true);
	}

	public bool IsDone () {
		return isDone;
	}

	public void Reset () {
		isDone = false;
	}

	[System.Serializable]
	public class Settings {
		public float minMagnitude;
		public float maxMagnitude;
		public float duration;
		public int vibrato;
	}
}
