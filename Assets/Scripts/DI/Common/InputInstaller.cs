using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class InputInstaller : MonoInstaller {
    [SerializeField] private InputController _inputController;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private KeybindingsDisplayController _keybindingDisplayController;
    
    public override void InstallBindings() {
        Container.BindInstance<InputController>(_inputController).AsSingle().NonLazy();
        Container.BindInstance<PlayerInput>(_playerInput).AsSingle();
        Container.Bind<InputMapper>().AsSingle().NonLazy();
        Container.BindInstance<KeybindingsDisplayController>(_keybindingDisplayController).AsSingle();
    }
}