using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    public float speed;
    public float maxHp;

    [SerializeField] protected float Hp;
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
    public virtual void Attack(Entity target, float atkDmg)
    {
        target.OnHit(this, atkDmg);
        target._Hp -= atkDmg;
    }

    public abstract void Die();
    public abstract void OnHit(Entity atkEntity, float Damage = 0);
}
