using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    float moveSpeed = 10.0f;
    float fireRate = 0.75f;
    float bulletVelocity = 10.0f;
    float shootDist = 10.0f;
    
    public GameObject bulletPrefab;
    public GameObject[] enemies;
    GameObject closestEnemy = null;

    void Update()
    {
        //Player Movement
        Vector2 playerPos = transform.position;

        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        playerPos.x += dirX * moveSpeed * Time.deltaTime;
        playerPos.y += dirY * moveSpeed * Time.deltaTime;

        transform.position = playerPos;

        FindClosestEnemy();

        // Shoot When Close To Target
        if (gameManager.enemyCount > 0 && Vector2.Distance(closestEnemy.transform.position, playerPos) < shootDist)
        {
            if (!IsInvoking("Shoot"))
            {
                InvokeRepeating("Shoot", fireRate, fireRate);
            }
        }
        else 
        {
            CancelInvoke("Shoot");
        }
        
    }

    //Functions
    void Shoot() 
    {
        Vector2 shootDir = closestEnemy.transform.position - transform.position;
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletVelocity;
    }   

    void FindClosestEnemy()
    {
        float lastDistance = Mathf.Infinity;

        if (gameManager.enemyCount != 0) 
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject currentEnemy in enemies)
            {
                float disToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
                if (disToEnemy < lastDistance)
                {
                    lastDistance = disToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
            Debug.DrawLine(transform.position, closestEnemy.transform.position);
        }
    }
}
