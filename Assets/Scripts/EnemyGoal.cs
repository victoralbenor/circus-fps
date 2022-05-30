using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyBase>();
        if (!enemy) return;
        enemy.WarnSpawnerAboutDeath();
        Destroy(other);
    }
}
