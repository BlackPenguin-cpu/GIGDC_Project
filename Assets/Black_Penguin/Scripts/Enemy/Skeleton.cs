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
        BaseStatSet(180, 11, 2, 10, 5, 10, 5, 10);
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
