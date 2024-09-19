using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CustomPhysic
{
    public bool IsFrictionActive = true;

    private Transform _transform;

    private Vector3 _velocity;
    private UniTask _frictionTask = default;

    private float _frictionPower;

    public bool IsFrictionSucceeded => _frictionTask.Status == UniTaskStatus.Succeeded;
    public float Speed => Mathf.Sqrt(Mathf.Pow(_velocity.x, 2) + Mathf.Pow(_velocity.y, 2) + Mathf.Pow(_velocity.z, 2));
    public Vector3 Velocity => _velocity;

    public void Initialize(Transform transform)
    {
        _transform = transform;

        Observable.EveryFixedUpdate().Subscribe(_ => { UpdateLocation(); });
    }

    public void AddForce(Vector3 speedDirection, float speed)
    {
        _velocity += speedDirection * speed;

        if (_frictionTask.Status == UniTaskStatus.Succeeded && IsFrictionActive)
        {
            _frictionTask = UpdateCharacterFriction();
        }
    }

    public void SetFrictionPower(float value)
    {
        if (value < 0)
        {
            Debug.LogError($"{nameof(_frictionPower)}. Value = {value} can not be negative");
        }

        _frictionPower = value;
    }

    public void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
    }

    private void UpdateLocation()
    {
        _transform.position += _velocity * Time.fixedDeltaTime;
    }

    private async UniTask UpdateCharacterFriction()
    {
        while (_velocity != Vector3.zero)
        {
            _velocity = Vector3.MoveTowards(_velocity, Vector3.zero, _frictionPower * Time.fixedDeltaTime);

            await UniTask.WaitForFixedUpdate();
        }
    }

    public int GetSpeedDirection(Vector3 objectDirection)
    {
        int direction = 0;

        if (Vector3.Distance(objectDirection, _velocity.normalized) > Vector3.Distance(objectDirection, _velocity.normalized * -1))
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        return direction;
    }
}
