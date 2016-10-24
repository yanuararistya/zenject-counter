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
		Container.BindAllInterfacesAndSelf<Counter.InputHandler> ().To<Counter.InputHandler> ().AsSingle ();
		Container.BindAllInterfaces<Counter.UpdateValue> ().To<Counter.UpdateValue> ().AsSingle ();
		Container.BindAllInterfaces<Counter.ValueChangedPublisher> ().To<Counter.ValueChangedPublisher> ().AsSingle ();
//		Container.BindAllInterfaces<Counter.IdleHandler> ().To<Counter.IdleHandler> ().AsSingle ();
		Container.BindAllInterfacesAndSelf<Counter.ResetValue> ().To<Counter.ResetValue> ().AsSingle ();
		Container.BindAllInterfaces<Counter.Juice> ().To<Counter.Juice> ().AsSingle ();
		Container.BindAllInterfaces<ChangeBackground> ().To<ChangeBackground> ().AsSingle ();
		Container.BindAllInterfaces<Counter.RandomizeTargetValue> ().To<Counter.RandomizeTargetValue> ().AsSingle ();
//		Container.BindAllInterfaces<CheckModelEqualsTarget> ().To<CheckModelEqualsTarget> ().AsSingle ();
		Container.BindAllInterfaces<CheckModelOverTarget> ().To<CheckModelOverTarget> ().AsSingle ();
//		Container.Bind<DisableInputForSeveralSeconds> ().AsSingle ();

		Container.Bind<ILoseHandler> ().To<ScreenShake> ();
		Container.Bind<ILoseHandler> ().To<YouLosePrompt> ();
		Container.Bind<ILoseHandler> ().To<DisableInputForSeveralSeconds> ();
		Container.BindAllInterfaces<LoseHandler> ().To<LoseHandler> ().AsSingle ();

		InstallSignals ();

		InstallSettings ();
    }

	void InstallSignals () {
		Container.BindSignal<ScreenOnClick> ();
		Container.BindTrigger<ScreenOnClick.Trigger> ();

		Container.BindSignal<Counter.OnValueChanged> ();
		Container.BindTrigger<Counter.OnValueChanged.Trigger> ();

		Container.BindSignal<Counter.OnModelEqualsTarget> ();
		Container.BindTrigger<Counter.OnModelEqualsTarget.Trigger> ();

		Container.BindSignal<Counter.OnIdle> ();
		Container.BindTrigger<Counter.OnIdle.Trigger> ();

		Container.BindSignal<Counter.OnModelOverTarget> ();
		Container.BindTrigger<Counter.OnModelOverTarget.Trigger> ();

		Container.BindSignal<OnRoundFinished> ();
		Container.BindTrigger<OnRoundFinished.Trigger> ();
	}

	void InstallSettings () {
		Container.BindInstance (_settings.changeBackgroundSettings);
		Container.BindInstance (_settings.resetEverySeconds);
		Container.BindInstance (_settings.randomTarget);
		Container.BindInstance (_settings.screenShake);
	}

	[Serializable]
	public class Settings {
		public ChangeBackground.Settings changeBackgroundSettings;
		public Counter.IdleHandler.Settings resetEverySeconds;
		public Counter.RandomizeTargetValue.Settings randomTarget;
		public ScreenShake.Settings screenShake;
	}
}