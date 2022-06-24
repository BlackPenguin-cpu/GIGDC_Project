using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Entity : MonoBehaviour
{
    public float speed;
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
        target.rigid.AddForce(new Vector3(transform.position.x > target.transform.position.x ? -100 : 100, 30, 0));
        target.OnHit(this, atkDmg);
        target._hp -= atkDmg;
    }

    public abstract void Die();
    public abstract void OnHit(Entity atkEntity, float Damage = 0);
}
