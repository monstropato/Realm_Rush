using UnityEngine;

internal class EnemyHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int initialHealth = 10;
    [SerializeField] int difficultyRamp = 1;

    //STATS
    int health;

    //CACHED CLASSES REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();

        health = initialHealth;
    }

    internal void ManageDamage(int damage)
    {
        health -= damage;
        if(health > 0)
        {
            LoseHealth();
        }
        else
        {
            Die();
        }
    }

    private void LoseHealth()
    {
        //nothing yet
    }

    internal void Die()
    {
        gameObject.SetActive(false);
        enemy.enemyCurrency.RewardGold();
        initialHealth += difficultyRamp;
    }
}