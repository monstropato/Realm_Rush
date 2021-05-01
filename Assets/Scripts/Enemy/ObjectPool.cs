using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] [Range(0.1f, 30f)] float spawnTime = 1f;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] Enemy enemyPrefab;

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
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].gameObject.name = $"{enemyPrefab.name} ({i})";
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
            yield return new WaitForSeconds(spawnTime);
        }
    }
}