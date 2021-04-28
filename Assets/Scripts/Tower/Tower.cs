using UnityEngine;

public class Tower : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] internal GameObject weapon;

    //CACHED CLASSES REFERENCES
    internal TowerTargetLocator targetLocator;
    internal TowerDamage towerDamage;

    private void Start()
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