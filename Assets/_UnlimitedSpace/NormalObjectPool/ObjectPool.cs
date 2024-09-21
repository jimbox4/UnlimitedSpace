using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> _pool = new List<T>();

    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            _pool.Add(obj);
        }
    }

    public T Get()
    {
        foreach (var obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }
        
        T objToReuse = _pool[0];
        objToReuse.transform.position = Vector3.zero;
        objToReuse.gameObject.SetActive(true);
        return objToReuse;
    }
}