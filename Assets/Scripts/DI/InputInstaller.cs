using Zenject;

public class InputInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.Bind<InputMapper>().AsSingle().NonLazy();
    }
}