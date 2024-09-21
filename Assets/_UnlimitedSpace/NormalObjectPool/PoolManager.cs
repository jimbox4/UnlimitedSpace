using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

public class PoolManager
{
    private readonly Dictionary<Type, object> pools = new Dictionary<Type, object>();
    private readonly DiContainer container;

    public PoolManager(DiContainer container)
    {
        this.container = container;
    }

    public T Get<T>() where T : MonoBehaviour
    {
        ObjectPool<T> pool;
        Type type = typeof(T);

        if (!pools.ContainsKey(type))
        {
            var prefab = container.ResolveId<T>("Prefab");
            pool = new ObjectPool<T>(prefab, 10);
            pools[type] = pool;
        }
        else
        {
            pool = (ObjectPool<T>)pools[type];
        }

        return pool.Get();
    }
}