using System.Collections.Generic;
using UnityEngine;

public class CustomPool<T> where T : IObject
{
    private int _poolSize;

    private List<T> _poolObjects = new List<T>();

    public IReadOnlyList<T> PoolObjects => _poolObjects;

    public CustomPool(int poolSize)
    {
        _poolSize = poolSize;
    }

    public int PoolSize => _poolSize;

    public void SetPoolObjects(List<T> poolObjects)
    {
        _poolObjects = poolObjects;
    }
}
