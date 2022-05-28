using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [Tooltip("Damage Particles")] public GameObject DamageParticles;

    [Tooltip("How many points the player earns for destroying this")]
    public int ScoreValue;

    public void Damage()
    {
        var effects = Instantiate(DamageParticles, transform.position, Quaternion.identity);
        Destroy(effects, 3f);

        ScoreManager.Instance.AddScore(ScoreValue);

        Destroy(gameObject);
    }
}