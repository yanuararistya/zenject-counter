using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class Display : MonoBehaviour {

		[SerializeField]
		Text _counterLabel;

		Counter.Model _model;

		[Inject]
		public void Construct(Counter.Model model) {
			_model = model;

			_model.counter.SubscribeToText (_counterLabel);
		}
	}
}