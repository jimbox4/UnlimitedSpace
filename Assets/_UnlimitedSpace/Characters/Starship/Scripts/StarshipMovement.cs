using UniRx;
using UnityEngine;
using Zenject;

public class StarshipMovement
{
    private CustomPhysic _customPhysic;
    private Camera _camera;
    private StarshipModelView _shipModelView;

    private Vector3 _forwardVelocity = default;

    private int _moveDirection;
    private int _movementDirection = 1;

    private float _maxSpeed = 100f;
    private float _minBoostSpeedLimit = 60f;
    private float _rotationSpeed = 20.0f;

    public bool IsEnabled => throw new System.NotImplementedException();

    public void Intitalize(Transform transform, DiContainer diContainer)
    {
        _shipModelView = diContainer.Resolve<StarshipModelView>();
        _camera = diContainer.Resolve<Camera>();

        IFactory<CustomPhysic> customPhysicFactory = diContainer.Resolve<IFactory<CustomPhysic>>();

        _customPhysic = customPhysicFactory.Create();

        _customPhysic.Initialize(transform);

        Observable.EveryUpdate().Subscribe(_ => 
        { 
            UpdateMovement();
            UpdateRotation();
            UpdateFrictionPower();
        });
    }

    public void SetMoveDirection(int direction)
    {
        _moveDirection = direction;
    }

    private void UpdateMovement()
    {
        float currentSpeed = _customPhysic.Speed;
        Vector3 shipDirection = _shipModelView.transform.TransformDirection(Vector3.forward);
        
        if (_moveDirection != 0)
        {
            _movementDirection = _moveDirection;
        }

        Vector3 speedMovementDirection = _shipModelView.transform.TransformDirection(Vector3.forward) * _movementDirection;

        _forwardVelocity = currentSpeed * speedMovementDirection;

        if (currentSpeed > _minBoostSpeedLimit &&
            _customPhysic.GetSpeedDirection(shipDirection) == _movementDirection)
        {
            Debug.Log("Velocity Setted " + _forwardVelocity);
            _customPhysic.SetVelocity(_forwardVelocity);
        }

        if (currentSpeed < _maxSpeed && _moveDirection != 0)
        {
            _customPhysic.AddForce(speedMovementDirection, 5 * 0.1f);
        }
    }

    private void UpdateRotation()
    {
        _shipModelView.transform.rotation = Quaternion.Slerp(_shipModelView.transform.rotation, _camera.transform.rotation, _rotationSpeed * Time.deltaTime);
    }

    private void UpdateFrictionPower()
    {
        if (_customPhysic.IsFrictionSucceeded)
        {
            return;
        }

        float frictionPower;

        if (_customPhysic.Speed > 20)
        {
            frictionPower = 25;
        }
        else
        {
            frictionPower = 5;
        }

        _customPhysic.SetFrictionPower(frictionPower);
    }
}
