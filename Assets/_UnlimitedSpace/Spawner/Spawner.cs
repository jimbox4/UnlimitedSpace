using System.Collections;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [Inject]
    private IGenericFactory factory;
    
    [Inject]
    private DiContainer container;
    
    private int _asteroidsPoolSize = 10;
    private float _spawnDistance = 500f;

    private void Start()
    {
        for (int i = 0; i < _asteroidsPoolSize; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        AsteroidView asteroidView = factory.GetAsNew<AsteroidView>();
        Vector3 normalizedPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
        Vector3 position = normalizedPosition * _spawnDistance;

        float scaleValue = Random.Range(1f, 4f);
        Vector3 scale = Vector3.one * scaleValue;
        
        Debug.LogError(position);
        //asteroidView.transform.position = position;

        StartCoroutine(Kek(asteroidView, position));
        //asteroidView.Initialize(container, position, transform, scale);
        //asteroidView.Activate(position, scale);
        asteroidView.GameObject.SetActive(true);
    }

    private IEnumerator Kek(AsteroidView view, Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        view.transform.position = position;
    }
}
