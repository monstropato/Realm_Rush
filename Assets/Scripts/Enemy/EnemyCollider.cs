using UnityEngine;

internal class EnemyCollider: MonoBehaviour
{
    //CACHED CLASSES REFERENCES
    Enemy enemy;

    internal void CustomStart()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessesHit(other);
    }

    private void ProcessesHit(GameObject other)
    {
        Tower tower = other.GetComponentInParent<Tower>();
        if (tower)
        {
            int damage = tower.towerDamage.GetDamage();
            enemy.enemyHealth.ManageDamage(damage);
        }
    }
}