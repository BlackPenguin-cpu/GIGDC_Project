
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : Entity
{
    public float attackSpeed;
    public float attackDamage;

    public override abstract void Die();
}
