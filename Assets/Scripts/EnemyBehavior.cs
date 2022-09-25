using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public SpawnMobs spawnMobs;
    public Transform player;
    public Image healthBar;
    float moveSpeed = 2.0f;
    float healthPoints;

    private void Start()
    {
        healthPoints = 3;
       
    }

    void Update()
    {
        //Follow Player
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        //Hit Points
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            spawnMobs.enemyCount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            healthPoints--;
            healthBar.fillAmount -= 0.3f;
            Destroy(collision.gameObject);
        }
    }
}
