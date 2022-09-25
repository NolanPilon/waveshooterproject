using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;
    public int enemyCount = 0;
    int maxEnemies = 15;
    float enemySpawnRate = 1.25f;

    Vector2[] spawnPositions;
    void Start()
    {
        //Potential Spawn Positions
        spawnPositions = new Vector2[4];
        spawnPositions[0] = new Vector2(-30, 0);
        spawnPositions[1] = new Vector2(30, 0);
        spawnPositions[2] = new Vector2(0, -20);
        spawnPositions[3] = new Vector2(0, 20);
    }
    void Update()
    {
        if (enemyCount < maxEnemies)
        {
            if (!IsInvoking("SpawnEnemy"))
            {
                InvokeRepeating("SpawnEnemy", 0.0f, enemySpawnRate);
            }
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    void SpawnEnemy() 
    {
        Vector2 playerPos = player.position;
        int i = Random.Range(0, 3);

        Vector2 spawnPos = playerPos + spawnPositions[i];

        Instantiate(enemy, spawnPos, Quaternion.identity);
        enemyCount++;
    }
}
