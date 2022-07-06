using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : BaseEnemy
{
    [SerializeField] GameObject m_Skull;
    [SerializeField] GameObject m_Soul;
    public override EnemyState _state
    {
        get
        {
            if (state == EnemyState.HIT) return EnemyState.MOVE;
            return base._state;
        }
        set { base._state = value; }
    }
    protected override void Start()
    {
        //기본 스텟
        BaseStatSet(600, 0, 3, 6, 60, 65, 60, 65);
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
        }
    }
    public override void Move()
    {
        if (_state != EnemyState.MOVE) return;
        if (attackCollisions[0].isCanAttack(this) && curAttackDelay < attackDelay)
        {
            _state = EnemyState.IDLE;
            return;
        }
        else _state = EnemyState.MOVE;
        float dir;

        if (player.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
            dir = 1;
        }
        else
        {
            sprite.flipX = true;
            dir = -1;
        }

        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
    }

    //해당 함수는 애니메이터에서 발동함
    public void Summon()
    {
        SoundManager.instance.PlaySoundClip("SFX_Fire_Boom", SoundType.SFX);
        SoundManager.instance.PlaySoundClip("SFX_Summon", SoundType.SFX);

        for (int i = -1; i < 2; i += 2)
        {
            ObjectPool.Instance.CreateObj(m_Soul, transform.position + new Vector3(i, dimensionType == DimensionType.OVER ? 1 : -1, 0), Quaternion.identity);
        }
        ObjectPool.Instance.CreateObj(m_Skull, transform.position, Quaternion.identity);

        curAttackDelay = 0;
        _state = EnemyState.MOVE;
    }
    public override void OnHit(Entity atkEntity, float Damage)
    {
        base.OnHit(atkEntity, Damage);
    }
}
