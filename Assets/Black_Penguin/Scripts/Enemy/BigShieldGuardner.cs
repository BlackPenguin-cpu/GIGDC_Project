using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShieldGuardner : BaseEnemy
{
    AttackCollision collision;
    protected override void Start()
    {
        collision = transform.GetComponentInChildren<AttackCollision>();
        BaseStatSet(500, 30, 3, 4, 48, 55, 40, 55);

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

    public IEnumerator TakleAttack()
    {
        //.해당 값은 상수처리
        float forcePower = 10;
        Vector3 dir = sprite.flipX ? Vector3.left : Vector3.right;

        for (int i = 0; i < 100; i++)
        {
            transform.Translate(dir * forcePower);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void TakleAttackCheck()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, Vector2.right, 0.01f);
        foreach (RaycastHit2D ray in rays)
        {
            if (ray.transform.TryGetComponent(out Player player))
            {
                Attack(player, attackDamage);
            }
        }

    }
}
