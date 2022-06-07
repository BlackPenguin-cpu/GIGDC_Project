
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBuffList
{
    public float stun = 0;
}
public class BaseEnemy : Entity
{
    //HealthBar
    public GameObject HealthBar => Resources.Load<GameObject>("HealthBar");
    float hpShowDuration;

    public BoxCollider2D collider => GetComponent<BoxCollider2D>();
    public EnemyBuffList buffList = new EnemyBuffList();
    public SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    public float attackSpeed;
    public float attackDamage;
    public float speed;
    protected override void Start()
    {
        base.Start(); 
        Instantiate(HealthBar, transform);
    }
    private void Update()
    {
        HealthBar.SetActive(hpShowDuration > 0);
        HealthBar.transform.position = new Vector3(0, collider.size.y, 0);

        buffList.stun -= Time.deltaTime;
        hpShowDuration -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Move();
    }
    /// <summary>
    /// Move
    /// </summary>
    public virtual void Move()
    {
        float dir;

        if (Player.Instance.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
            dir = 1;
        }
        else
        {
            sprite.flipX = true;
            dir = -1;
        }

        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
    }
    /// <summary>
    /// Die
    /// </summary>
    public override void Die()
    {
        Player.Instance.DaggerSkill2();
        Destroy(gameObject);
    }
    /// <summary>
    /// OnHit
    /// </summary>
    /// <param name="atkEntity"></param>
    /// <param name="Damage"></param>
    public override void OnHit(Entity atkEntity, float Damage = 0)
    {
        hpShowDuration = 3;
        HealthBar.GetComponent<SpriteRenderer>().size = new Vector2(Hp / maxHp, 1);
    }
}
