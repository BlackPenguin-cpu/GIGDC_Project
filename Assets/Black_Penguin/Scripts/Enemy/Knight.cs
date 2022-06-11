using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BaseEnemy
{
    private AttackCollision AttackArea;
    protected override void Start()
    {
        AttackArea = transform.GetComponentInChildren<AttackCollision>();

        //기본 스텟
        crystalDropValueRange.Min = 10;
        crystalDropValueRange.Max = 15;
        coinDropValueRange.Min = 10;
        coinDropValueRange.Max = 20;
        maxHp = 180;
        attackDamage = 20;
        attackSpeed = 1;
        attackDelay = 2;
        speed = 10;
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
        if (state != EnemyState.ATTACK)
        {
            state = AttackArea.isCanAttack(this) ? EnemyState.ATTACK : EnemyState.MOVE;
            curAttackDelay = 0;
        }
    }
    /// <summary>
    /// 본 함수는 애니매이터에서 실행함
    /// </summary>
    public void OnAttack()
    {
        AttackArea.OnAttack(this);
    }
}
