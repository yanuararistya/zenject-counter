using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

public class CheckModelEqualsTarget : IInitializable {

	Counter.Model _target;
	Counter.Model _model;
	Counter.OnModelEqualsTarget.Trigger _signal;

	public CheckModelEqualsTarget (
		[Inject(Id = Counter.Model.Type.Target)] Counter.Model target,
		Counter.Model model, 
		Counter.OnModelEqualsTarget.Trigger signal) 
	{
		_target = target;
		_model = model;
		_signal = signal;
	}

	public void Initialize () {
		_model.counter.ObserveEveryValueChanged (v => v.Value)
			.Where (v => v == _target.counter.Value)
			.Delay (System.TimeSpan.FromSeconds (.5f))
			.Subscribe (_ => _signal.Fire ());
	}
}
