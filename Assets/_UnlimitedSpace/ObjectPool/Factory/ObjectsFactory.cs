using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFactory<T> where T : MonoBehaviour
{
    private MonoBehaviour _monoBehaviour = new MonoBehaviour();
    private T _prefab;

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
            T instance = UnityEngine.Object.Instantiate(_prefab);

            objects.Add(instance);
        }

        return objects;
    }
}
