using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller {
    [SerializeField] private UITreeManager _uiTree;

    public override void InstallBindings() {
        Container.BindInstance<UITreeManager>(_uiTree).AsSingle();
    }
}