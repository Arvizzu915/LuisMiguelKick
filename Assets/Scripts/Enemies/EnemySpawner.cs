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
    private int enemiesPoolIndex = 0;
    


    private void SpawnEnemy()
    {
        currentEnemiesInScene++;

        int enemiesPick = Random.Range(0, enemiesPickPool.Count);

        enemiesPooling[enemiesPoolIndex] = enemiesPickPool[enemiesPick];

        enemiesPoolIndex++;
    }

    public void SetEnemiesPool(List<int> enemiesIndex)
    {
        enemiesPickPool.Clear();

        for (int i = 0; i < enemiesIndex.Count; i++)
        {
            enemiesPickPool.Add(enemies[enemiesIndex[i]]);
        }
    }
}
