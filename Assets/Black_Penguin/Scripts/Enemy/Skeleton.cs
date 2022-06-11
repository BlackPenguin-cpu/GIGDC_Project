using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy
{
    private AttackCollision AttackArea;
    protected override void Start()
    {
        AttackArea = transform.GetComponentInChildren<AttackCollision>();

        //�⺻ ����
        crystalDropValueRange.Min = 5;
        crystalDropValueRange.Max = 10;
        coinDropValueRange.Min = 5;
        coinDropValueRange.Max = 10;
        maxHp = 180;
        attackDamage = 11;
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
    /// �� �Լ��� �ִϸ����Ϳ��� ������
    /// </summary>
    public void OnAttack()
    {
        AttackArea.OnAttack(this);
    }
}
