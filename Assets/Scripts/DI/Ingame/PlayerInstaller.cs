using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller {
    [SerializeField] private PlayerController _player;

    public override void InstallBindings() {
        Container.Bind<PlayerMovementController>().FromComponentOn(_player.gameObject).AsSingle();
        //Container.Bind<PlayerBlinkController>().FromComponentOn(_player.gameObject).AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerBlinkController>().FromComponentOn(_player.gameObject).AsSingle();

        Container.BindInstance<PlayerController>(_player).AsSingle();
    }
}