using UnityEngine;
using Zenject;

public class WinPanelInstaller : MonoInstaller {
    [SerializeField] private WinPanel _winPanel;

    public override void InstallBindings(){
        Container.BindInstance<WinPanel>(_winPanel).AsSingle();
    }
}