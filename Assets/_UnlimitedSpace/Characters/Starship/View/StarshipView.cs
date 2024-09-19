using UnityEngine;
using Zenject;

public class StarshipView : Character
{
    [SerializeField] private StarshipModelView _shipModelView;

    public StarshipMovement StarshipMovement;

    private DiContainer _diContainer;

    [Inject]
    public void Construct(StarshipMovement starshipMovement, DiContainer diContainer)
    {
        StarshipMovement = starshipMovement;
        _diContainer = diContainer;
    }

    public void Initialize()
    {
        StarshipMovement.Intitalize(transform, _diContainer);
    }
}
