using UnityEngine;
using Zenject;

public class PlayerDataInstallerInstaller : MonoInstaller {
    [SerializeField] private PlayerDataHandler _playerDataHandler;
    
    public override void InstallBindings() {
        Container.BindInstance<PlayerDataHandler>(_playerDataHandler).AsSingle();
    }
}