using UnityEngine;

internal class TowerTargetLocator : MonoBehaviour
{
    //STATES
    Enemy currentTarget;

    //CACHED CLASSES REFERENCES
    Tower tower;


    internal void CustomStart()
    {
        tower = GetComponent<Tower>();
    }

    private void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }


    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy;
                maxDistance = targetDistance;
            }
        }
        currentTarget = closestTarget;
        Debug.Log($"method finished, current target: {currentTarget.name}");
    }

    private void AimWeapon()
    {
        if (currentTarget)
        {
            tower.weapon.transform.LookAt(currentTarget.transform);
            //Attack(true);
        }
        else
        {
            tower.weapon.transform.LookAt(Vector3.back);
            //Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = tower.projectile.emission;
        emissionModule.enabled = isActive;
    }
}