using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DimensionType
{
    OVER = 1,
    UNDER = -1
}

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    public float speed;
    public DimensionType dimensionType = DimensionType.OVER;
    protected Rigidbody2D rigid;
    [SerializeField] protected float maxHp;
    public virtual float _maxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    [SerializeField] protected float hp;
    public virtual float _hp
    {
        get { return hp; }
        set
        {
            if (value > _maxHp)
            {
                value = _maxHp;
            }
            else if (value <= 0)
            {
                Die();
                hp = 0;
                return;
            }
            hp = value;
        }
    }
    protected virtual void Start()
    {
        hp = _maxHp;
        rigid = GetComponent<Rigidbody2D>();
    }
    public virtual void Attack(Entity target, float atkDmg)
    {
        target.OnHit(this, atkDmg);
        target._hp -= atkDmg;
    }

    public abstract void Die();
    public abstract void OnHit(Entity atkEntity, float Damage = 0);
}
