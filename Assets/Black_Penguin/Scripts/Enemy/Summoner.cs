using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : BaseEnemy
{
    private AttackCollision AttackDetectArea;
    AttackCondition attackCondition;
    protected override void Start()
    {
        AttackDetectArea = transform.GetComponentInChildren<AttackCollision>();

        //�⺻ ����
        BaseStatSet(600, 0, 3, 11, 60, 65, 60, 65);
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
    void Summon()
    {
        for (int i = -1; i < 2; i += 2)
        {
            ObjectPool.Instance.CreateObj(Resources.Load<GameObject>("Enemy/Soul"), transform.position + new Vector3(i, 1, 0), Quaternion.identity);
        }
        ObjectPool.Instance.CreateObj(Resources.Load<GameObject>("Enemy/Skeleton"), transform.position, Quaternion.identity);
    }
}
