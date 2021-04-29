using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float spawnTIme = 1f;
    [SerializeField] Enemy enemy;
    [SerializeField] int poolSize = 5;

    //STATE
    Enemy[] pool;
    bool spawn = true;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void PopulatePool()
    {
        pool = new Enemy[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].Despawn();
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].Spawn();
                return;
            }
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawn)
        {
            EnableObjectInPool();   
            yield return new WaitForSeconds(spawnTIme);
        }
    }
}