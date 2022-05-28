using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour, IDamageable
{
    public void Damage()
    {
        //todo spawn effects
        //todo add score
        Destroy(gameObject);
    }
}
