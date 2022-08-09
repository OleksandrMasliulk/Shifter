using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

public class EventSystemInstaller : MonoInstaller {
    [SerializeField] private EventSystem _eventSystem;

    public override void InstallBindings() {
        Container.BindInstance<EventSystem>(_eventSystem).AsSingle();
    }
}