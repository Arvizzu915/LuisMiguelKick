using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxEnemiesInScene = 20;
    private int currentEnemiesInScene = 0;

    [Header("All possible enemy prefabs")]
    [SerializeField] private GameObject[] enemies;   // assign 5 prefabs here in inspector

    [Header("Enemies that can spawn right now")]
    [SerializeField] private List<int> allowedEnemyTypes = new(); // indexes to use

    private List<List<GameObject>> pools = new(); // a pool per enemy type

    [SerializeField] private float mapLength = 10;

    private void Start()
    {
        // Example: allow all 5 enemy prefabs
        allowedEnemyTypes = new List<int> { 0, 1, 2, 3, 4 };

        CreatePools();
        InvokeRepeating(nameof(SpawnEnemy), 0f, 1f);
    }

    private void CreatePools()
    {
        pools.Clear();

        for (int i = 0; i < enemies.Length; i++)
        {
            pools.Add(new List<GameObject>());   // one pool per prefab
        }
    }

    private void SpawnEnemy()
    {
        if (currentEnemiesInScene >= maxEnemiesInScene) return;

        currentEnemiesInScene++;

        // Pick a random enemy type that is allowed
        int randomIndex = allowedEnemyTypes[Random.Range(0, allowedEnemyTypes.Count)];

        GameObject enemy = GetFromPool(randomIndex);

        enemy.SetActive(true);
        enemy.transform.position = GetRandomPositionInMap();
    }

    private GameObject GetFromPool(int enemyType)
    {
        List<GameObject> pool = pools[enemyType];

        // find inactive object
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
                return pool[i];
        }

        // none available → create a new one
        GameObject newEnemy = Instantiate(enemies[enemyType]);
        newEnemy.SetActive(false);
        pool.Add(newEnemy);

        return newEnemy;
    }

    private Vector3 GetRandomPositionInMap()
    {
        return new Vector3(Random.Range(-mapLength, mapLength), 0f, Random.Range(-mapLength, mapLength));
    }
}

