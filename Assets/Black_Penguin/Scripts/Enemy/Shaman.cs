using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum AttackCondition
{
    Charging,
    Shooting
}
public class Shaman : BaseEnemy
{
    private AttackCollision AttackDetectArea;
    AttackCondition attackCondition;
    protected override void Start()
    {
        AttackDetectArea = transform.GetComponentInChildren<AttackCollision>();

        //�⺻ ����
        BaseStatSet(280, 60, 4, 8, 30, 37, 30, 37);
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
            attackCondition = AttackCondition.Charging;
            curAttackDelay = 0;
        }
    }
    protected override void AnimController()
    {
        base.AnimController();
        animator.SetInteger("AttackCondition", (int)attackCondition);
    }

    /// <summary>
    /// �� �Լ��� �ִϸ����Ϳ��� ������
    /// </summary>
    public void StartAttack()
    {
        attackCondition = AttackCondition.Shooting;
    }
    /// <summary>
    /// �� �Լ��� �ִϸ����Ϳ��� ������
    /// </summary>
    public void OnAttack()
    {
        AttackProjectile projectile = Instantiate(Resources.Load<AttackProjectile>("Enemy/FireBall"), transform.position, Quaternion.identity);
        projectile = new AttackProjectile(this, attackDamage, 5, ProjectileType.Target, player.gameObject);
    }
}
