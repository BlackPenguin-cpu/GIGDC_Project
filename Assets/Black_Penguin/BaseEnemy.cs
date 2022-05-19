
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : Entity
{
    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }
    public abstract void Attack();
}
