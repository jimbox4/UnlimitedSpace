using Zenject;

public class SpaceshipMovementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StarshipMovement>().FromInstance(new StarshipMovement()).AsSingle();
    }
}