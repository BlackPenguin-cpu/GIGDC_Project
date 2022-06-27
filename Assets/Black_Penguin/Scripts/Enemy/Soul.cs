using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : BaseEnemy
{
    [SerializeField] GameObject boomEffect;
    protected override void Start()
    {
        BaseStatSet(80, 30, 0, 15, 0, 0, 0, 0);

        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (attackCollisions[0].isCanAttack(this))
        {
            _state = EnemyState.ATTACK;
            curAttackDelay = 0;
        }
    }
    public override void Move()
    {
        if (_state != EnemyState.MOVE) return;
        float dir;

        if (player.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
        GameObject target;
        if (dimensionType == DimensionType.OVER)
        {
            target = player.gameObject;
        }
        else
        {
            target = DarkPlayer.Instance.gameObject;
        }


        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }
    public void AnimAttack()
    {
        attackCollisions[0].OnAttack(this);
        Die();
    }
    public override void OnDieActionAdd()
    {
        onDie += () => MaterialDrop();
        onDie += () => CameraManager.Instance.CameraShake(0.1f, 0.4f, 0.05f);
        onDie += () => _state = EnemyState.DIE;
        onDie += () => ObjectPool.Instance.DeleteObj(gameObject);
    }
    public override void Die()
    {
        ObjectPool.Instance.CreateObj(boomEffect, transform.position, Quaternion.identity);
        base.Die();
    }
}
