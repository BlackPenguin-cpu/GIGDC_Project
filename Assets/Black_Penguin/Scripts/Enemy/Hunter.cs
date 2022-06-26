using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : BaseEnemy
{
    protected override void Start()
    {
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
        if (_state != EnemyState.ATTACK)
        {
            _state = attackCollisions[0].isCanAttack(this) ? EnemyState.ATTACK : EnemyState.MOVE;
            curAttackDelay = 0;
        }
    }
}
