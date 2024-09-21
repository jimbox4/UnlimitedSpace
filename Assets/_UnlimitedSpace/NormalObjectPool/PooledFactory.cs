using UnityEngine;

public interface IGenericFactory
{
    T GetAsNew<T>() where T : MonoBehaviour;
}

public class PooledFactory : IGenericFactory
{
    private readonly PoolManager poolManager;

    public PooledFactory(PoolManager poolManager)
    {
        this.poolManager = poolManager;
    }

    public T GetAsNew<T>() where T : MonoBehaviour
    {
        return poolManager.Get<T>();
    }
}