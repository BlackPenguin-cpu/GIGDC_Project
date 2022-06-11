using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    public Entity shootSelf;
    public GameObject target;
    public float damage;
    public float speed;
    public AttackProjectile(Entity shootSelf, float damage, float speed, GameObject target = null)
    {
        this.shootSelf = shootSelf;
        this.damage = damage;
        this.speed = speed;
        this.target = target;
    }
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shootSelf.TryGetComponent(out BaseEnemy enemy) && collision.TryGetComponent(out Player player))
        {
            shootSelf.Attack(player, damage);
        }
        else if (shootSelf.TryGetComponent(out Player player1) && collision.TryGetComponent(out BaseEnemy enemy1))
        {
            shootSelf.Attack(enemy1, damage);
        }
    }
}
