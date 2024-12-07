using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public List<GameObject> enemyPrefabs;
    public Transform[] spawnPoints;
    public float initialSpawnInterval = 10f;
    public int initialSpawnCount = 1;
    public float spawnIncreaseInterval = 10f;
    public int spawnIncrement = 1;

    private float spawnTimer;
    private float increaseTimer;
    private int currentSpawnCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = initialSpawnInterval;
        increaseTimer = spawnIncreaseInterval;
        currentSpawnCount = initialSpawnCount;
        StartCoroutine(SpawnEnemies());
    }

// Coroutine for spawning enemies
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
          // spawns enemies
          for (int i =0; i < currentSpawnCount; i++)
          {
            SpawnEnemy();
          }
            //waits for spawncycle to repeat
            yield return new WaitForSeconds(spawnTimer);

            //decreases the spawn interval
            increaseTimer -= Time.deltaTime;
            if (increaseTimer <= 0)
            {
                currentSpawnCount += spawnIncrement;
                increaseTimer = spawnIncreaseInterval;
                spawnTimer = Mathf.Max(1f, spawnTimer * 0.9f);
            }
        }
    }

    void SpawnEnemy()
    {
        //Get a random prefab and spawnpoint
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // instantiate the random enemy at the random spawn point
        Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }
}
