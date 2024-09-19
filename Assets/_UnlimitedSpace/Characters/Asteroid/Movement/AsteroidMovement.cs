using UnityEngine;
using Zenject;

public class AsteroidMovement
{
    private CustomPhysic _customPhysic;
    private Transform _transform;

    private Transform _target;
    private Vector3 _speedMovementDirection;

    public void Initialize(DiContainer diContainer, Transform transform, Transform target)
    {
        _target = target;
        _transform = transform;


        IFactory<CustomPhysic> physicFactory = diContainer.Resolve<IFactory<CustomPhysic>>();
        _customPhysic = physicFactory.Create();
        _customPhysic.Initialize(_transform);
        _customPhysic.IsFrictionActive = false;
    }

    public void UpdateRotation()
    {
        _transform.LookAt(_target);
    }

    public void SetSpeed(float speedValue)
    {
        _speedMovementDirection = (_target.position - _transform.position).normalized;

        Vector3 speedDirection = 
            new Vector3(speedValue * _speedMovementDirection.x, 
            speedValue * _speedMovementDirection.y, 
            speedValue * _speedMovementDirection.z);

        _customPhysic.SetVelocity(speedDirection);
    }
}
