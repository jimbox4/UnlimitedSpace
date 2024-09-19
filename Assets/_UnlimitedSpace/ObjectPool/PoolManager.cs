using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager<T> where T : MonoBehaviour
{
    private Action<T> _takeAction;
    
    private CustomPool<T> _pool;
    private ObjectsFactory<T> _objectsFactory;

    public PoolManager(int poolSize, Action<T> takeAction)
    {
        if (poolSize < 0)
        {
            Debug.LogError($"pool size can not be negative. {nameof(poolSize)} = {poolSize}");

            return;
        }

        _takeAction = takeAction;

        _pool = new CustomPool<T>(poolSize);
        _objectsFactory = new ObjectsFactory<T>();

        FillPool();
    }

    public void Take()
    {
        T takedPoolObject = null;

        foreach (var poolObject in _pool.PoolObjects)
        {
            if (poolObject.enabled == false)
            {
                takedPoolObject = poolObject;

                break;
            }
        }

        if (takedPoolObject == null)
        {
            return;
        }

        _takeAction.Invoke(takedPoolObject);
    }

    private void FillPool()
    {
        List<T> objects = new List<T>();

        objects = _objectsFactory.Create(_pool.PoolSize);

        foreach (var obj in objects)
        {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.gameObject.SetActive(false);
        }

        _pool.SetPoolObjects(objects);
    }
}
