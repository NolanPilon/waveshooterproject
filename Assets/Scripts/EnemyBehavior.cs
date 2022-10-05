using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    GameObject player;
    public Image healthBar;
    float healthPoints;
    float moveSpeed = 5.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthPoints = 3;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }

        Vector2 moveDir = player.transform.position - transform.position;
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
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
