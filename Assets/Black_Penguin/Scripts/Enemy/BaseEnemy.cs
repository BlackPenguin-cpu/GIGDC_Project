
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    MOVE,
    IDLE,
    HIT,
    DIE,
    ATTACK
}

[System.Serializable]
public class EnemyBuffList
{
    public float stun = 0;
}
[System.Serializable]
public class Range
{
    public float Min;
    public float Max;
    public float randomRangeFloatReturn()
    {
        return Random.Range(Min, Max);
    }
    public int randomRangeIntReturn()
    {
        return (int)Random.Range(Min, Max);
    }
}
[RequireComponent(typeof(Animator))]
public class BaseEnemy : Entity
{
    //HealthBar
    private GameObject HealthBarObj;
    private float hpShowDuration;

    protected new BoxCollider2D collider;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rigid;
    protected Player player;
    protected Animator animator;
    public System.Action onDie;

    public Range coinDropValueRange;
    public Range crystalDropValueRange;
    public EnemyBuffList buffList = new EnemyBuffList();
    public EnemyState state;
    public float attackSpeed = 1;
    public float attackDelay;
    protected float curAttackDelay;
    public float attackDamage;

    public override float _hp
    {
        get => base._hp;
        set
        {
            if (value < hp)
            {
                OnHit(Player.Instance, hp - value);
            }
            base._hp = value;
        }
    }
    protected override void Start()
    {
        base.Start();
        player = Player.Instance;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        HealthBarObj = Instantiate(Resources.Load<GameObject>("HealthBar"), transform);
        HealthBarObj.transform.localScale = new Vector3(collider.size.x, 1, 1);
        HealthBarObj.transform.localPosition = new Vector3(0, collider.size.y, 0);
    }
    protected virtual void Update()
    {
        HealthBarObj.SetActive(hpShowDuration > 0);
        AnimController();
        if (state == EnemyState.HIT)
            curAttackDelay = 0;

        curAttackDelay += Time.deltaTime;
        buffList.stun -= Time.deltaTime;
        hpShowDuration -= Time.deltaTime;
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }
    /// <summary>
    /// 반드시 start문에서 발동해야하는 구문
    /// </summary>
    protected virtual void BaseStatSet
        (float hp, float attackDamage, float attackSpeed, float speed
        , float minCoin, float maxCoin, float minCrystal, float maxCrystal)
    {
        this.hp = hp;
        this.attackDamage = attackDamage;
        this.attackSpeed = attackSpeed;
        this.speed = speed;
        this.coinDropValueRange.Min = minCoin;
        this.coinDropValueRange.Max = maxCoin;
        this.crystalDropValueRange.Min = minCrystal;
        this.crystalDropValueRange.Max = maxCrystal;

    }
    protected virtual void AnimController()
    {
        return;//애니메이션 생긴 추후 수정
        animator.SetInteger("State", (int)state);
        animator.SetFloat("AttackSpeed", attackSpeed);
    }
    /// <summary>
    /// Move
    /// </summary>
    public virtual void Move()
    {
        if (state != EnemyState.MOVE) return;
        float dir;

        if (player.transform.position.x > transform.position.x)
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
        onDie += () => MaterialDrop();
        onDie += () => Player.Instance.DaggerSkill2();
        onDie += () => ObjectPool.Instance.DeleteObj(gameObject);
        onDie += () => CameraManager.instance.CameraShake(0.1f, 0.4f, 0.05f); ;

        state = EnemyState.DIE;
        //임시
        onDie.Invoke();
        if (gameObject.activeSelf)
            Destroy(gameObject);
    }

    void MaterialDrop()
    {
        int crystalDropValue = crystalDropValueRange.randomRangeIntReturn();
        int coinDropValue = crystalDropValueRange.randomRangeIntReturn();
        for (int i = 0; i < crystalDropValue / 10; i++)
        {
            Rigidbody2D crystalObj = Instantiate(Resources.Load<Rigidbody2D>("CrystalObj"), transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            crystalObj.AddTorque(Random.Range(-100, 100));
            crystalObj.AddForce(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
        }
        for (int i = 0; i < coinDropValue / 10; i++)
        {
            Rigidbody2D goldObj = Instantiate(Resources.Load<Rigidbody2D>("CoinObj"), transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            goldObj.AddTorque(Random.Range(-100, 100));
            goldObj.AddForce(new Vector2(Random.Range(-10, 10), Random.Range(10, 15)));
        }
        GameManager.Instance.crystal += crystalDropValue;
        GameManager.Instance._coin += coinDropValue;
    }
    /// <summary>
    /// OnHit
    /// </summary>
    public override void OnHit(Entity atkEntity, float Damage)
    {
        hpShowDuration = 3;
        player.onAttackHit(this);
        StartCoroutine(HitEffectCoroutine());
        HealthBarObj.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(hp / _maxHp, 1);
    }

    IEnumerator HitEffectCoroutine()
    {
        state = EnemyState.HIT;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        state = EnemyState.MOVE;
        sprite.color = Color.white;
    }
}
