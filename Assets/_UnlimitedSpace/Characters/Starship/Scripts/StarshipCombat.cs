using System.Collections.Generic;
using UnityEngine;

public class StarshipCombat : MonoBehaviour
{
    [SerializeField] private List<Transform> _canonPoints;
    [SerializeField] private Transform _laserPoint;

    private IEnumerator<Transform> _canonsEnumerator;

    private int _canonDamage = 1;
    private int _laserDamage = 5;

    private void Start()
    {
        _canonsEnumerator = _canonPoints.GetEnumerator();
    }

    public void CanonShoot()
    {
        
    }

    public void LaserShoot()
    {

    }
}
