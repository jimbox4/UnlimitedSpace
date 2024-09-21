using Zenject;

public class PoolInstaller : MonoInstaller
{
    public AsteroidView AsteroidView;
    
    public override void InstallBindings()
    {
        Container.Bind<AsteroidView>().WithId("Prefab").FromInstance(AsteroidView);
        Container.BindInterfacesAndSelfTo<PoolManager>().AsSingle();
        Container.Bind<IGenericFactory>().To<PooledFactory>().AsSingle();
        Container.Bind<AsteroidMovement>().AsSingle();
    }
}
