using UnityEngine;
using Zenject;

public class PostFXInstaller : MonoInstaller {
    [SerializeField] private PostFXHandler _postFXHandler;

    public override void InstallBindings() {
        Container.BindInstance<PostFXHandler>(_postFXHandler).AsSingle();
    }
}