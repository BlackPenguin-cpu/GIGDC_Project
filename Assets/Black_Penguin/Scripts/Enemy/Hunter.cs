using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : BaseEnemy
{
    private AttackCollision AttackDetectArea;
    AttackCondition attackCondition;
    protected override void Start()
    {
        AttackDetectArea = transform.GetComponentInChildren<AttackCollision>();

        //±âº» ½ºÅÝ
        BaseStatSet(360,38,2,13,45,50,30,50);
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
            state = AttackDetectArea.isCanAttack(this) ? EnemyState.ATTACK : EnemyState.MOVE;
            curAttackDelay = 0;
        }
    }
}
