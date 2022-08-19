using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller {
    [SerializeField] private InputController _inputController;
    
    public override void InstallBindings() {
        Container.BindInstance<InputController>(_inputController).AsSingle().NonLazy();
        Container.Bind<InputMapper>().AsSingle().NonLazy();
    }
}