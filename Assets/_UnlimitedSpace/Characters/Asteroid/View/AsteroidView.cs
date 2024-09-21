using UnityEngine;
using Zenject;

public class AsteroidView : MonoBehaviour
{
    private AsteroidMovement _asteriodMovement;
    private DiContainer _diContainer;

    private float _speed;
    private float _minSpeed = 20f;
    private float _maxSpeed = 60f;

    public GameObject GameObject => gameObject;

    public void Initialize(DiContainer diContainer, Vector3 position, Transform target, Vector3 scale)
    {
        _diContainer = diContainer;
        //_asteriodMovement = _diContainer.Resolve<AsteroidMovement>();
       // _asteriodMovement.Initialize(_diContainer, transform, target);

        transform.position = position;
        transform.rotation = Quaternion.identity;
        transform.localScale = scale;
    }

    public void Activate(Vector3 position, Vector3 scale)
    {
        transform.position = position;
        transform.localScale = scale;

        _speed = Random.Range(_minSpeed, _maxSpeed);
       // _asteriodMovement.SetSpeed(_speed);
       // _asteriodMovement.UpdateRotation();
    }
}
