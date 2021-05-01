using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyCollider))]
[RequireComponent(typeof(EnemyCurrency))]
public class Enemy : MonoBehaviour
{
    //CONFIG PARAMS

    //CACHED CLASSES REFERENCES
    internal EnemyMovement enemyMovement;
    internal EnemyHealth enemyHealth;
    internal EnemyCollider enemyCollider;
    internal EnemyCurrency enemyCurrency;

    //CACHED EXTERNAL REFERENCES
    internal Bank bank;

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
        enemyCurrency = GetComponent<EnemyCurrency>();

        bank = FindObjectOfType<Bank>();
    }

    private void StartCustomStarts()
    {
        enemyMovement.CustomStart();
        enemyHealth.CustomStart();
        enemyCollider.CustomStart();
        enemyCurrency.CustomStart();
    }

    internal void Spawn()
    {
        gameObject.SetActive(true);
    }

    internal void Despawn()
    {
        gameObject.SetActive(false);
    }

    internal void Die()
    {
        gameObject.SetActive(false);
        enemyCurrency.RewardGold();
    }
}
