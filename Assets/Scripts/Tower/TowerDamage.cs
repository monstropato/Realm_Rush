using UnityEngine;

internal class TowerDamage: MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int damage = 2;
    //CACHED CLASSES REFERENCES
    Tower tower;

    internal void CustomStart()
    {
        tower = GetComponent<Tower>();
    }

    internal int GetDamage()
    {
        return damage;
    }
}
