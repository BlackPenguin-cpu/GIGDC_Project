
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffList
{
    public float stun;
}

public class BaseEnemy : Entity
{
    public EnemyBuffList buffList;
    public float attackSpeed;
    public float attackDamage;

    private void Update()
    {
        buffList.stun -= Time.deltaTime;
    }
    public override void Die()
    {
        Player.Instance.DaggerSkill2();
    }

    public override void OnHit(Entity atkEntity, float Damage = 0)
    {
    }
}
