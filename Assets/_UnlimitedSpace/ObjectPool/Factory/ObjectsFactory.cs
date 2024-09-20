using System.Collections.Generic;
using UnityEngine;

public class ObjectsFactory<T> where T : IObject
{
    private Spawner _spawner;
    private T _prefab;

    public ObjectsFactory(Spawner spawner)
    {
        _spawner = spawner;
    }

    public List<T> Create(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError($"amount can not be negative. {nameof(amount)} = {amount}");

            return null;
        }

        List<T> objects = new List<T>();

        for (int i = 0; i < amount; i++)
        {
            T instance = _spawner.InstantiatePrefab(_prefab).GameObject.GetComponent<T>();

            objects.Add(instance);
        }

        return objects;
    }
}
