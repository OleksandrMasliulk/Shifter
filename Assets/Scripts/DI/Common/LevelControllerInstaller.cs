using UnityEngine;
using Zenject;

public class LevelControllerInstaller : MonoInstaller {
    [SerializeField] private LevelController _levelLoader;

    public override void InstallBindings() {
        Container.BindInstance<LevelController>(_levelLoader).AsSingle();
    }
}