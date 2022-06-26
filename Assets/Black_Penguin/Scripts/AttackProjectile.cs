using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Basic,
    Target,
    Homing
}
[RequireComponent(typeof(BoxCollider2D))]
public class AttackProjectile : MonoBehaviour, IObjectPoolingObj
{
    public Entity shootSelf;
    public GameObject target;
    public float damage;
    public float speed;
    public float startWaitTime = 1;
    public ProjectileType projectileType;

    private Player player;
    private bool isRotateSet;
    private void Start()
    {
        player = Player.Instance;
    }
    private void Update()
    {
        if (projectileType == ProjectileType.Target)
        {
            if (startWaitTime > 0)
            {
                startWaitTime -= Time.deltaTime;
            }
            else
            {
                if (isRotateSet == false)
                {
                    isRotateSet = true;
                    Vector2 len = target.transform.position - transform.position;
                    float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, z);
                }
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO : 스트링 다매요
        if (collision.gameObject.CompareTag("Platform"))
            ObjectPool.Instance.DeleteObj(gameObject);

        if (shootSelf.TryGetComponent(out BaseEnemy enemy) && collision.GetComponent<ITypePlayer>() != null)
        {
            shootSelf.Attack(player, damage);
            ObjectPool.Instance.DeleteObj(gameObject);
        }
        else if (shootSelf.TryGetComponent(out Player player1) && collision.TryGetComponent(out BaseEnemy enemy1))
        {
            shootSelf.Attack(enemy1, damage);
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
    public void Init(Entity shootSelf, float damage, float speed, float startWaitTime, ProjectileType projectileType, GameObject target = null)
    {
        this.shootSelf = shootSelf;
        this.damage = damage;
        this.speed = speed;
        this.startWaitTime = startWaitTime;
        this.target = target;
        this.projectileType = projectileType;
    }

    public void OnObjCreate()
    {
    }
}
