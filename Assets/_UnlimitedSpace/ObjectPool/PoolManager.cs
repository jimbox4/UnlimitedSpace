using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager<T> where T : IObject
{
    private Action<IObject> _takeAction;

    private CustomPool<T> _pool;
    private ObjectsFactory<T> _objectsFactory;

    public PoolManager(Spawner spawner, int poolSize, Action<IObject> takeAction)
    {
        if (poolSize < 0)
        {
            Debug.LogError($"pool size can not be negative. {nameof(poolSize)} = {poolSize}");

            return;
        }

        _takeAction = takeAction;

        _pool = new CustomPool<T>(poolSize);
        _objectsFactory = new ObjectsFactory<T>(spawner);

        FillPool();
    }

    public void Take()
    {
        foreach (var poolObject in _pool.PoolObjects)
        {
            if (poolObject.GameObject.activeInHierarchy == false)
            {
                _takeAction.Invoke(poolObject);

                return;
            }
        }
    }

    private void FillPool()
    {
        List<T> objects = new List<T>();

        objects = _objectsFactory.Create(_pool.PoolSize);

        foreach (var obj in objects)
        {
            obj.GameObject.transform.position = Vector3.zero;
            obj.GameObject.transform.rotation = Quaternion.identity;
            obj.GameObject.SetActive(false);
        }

        _pool.SetPoolObjects(objects);
    }
}
