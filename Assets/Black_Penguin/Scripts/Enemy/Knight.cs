using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseEnemy
{
    protected override void Start()
    {
        //�⺻ ����
        BaseStatSet(180,20,0,10,10,20,10,15);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (curAttackDelay > attackDelay)
        {
            OnCheck();
        }

    }
    void OnCheck()
    {
        if (_state != EnemyState.ATTACK && _state != EnemyState.HIT)
        {
            _state = UseAttackCollision(0, true) ? EnemyState.ATTACK : EnemyState.MOVE;
            curAttackDelay = 0;
        }
    }
    public void AttackEnd()
    {
        _state = EnemyState.IDLE;
    }
    public override void OnHit(Entity atkEntity, float Damage)
    {
        StartCoroutine(HitAnim());
        base.OnHit(atkEntity, Damage);
    }
    public void OnAttack(int index)
    {
        UseAttackCollision(index);
    }
    IEnumerator HitAnim()
    {
        _state = EnemyState.HIT;
        yield return new WaitForSeconds(0.4f);
        _state = EnemyState.IDLE;
    }
}
