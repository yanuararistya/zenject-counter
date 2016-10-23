using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using Zenject;

public class TargetDisplay : MonoBehaviour {

	[SerializeField]
	Text _counterLabel;

	Counter.Model _model;

	[Inject]
	public void Construct([Inject(Id = Counter.Model.Type.Target)] Counter.Model model) {
		_model = model;

		_model.counter.SubscribeToText (_counterLabel);
	}
}
