using UnityEngine;
using System.Collections;
using Zenject;

public class DecrementCounter : ICountable {

	Counter.Model _model;

	public DecrementCounter (Counter.Model model) {
		_model = model;
	}

	public void Next () {
		_model.counter.Value--;
	}
}
