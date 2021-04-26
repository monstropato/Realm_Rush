using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal List<Waypoint> patch = new List<Waypoint>();

    //CACHED CLASSES REFERENCES
    internal EnemyMovement enemyMovement;

    private void Start()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void StartCustomStarts()
    {
        enemyMovement.CustomStart();
    }
}
