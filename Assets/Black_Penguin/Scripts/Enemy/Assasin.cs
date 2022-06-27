using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin : BaseEnemy
{
    public override EnemyState _state
    {
        get => base._state;
        set
        {
            if (state == EnemyState.ATTACK) return;
            base._state = value;
        }
    }
    protected override void Start()
    {
        BaseStatSet(300, 40, 3, 15, 40, 45, 35, 45, 2);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (attackCollisions[0].isCanAttack(this))
        {
            if (curAttackDelay > attackDelay)
            {
                curAttackDelay = 0;
                _state = EnemyState.ATTACK;
            }
            else
                _state = EnemyState.IDLE;
        }
        else
        {
            _state = EnemyState.MOVE;
        }
    }

    //본 함수들은 애니매이터에서 발동함
    void AnimAttack()
    {
        attackCollisions[1].OnAttack(this);
    }
    void AnimAttackEnd()
    {
        state = EnemyState.MOVE;
        curAttackDelay = 0;
    }
    public void Teleport()
    {
        transform.position = player.transform.position + (player.sprite.flipX ? Vector3.right : Vector3.left);
        sprite.color = Color.clear;
        StartCoroutine(FadeOut());
    }
    public IEnumerator FadeOut()
    {
        while (sprite.color.a < 0.9f)
        {
            sprite.color = Color.Lerp(sprite.color, Color.white, Time.deltaTime * 2);
            yield return null;
        }
        sprite.color = Color.white;
    }
}
