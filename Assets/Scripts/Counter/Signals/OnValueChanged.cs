using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class OnValueChanged : Signal {
		public class Trigger : TriggerBase {}
	}
}