using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxEnemiesInScene = 20, currentEnemiesInScene = 0;

    [SerializeField] GameObject[] enemies;
    [SerializeField] List<GameObject> enemiesPickPool = new();
    public List<GameObject> currentEnemies = new();
    public List<GameObject> enemiesPooling = new();

    [SerializeField] private float mapLength = 10;

    private void Start()
    {
        List<int> allEnemiesIndexes = new()
        {
            0
        };

        SetEnemiesPool(allEnemiesIndexes);

        InvokeRepeating(nameof(SpawnEnemy), 0f, 1f);
    }

    private void SpawnEnemy()
    {
        if (currentEnemiesInScene >= maxEnemiesInScene) return;

        currentEnemiesInScene++;

        int enemiesPick = Random.Range(0, enemiesPickPool.Count);

        GameObject enemyPooled = GetEnemyPooling();

        enemyPooled = enemiesPickPool[enemiesPick];
        enemyPooled.SetActive(true);

        Vector3 mapPos = GetRandomPositionInMap();

        enemyPooled.transform.position = mapPos;
    }

    public void SetEnemiesPool(List<int> enemiesIndex)
    {
        enemiesPickPool.Clear();

        for (int i = 0; i < enemiesIndex.Count; i++)
        {
            enemiesPickPool.Add(enemies[enemiesIndex[i]]);
        }
    }

    public GameObject GetEnemyPooling()
    {
        GameObject enemyToUse = null;

        for (int i = 0; i < enemiesPooling.Count; i++)
        {
            if (!enemiesPooling[i].activeSelf)
            {
                enemyToUse = enemiesPooling[i];
                break;
            }
        }

        if (enemyToUse == null)
        {
            GameObject newEnemy = Instantiate(enemiesPickPool[0]);
            newEnemy.SetActive(false);
            enemiesPooling.Add(newEnemy);
            enemyToUse = newEnemy;
        }

        return enemyToUse;
    }

    public Vector3 GetRandomPositionInMap()
    {
        Vector3 randomPos = new(Random.Range(-mapLength, mapLength), 0f, Random.Range(-mapLength, mapLength));

        return randomPos;
    }
}
