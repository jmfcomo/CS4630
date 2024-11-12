using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Missile : ProjectileHero
{
    GameObject nearestEnemy;

    private void Start()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (allEnemies.Length == 0)
        {
            Destroy(gameObject);
        }

        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                nearestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }

    public override void Move()
    {
        if (nearestEnemy == null)
        {
            Destroy(gameObject);
        }

        Vector3 directionToEnemy = (nearestEnemy.transform.position - transform.position).normalized;
        float moveSpeed = 50f;
        transform.position += directionToEnemy * moveSpeed * Time.deltaTime;
    }
}
