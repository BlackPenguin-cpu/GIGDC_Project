using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Entity : MonoBehaviour
{
    public float speed;
    public int maxHp;
    protected float Hp;
    public virtual float _Hp
    {
        get { return Hp; }
        set
        {
            if (value > maxHp)
            {
                value = maxHp;
            }
            else if (value <= 0)
            {
                Die();
            }
            Hp = value;
        }
    }
    protected virtual void Start()
    {
        Hp = maxHp;
    }
    public virtual void Attack()
    {
        OnHit(this);
    }
    public abstract void Die();
    public abstract void OnHit(Entity entity,float Damage = 0);
}
