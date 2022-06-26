using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin : BaseEnemy
{
    AttackCollision collision;
    protected override void Start()
    {
        collision = transform.GetComponentInChildren<AttackCollision>();
        BaseStatSet(300, 40, 3, 15, 40, 45, 35, 45);
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
    public void Teleport()
    {
        transform.position = player.transform.position + (player.sprite.flipX ? Vector3.right : Vector3.left) * 3;                                                                                              
    }
}
