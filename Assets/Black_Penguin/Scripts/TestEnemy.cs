using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class TestEnemy : BaseEnemy
{
    public override void Attack()
    {
    }

    public override void Die()
    {
    }

    public override void OnHit()
    {
        Debug.Log("아이고난");
    }
}
