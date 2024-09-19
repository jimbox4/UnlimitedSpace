using UnityEngine;
using Zenject;

public class SpaceshipViewInstaller : MonoInstaller
{
    [SerializeField] private StarshipView _starshipView;

    public override void InstallBindings()
    {
        Container.Bind<StarshipView>().FromInstance(_starshipView).AsSingle();
    }
}