using UnityEngine;
using Zenject;

public class StarshipModelInstaller : MonoInstaller
{
    [SerializeField] private StarshipModelView _starshipModelView;

    public override void InstallBindings()
    {
        Container.Bind<StarshipModelView>().FromInstance(_starshipModelView).AsSingle();
    }
}