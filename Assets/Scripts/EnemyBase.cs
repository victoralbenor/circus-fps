using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [Tooltip("Damage Particles")] 
    public GameObject DamageParticles;

    [Tooltip("How many points the player earns for destroying this")]
    public int ScoreValue;
    
    [Tooltip("Where the enemy is going to")]
    public Transform GoalPoint;

    protected EnemySpawner m_MySpawner;
    
    protected virtual void Start()
    {
        GetComponent<NavMeshAgent>().destination = GoalPoint.position;
    }
    
    public void Damage()
    {
        ScoreManager.Instance.AddScore(ScoreValue);
        SpawnEffects();
        CheckDeath();
    }
    
    protected virtual void CheckDeath()
    {
        Die();
    }

    protected virtual void Die()
    {
        WarnSpawnerAboutDeath();
        Destroy(gameObject);
    }
    
    protected void SpawnEffects()
    {
        var effects = Instantiate(DamageParticles, transform.position, Quaternion.identity);
        Destroy(effects, 3f);
    }

    public void SetSpawnerOrigin(EnemySpawner enemySpawner)
    {
        m_MySpawner = enemySpawner;
    }

    public void WarnSpawnerAboutDeath()
    {
        m_MySpawner.EnemyDied();
    }
    
}
