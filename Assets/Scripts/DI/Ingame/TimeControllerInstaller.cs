using UnityEngine;
using Zenject;

public class TimeControllerInstaller : MonoInstaller {
    [SerializeField] private float _levelTime;
    [SerializeField] private TimerController _timeController;

    public override void InstallBindings() {
        Container.BindInstance<float>(_levelTime).WhenInjectedInto<TimerController>();

        Container.BindInstance<TimerController>(_timeController).AsSingle();
    }
}