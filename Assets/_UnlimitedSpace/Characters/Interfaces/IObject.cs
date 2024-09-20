using UnityEngine;
using Zenject;

public interface IObject
{
    public GameObject GameObject { get; }

    public void Activate(Vector3 position, Vector3 scale);
    public void Initialize(DiContainer diContainer, Vector3 position, Transform target, Vector3 scale);
}
