using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : EnemyBase
{
    public GameObject[] EnemiesToSpawn;

    protected override void Die()
    {
        SpawnEnemies();
        WarnSpawnerAboutDeath();
        Destroy(gameObject);
    }

    private void SpawnEnemies()
    {
        foreach (var enemy in EnemiesToSpawn)
        {
            var instantiatedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            var enemyBase = instantiatedEnemy.GetComponent<EnemyBase>();
            enemyBase.GoalPoint = this.GoalPoint;
            enemyBase.SetSpawnerOrigin(m_MySpawner);
            m_MySpawner.NewEnemySpawned();
        }
    }
}
