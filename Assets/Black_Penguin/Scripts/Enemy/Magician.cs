using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : BaseEnemy
{
    private AttackCollision AttackDetectArea;
    AttackCondition attackCondition;
    protected override void Start()
    {
        AttackDetectArea = transform.GetComponentInChildren<AttackCollision>();

        //±âº» ½ºÅÝ
        BaseStatSet(800,100,3,6,90,100,70,80);
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
        if (_state != EnemyState.ATTACK)
        {
            _state = AttackDetectArea.isCanAttack(this) ? EnemyState.ATTACK : EnemyState.MOVE;
            curAttackDelay = 0;
        }
    }
}
