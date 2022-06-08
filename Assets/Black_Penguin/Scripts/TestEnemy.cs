using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TestEnemy : BaseEnemy
{
    public override void Attack(Entity target, float atkDmg)
    {
        base.Attack(target, atkDmg);
    }
    public override void Die()
    {
    }

    public override void OnHit(Entity entity, float Damage = 0)
    {
    }
}
