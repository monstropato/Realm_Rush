using UnityEngine;

internal class TowerTargetLocator : MonoBehaviour
{
    [SerializeField] float range = 15f;

    //STATES
    Enemy currentTarget;
    Quaternion defaultPose;

    //CACHED CLASSES REFERENCES
    Tower tower;


    internal void CustomStart()
    {
        tower = GetComponent<Tower>();
        defaultPose = tower.weapon.transform.rotation;
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
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance && targetDistance <= range)
            {
                closestTarget = enemy;
                maxDistance = targetDistance;
            }
        }
        currentTarget = closestTarget;
    }

    private void AimWeapon()
    {
        if (currentTarget)
        {
            tower.weapon.transform.LookAt(currentTarget.transform);
            tower.towerDamage.Attack(true);
        }
        else
        {
            tower.weapon.transform.rotation = defaultPose;
            tower.towerDamage.Attack(false);
        }
    }
}