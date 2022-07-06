using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : BaseEnemy
{
    [SerializeField] GameObject projectile;
    protected override void Start()
    {
        //±âº» ½ºÅÝ
        BaseStatSet(800, 15, 1, 6, 90, 100, 70, 80);
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
        if (_state != EnemyState.ATTACK && attackCollisions[0].isCanAttack(this))
        {
            _state = EnemyState.ATTACK;
            curAttackDelay = 0;
        }
    }
    public void shootFireball()
    {
        SoundManager.instance.PlaySoundClip("SFX_Fire_Boom", SoundType.SFX);
        float shootYPosition = dimensionType == DimensionType.OVER ? 1 : -1;
        GameObject Target = dimensionType == DimensionType.OVER ? player.gameObject : DarkPlayer.Instance.gameObject;

        for (int i = -1; i < 2; i++)
        {
            AttackProjectile projectileComponenet = ObjectPool.Instance.CreateObj
                (projectile, transform.position + Vector3.right * (1 * i) + Vector3.up * (i == 0 ? shootYPosition : 0), Quaternion.identity).GetComponent<AttackProjectile>();
            projectileComponenet.Init(this, attackDamage, 10, 0, ProjectileType.Target, Target);
        }
        _state = EnemyState.MOVE;
    }
}
