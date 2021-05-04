using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("References")]
    [SerializeField] internal GameObject weapon;
    [SerializeField] internal ParticleSystem projectile;
    [Header("Instantiation")]
    [SerializeField] internal int cost = 75;
    [SerializeField] internal float buildTime = 1f;

    //CACHED CLASSES REFERENCES
    internal TowerTargetLocator targetLocator;
    internal TowerDamage towerDamage;

    //CACHED EXTERNAL REFERENCES
    internal Bank bank;

    private void Awake()
    {
        GetCachedReferences();
        StartCustomStarts();
        StartCoroutine(Build());
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


    public bool CreateTower(Tower tower, Vector3 position, Vector2Int coordinates)
    {
        bank = FindObjectOfType<Bank>();

        if (!bank) { return false; }

        if(bank.CurrentBalance >= cost)
        {
            Tower newTower = Instantiate(tower, position, Quaternion.identity);
            newTower.name = $"{tower.name} {coordinates}";
            bank.Withdraw(cost);
            return true;
        }

        else 
        {
            Debug.Log("Not enough gold");
            return false; 
        }
    }

    private IEnumerator Build()
    {
        weapon.SetActive(false);
        yield return new WaitForSeconds(buildTime);
        weapon.SetActive(true);
    }
}