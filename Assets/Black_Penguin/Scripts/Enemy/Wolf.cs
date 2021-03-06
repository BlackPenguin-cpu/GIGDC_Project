using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : BaseEnemy
{
    [SerializeField] float LeapPower = 30;

    protected override void Start()
    {
        BaseStatSet(130,20,2,15,20,30,20,30);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (curAttackDelay > attackDelay)
        {
            curAttackDelay = 0;
            StartCoroutine(LeapAction());
        }
    }
    IEnumerator AttackTrigger()
    {
        while (_state == EnemyState.ATTACK)
        {
            RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, new Vector2(sprite.flipX ? -1 : 1, 0));
            foreach (RaycastHit2D ray in rays)
            {
                if (ray.transform.GetComponent<Player>() && ray.distance < collider.edgeRadius)
                {
                    Attack(player, attackDamage);
                    yield break;
                }
            }
            yield return null;
        }
    }
    IEnumerator LeapAction()
    {
        //애니메이션 나오면 여기다가 따로넣자
        const float WaitSecond = 5;

        yield return new WaitForSeconds(WaitSecond);
        rigid.AddForce(new Vector2((sprite.flipX ? -1 : 1) * LeapPower, 15));
        _state = EnemyState.ATTACK;
        StartCoroutine(AttackTrigger());
        yield return new WaitForSeconds(0.2f);
        _state = EnemyState.MOVE;
    }

    public override void Attack(Entity target, float atkDmg)
    {
        base.Attack(target, atkDmg);
    }
}
