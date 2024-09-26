using UnityEngine;
using Zenject;

public class StarshipView : Character
{
    [SerializeField] private StarshipModelView _shipModelView;

    public StarshipMovement StarshipMovement;

    private DiContainer _diContainer;

    private int _maxHealth = 3;

    [Inject]
    public void Construct(StarshipMovement starshipMovement, DiContainer diContainer)
    {
        StarshipMovement = starshipMovement;
        _diContainer = diContainer;
    }

    public void Initialize()
    {
        base.Initialize(_maxHealth, _maxHealth);
        StarshipMovement.Intitalize(transform, _diContainer);
    }
}
