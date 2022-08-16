using UnityEngine;
using Zenject;

public class LevelLoaderInstaller : MonoInstaller {
    [SerializeField] private LevelLoader _levelLoader;

    public override void InstallBindings() {
        Container.BindInstance<LevelLoader>(_levelLoader).AsSingle();
    }
}