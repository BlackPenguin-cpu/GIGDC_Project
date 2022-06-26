using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : BaseEnemy
{
    AttackCondition attackCondition;
    AttackProjectile projectile;
    protected override void Start()
    {
        //±âº» ½ºÅÝ
        BaseStatSet(800, 100, 3, 6, 90, 100, 70, 80);
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
    public void shootFireball()
    {
        AttackProjectile projectile = new AttackProjectile(this, attackDamage, 5, ProjectileType.Target, player.gameObject);
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
