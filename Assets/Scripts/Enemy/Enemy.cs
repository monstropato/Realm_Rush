using UnityEngine;

public class Enemy : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED CLASSES REFERENCES
    internal EnemyMovement enemyMovement;
    internal EnemyHealth enemyHealth;
    internal EnemyCollider enemyCollider;

    private void OnEnable()
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

    internal void Spawn()
    {
        gameObject.SetActive(true);
    }

    internal void Despawn()
    {
        gameObject.SetActive(false);
    }
}
