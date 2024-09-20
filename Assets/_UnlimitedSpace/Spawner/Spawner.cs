using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AsteroidView _asteroidPrefab;

    private PoolManager<AsteroidView> _asteroidsPool;
    private int _asteroidsPoolSize = 10;
    private float _spawnDistance = 500f;

    public IObject InstantiatePrefab(IObject prefab)
    {
        return Instantiate(_asteroidPrefab.gameObject).GetComponent<IObject>();
    }

    private void Start()
    {
        _asteroidsPool = new PoolManager<AsteroidView>(this, _asteroidsPoolSize, TakeAsteroid);
    }

    private void FixedUpdate()
    {
        _asteroidsPool.Take();
    }

    private void TakeAsteroid(IObject asteroidView)
    {
        Vector3 normalizedPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
        Vector3 position = normalizedPosition * _spawnDistance;

        float scaleValue = Random.Range(1f, 4f);
        Vector3 scale = Vector3.one * scaleValue;

        asteroidView.Activate(position, scale);
        asteroidView.GameObject.SetActive(true);
    }
}
