using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Zenject;
using Counter;

public class CheckModelOverTarget : IInitializable {

	Model _target;
	Model _model;
	OnModelOverTarget.Trigger _signal;

	public CheckModelOverTarget (
		[Inject(Id = Model.Type.Target)] Model target,
		Model model,
		OnModelOverTarget.Trigger signal) 
	{
		_target = target;
		_model = model;
		_signal = signal;
	}

	public void Initialize () {
		_model.counter.ObserveEveryValueChanged (v => v.Value)
			.Where (v => v > _target.counter.Value)
			.Subscribe (_ => _signal.Fire ());
	}
}
