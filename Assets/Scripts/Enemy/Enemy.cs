using UnityEngine;

public class Enemy : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED CLASSES REFERENCES
    internal EnemyMovement enemyMovement;
    internal EnemyHealth enemyHealth;
    internal EnemyCollider enemyCollider;

    private void Start()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        enemyCollider = GetComponent<EnemyCollider>();
    }

    private void StartCustomStarts()
    {
        enemyMovement.CustomStart();
        enemyHealth.CustomStart();
        enemyCollider.CustomStart();
    }
}
