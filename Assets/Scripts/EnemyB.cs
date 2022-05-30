using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyB : EnemyA
{
    public int Health;

    protected override void CheckDeath()
    {
        Health--;
        transform.localScale += Vector3.one;
        if(Health <= 0) Die();
    }
}
