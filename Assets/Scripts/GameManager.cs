using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController controller;
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

        SpawnEnemy();
        enemyCount = 1;
    }
    void Update()
    {
        //Spawn Behavior
        if (controller.enemies.Length > 0) 
        {
            enemyCount = controller.enemies.Length;
        }

        if (enemyCount < maxEnemies)
        {
            if (!IsInvoking("SpawnEnemy"))
            {
                InvokeRepeating("SpawnEnemy", enemySpawnRate, enemySpawnRate);
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
    }
}
