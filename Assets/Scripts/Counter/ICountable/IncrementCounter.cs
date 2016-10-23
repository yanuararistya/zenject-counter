using UnityEngine;
using System.Collections;

public class IncrementCounter : ICountable {

	Counter.Model _model;

	public IncrementCounter (Counter.Model model) {
		_model = model;
	}

	public void Next ()
	{
		_model.counter.Value++;
	}
}
