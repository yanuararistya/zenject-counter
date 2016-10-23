using UnityEngine;
using System.Collections;
using UniRx;
using Zenject;

namespace Counter {
	public class Model {

		public enum Type
		{
			Target
		}

		public IntReactiveProperty counter;

		public Model () {
			counter = new IntReactiveProperty (0);
		}
	}
}
