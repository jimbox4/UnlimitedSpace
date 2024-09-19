using Zenject;

public class PhysicInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindIFactory<CustomPhysic>().AsSingle();
    }
}