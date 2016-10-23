using UnityEngine;
using System;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
	[SerializeField]
	Settings _settings = null;

    public override void InstallBindings()
    {
		Container.Bind<ICountable> ().To<IncrementCounter> ().AsSingle ();

		Container.Bind<Counter.Model> ().AsCached ();
		Container.Bind<Counter.Model> ().WithId (Counter.Model.Type.Target).AsCached ();
		Container.BindAllInterfaces<Counter.InputHandler> ().To<Counter.InputHandler> ().AsSingle ();
		Container.BindAllInterfaces<Counter.UpdateValue> ().To<Counter.UpdateValue> ().AsSingle ();
		Container.BindAllInterfaces<Counter.ValueChangedPublisher> ().To<Counter.ValueChangedPublisher> ().AsSingle ();
		Container.BindAllInterfaces<Counter.ResetValuePublisher> ().To<Counter.ResetValuePublisher> ().AsSingle ();
		Container.BindAllInterfaces<Counter.ResetValue> ().To<Counter.ResetValue> ().AsSingle ();
		Container.BindAllInterfaces<Counter.Juice> ().To<Counter.Juice> ().AsSingle ();
		Container.BindAllInterfaces<ChangeBackground> ().To<ChangeBackground> ().AsSingle ();
		Container.BindAllInterfaces<Counter.RandomizeTargetValue> ().To<Counter.RandomizeTargetValue> ().AsSingle ();

		InstallSignals ();

		InstallSettings ();
    }

	void InstallSignals () {
		Container.BindSignal<ScreenOnClick> ();
		Container.BindTrigger<ScreenOnClick.Trigger> ();

		Container.BindSignal<Counter.OnValueChanged> ();
		Container.BindTrigger<Counter.OnValueChanged.Trigger> ();

		Container.BindSignal<Counter.OnReset> ();
		Container.BindTrigger<Counter.OnReset.Trigger> ();
	}

	void InstallSettings () {
		Container.BindInstance (_settings.changeBackgroundSettings);
		Container.BindInstance (_settings.resetEverySeconds);
		Container.BindInstance (_settings.randomTarget);
	}

	[Serializable]
	public class Settings {
		public ChangeBackground.Settings changeBackgroundSettings;
		public Counter.ResetValuePublisher.Settings resetEverySeconds;
		public Counter.RandomizeTargetValue.Settings randomTarget;
	}
}