using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Basic,
    Target,
    Homming
}
[RequireComponent(typeof(BoxCollider2D))]
public class AttackProjectile : MonoBehaviour, IObjectPoolingObj
{
    public Entity shootSelf;
    public GameObject target;
    public float damage;
    public float speed;
    public float startWaitTime = 1;
    public float duration = 3;
    public bool canPierce;
    public ProjectileType projectileType;
    public DimensionType dimensionType;
    public GameObject onDestroyObj;

    private SpriteRenderer sprite;
    private Player player;
    private bool isRotateSet;
    private void Start()
    {
        player = Player.Instance;
    }
    private void Update()
    {
        if (startWaitTime > 0)
        {
            startWaitTime -= Time.deltaTime;
        }
        else if (projectileType == ProjectileType.Target)
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
        else if (projectileType == ProjectileType.Homming)
        {
            Vector2 len = target.transform.position - transform.position;
            float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, z);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (projectileType == ProjectileType.Basic)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
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
            if (onDestroyObj != null)
                ObjectPool.Instance.CreateObj(onDestroyObj, transform.position, transform.rotation);
            ObjectPool.Instance.DeleteObj(gameObject);
        }
        else if (shootSelf.GetComponent<Player>() && collision.TryGetComponent(out BaseEnemy enemy1))
        {
            shootSelf.Attack(enemy1, damage);
            if (!canPierce)
            {
                if (onDestroyObj != null)
                    ObjectPool.Instance.CreateObj(onDestroyObj, transform.position, transform.rotation);
                ObjectPool.Instance.DeleteObj(gameObject);
            }
        }
    }
    public void Init(Entity shootSelf, float damage, float speed, float startWaitTime, ProjectileType projectileType, GameObject target = null, float duration = 3)
    {
        this.shootSelf = shootSelf;
        this.damage = damage;
        this.speed = speed;
        this.startWaitTime = startWaitTime;
        this.target = target;
        this.projectileType = projectileType;
        this.duration = duration;
    }

    public void OnObjCreate()
    {
        if (transform.GetComponentInChildren<ProjectileSprite>())
        {
            sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }
        else
        {
            sprite = GetComponent<SpriteRenderer>();
        }

        dimensionType = transform.position.y > 0 ? DimensionType.OVER : DimensionType.UNDER;
        sprite.material = dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial;

        duration = 3;
        isRotateSet = false;
    }
}
