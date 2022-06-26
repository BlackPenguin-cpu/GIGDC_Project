using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Basic,
    Target,
    Homing
}
public class AttackProjectile : MonoBehaviour
{
    public Entity shootSelf;
    public GameObject target;
    public float damage;
    public float speed;
    public ProjectileType projectileType;

    Player player;
    public AttackProjectile(Entity shootSelf, float damage, float speed, ProjectileType projectileType, GameObject target = null)
    {
        this.shootSelf = shootSelf;
        this.damage = damage;
        this.speed = speed;
        this.target = target;
        this.projectileType = projectileType;
    }
    private void Start()
    {
        player = Player.Instance;
        if (projectileType == ProjectileType.Target)
            transform.LookAt(target.transform);
    }
    private void Update()
    {
        if (projectileType == ProjectileType.Target)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shootSelf.TryGetComponent(out BaseEnemy enemy) && collision.GetComponent<ITypePlayer>() != null)
        {
            shootSelf.Attack(player, damage);
        }
        else if (shootSelf.TryGetComponent(out Player player1) && collision.TryGetComponent(out BaseEnemy enemy1))
        {
            shootSelf.Attack(enemy1, damage);
        }
    }
}
