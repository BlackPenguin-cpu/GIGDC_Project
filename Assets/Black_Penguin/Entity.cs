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
                return;
            }
            if (value < Hp)
            {
                OnHit();
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
    abstract public void Die();
    abstract public void OnHit();
}
