using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : BaseEnemy
{
    protected override void Update()
    {
        base.Update();


    }
    void onAttack()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, new Vector2(sprite.flipX ? -1 : 1, 0));
        foreach (RaycastHit2D ray in rays)
        {
            if (ray.transform.GetComponent<Player>())
            {
                Attack(player, attackDamage);
            }
        }
    }

    public override void Attack(Entity target, float atkDmg)
    {
        base.Attack(target, atkDmg);
    }
}
