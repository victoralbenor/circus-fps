using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : EnemyBase
{
    public GameObject[] EnemiesToSpawn;

    protected override void Die()
    {
        SpawnEnemies();
        Destroy(gameObject);
    }

    private void SpawnEnemies()
    {
        foreach (var enemy in EnemiesToSpawn)
        {
            var instantiatedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            instantiatedEnemy.GetComponent<EnemyBase>().GoalPoint = this.GoalPoint;
        }
    }
}
