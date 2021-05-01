using UnityEngine;

[RequireComponent(typeof(Tower))]
internal class TowerDamage: MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int damage = 2;

    //CACHED CLASSES REFERENCES
    Tower tower;

    //GET PARAMS
    internal int Damage { get { return damage; } }

    internal void CustomStart()
    {
        tower = GetComponent<Tower>();
    }

    internal void Attack(bool isActive)
    {
        var emissionModule = tower.projectile.emission;
        emissionModule.enabled = isActive;
    }
}