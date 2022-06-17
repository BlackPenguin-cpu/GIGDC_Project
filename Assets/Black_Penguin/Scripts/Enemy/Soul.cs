using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Soul : BaseEnemy
{
    AttackCollision collision;
    protected override void Start()
    {
        collision = transform.GetComponentInChildren<AttackCollision>();
        BaseStatSet(80, 30, 1, 18, 0, 0, 0, 0);

        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (collision.isCanAttack(this) && curAttackDelay > attackDelay)
        {
            curAttackDelay = 0;
        }
    }
    public override void Die()
    {
        base.Die();
    }
}
