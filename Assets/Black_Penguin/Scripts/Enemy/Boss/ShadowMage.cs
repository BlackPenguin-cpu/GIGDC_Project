using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMage : BaseEnemy
{
    public override void OnObjCreate()
    {
        player = Player.Instance;
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        attackCollisions = GetComponentsInChildren<AttackCollision>();

        hp = _maxHp;
        sprite.color = Color.white;

    }
}
