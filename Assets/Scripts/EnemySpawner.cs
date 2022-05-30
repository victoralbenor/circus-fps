using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("The point where the enemy is going")]
    public GameObject LevelGoal;

    [Tooltip("List of enemies to spawn in order of appearance")]
    public GameObject[] EnemyList;

    [Tooltip("How long to wait before spawning next enemy")]
    public float TimeBetweenSpawns;

    private int m_CurrentEnemy = 0;

    private void Start()
    {
        Invoke(nameof(SpawnNextEnemy), TimeBetweenSpawns);
    }

    private void SpawnNextEnemy()
    {
        var enemy = Instantiate(EnemyList[m_CurrentEnemy], transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyBase>().GoalPoint = LevelGoal.transform;
        m_CurrentEnemy++;
        if(m_CurrentEnemy < EnemyList.Length)
            Invoke(nameof(SpawnNextEnemy), TimeBetweenSpawns);
    }
}
