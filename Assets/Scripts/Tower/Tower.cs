using UnityEngine;

public class Tower : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject weapon;
    [SerializeField] internal ParticleSystem projectile;

    //CACHED CLASSES REFERENCES
    internal TowerTargetLocator targetLocator;
    internal TowerDamage towerDamage;

    private void Awake()
    {
        GetCachedReferences();
        StartCustomStarts();
    }

    private void GetCachedReferences()
    {
        targetLocator = GetComponent<TowerTargetLocator>();
        towerDamage = GetComponent<TowerDamage>();
    }

    private void StartCustomStarts()
    {
        targetLocator.CustomStart();
        towerDamage.CustomStart();
    }
}