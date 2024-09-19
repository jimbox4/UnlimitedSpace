using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class InputListener : MonoBehaviour
{
    private DiContainer _container;
    private StarshipView _starShipView;
    private IInputSystem _inputSystem;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }

    public async void Start()
    {
        while (
            _container.HasBinding<StarshipView>() == false && 
            _container.HasBinding<IInputSystem>() == false)
        {
            await Task.Delay(100);
        }

        _starShipView = _container.Resolve<StarshipView>();
        _inputSystem = _container.Resolve<IInputSystem>();

        Initialize();

        _inputSystem.KeyDirectionPressed += _starShipView.StarshipMovement.SetMoveDirection;
    }

    private void Initialize()
    {
        _starShipView.Initialize();

        Camera camera = _container.Resolve<Camera>();
        Transform cameraTarget = _container.Resolve<StarshipModelView>().transform;

        _inputSystem.Initialize(camera, cameraTarget);
    }

    private void Update()
    {
        _inputSystem?.Update();
    }
}
