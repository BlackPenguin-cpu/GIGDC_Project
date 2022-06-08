
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
    private GameObject HealthBarObj;
    private float hpShowDuration;

    public EnemyBuffList buffList = new EnemyBuffList();
    private new BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Rigidbody2D rigid;

    public float attackSpeed;
    public float attackDamage;

    public override float _Hp
    {
        get => base._Hp;
        set
        {
            if (value < Hp)
            {
                OnHit(Player.Instance, Hp - value);
            }
            base._Hp = value;
        }
    }
    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        HealthBarObj = Instantiate(Resources.Load<GameObject>("HealthBar"), transform);
        HealthBarObj.transform.localScale = new Vector3(collider.size.x, 1, 1);
        HealthBarObj.transform.localPosition = new Vector3(0, collider.size.y, 0);
    }
    private void Update()
    {
        HealthBarObj.SetActive(hpShowDuration > 0);

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
    public override void OnHit(Entity atkEntity, float Damage)
    {
        hpShowDuration = 3;
        StartCoroutine(HitEffectCoroutine());
        HealthBarObj.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(Hp - Damage / maxHp, 1);
    }

    IEnumerator HitEffectCoroutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
