using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("The point where the enemy is going")]
    public GameObject LevelGoal;

    [Tooltip("List of enemies to spawn in order of appearance")]
    public GameObject[] EnemyList;

    [Tooltip("How long to wait before spawning next enemy")]
    public float TimeBetweenSpawns;

    private int m_CurrentEnemy = 0;
    private int m_EnemiesLeft;

    private void Start()
    {
        m_EnemiesLeft = EnemyList.Length;
        Invoke(nameof(SpawnNextEnemy), TimeBetweenSpawns);
    }

    private void SpawnNextEnemy()
    {
        var enemy = Instantiate(EnemyList[m_CurrentEnemy], transform.position, Quaternion.identity);
        var enemyBase = enemy.GetComponent<EnemyBase>();
        enemyBase.GoalPoint = LevelGoal.transform;
        enemyBase.SetSpawnerOrigin(this);
        m_CurrentEnemy++;
        if(m_CurrentEnemy < EnemyList.Length)
            Invoke(nameof(SpawnNextEnemy), TimeBetweenSpawns);
    }

    public void EnemyDied()
    {
        m_EnemiesLeft--;
        if(m_EnemiesLeft <= 0) NextLevel();
    }

    public void NewEnemySpawned()
    {
        m_EnemiesLeft++;
    }

    private void NextLevel()
    {
        var currentScene = SceneManager.GetSceneAt(1).buildIndex;
        if (currentScene >= SceneManager.sceneCountInBuildSettings - 1)
        {
            ScoreManager.Instance.SaveScore();
            SceneManager.LoadScene(0);
            return;
        }
        SceneManager.LoadScene(currentScene+1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
