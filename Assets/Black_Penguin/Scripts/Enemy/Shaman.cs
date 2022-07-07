using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaman : BaseEnemy
{
    [SerializeField] GameObject projectile;
    protected override void Start()
    {
        //±âº» ½ºÅÝ
        BaseStatSet(280, 15, 0, 6, 90, 100, 70, 80, 0.5f);
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
        if (attackCollisions[0].isCanAttack(this))
        {
            _state = EnemyState.ATTACK;
            curAttackDelay = 0;
        }
    }
    public void shootFireball()
    {
        GameObject Target = dimensionType == DimensionType.OVER ? player.gameObject : DarkPlayer.Instance.gameObject;

        AttackProjectile projectileComponenet = ObjectPool.Instance.CreateObj
            (projectile, transform.position + (dimensionType == DimensionType.OVER ? Vector3.up : Vector3.down) * 2, Quaternion.identity).GetComponent<AttackProjectile>();
        projectileComponenet.Init(this, attackDamage, 10, 1, ProjectileType.Target, Target);
        _state = EnemyState.MOVE;
    }
}
