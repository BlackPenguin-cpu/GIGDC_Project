using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyState
{
    MOVE,
    ATTACK,
    HIT,
    IDLE,
    DIE,
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
public class BaseEnemy : Entity, IObjectPoolingObj
{
    //HealthBar
    private GameObject HealthBarObj;
    private float hpShowDuration;

    protected new BoxCollider2D collider;
    protected AttackCollision[] attackCollisions;
    protected SpriteRenderer sprite;
    protected Player player;
    protected Animator animator;
    public System.Action onDie;

    public Range coinDropValueRange;
    public Range crystalDropValueRange;
    public EnemyBuffList buffList = new EnemyBuffList();
    private EnemyState state;
    public EnemyState _state
    {
        get
        {
            if (buffList.stun > 0)
            {
                return EnemyState.HIT;
            }
            return state;
        }
        set
        {
            state = value;
        }
    }
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
        OnObjCreate();
    }
    public virtual void OnObjCreate()
    {
        player = Player.Instance;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        attackCollisions = GetComponentsInChildren<AttackCollision>();

        if (transform.position.y < 0)
        {
            rigid.gravityScale = -rigid.gravityScale;
            sprite.flipY = true;
            dimensionType = DimensionType.UNDER;

            //TODO: 나중에 스프라이트나오면 그걸로 바꾸는 작업
            sprite.color = Color.black;
        }
        HealthBarObj = Instantiate(Resources.Load<GameObject>("HealthBar"), transform);
        HealthBarObj.transform.localScale = new Vector3(collider.size.x, 1, 1);
        HealthBarObj.transform.localPosition = new Vector3(0, dimensionType == DimensionType.OVER ? collider.size.y : -collider.size.y, 0);
    }
    protected virtual void Update()
    {
        HealthBarObj.SetActive(hpShowDuration > 0);
        AnimController();
        if (_state == EnemyState.HIT)
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
    /// 반드시 start문에서 발동해야하는 함수 
    /// </summary>
    protected virtual void BaseStatSet
        (float maxHp, float attackDamage, float attackDelay, float speed
        , float minCoin, float maxCoin, float minCrystal, float maxCrystal, float attackSpeed = 1)
    {
        this.maxHp = maxHp;
        this.attackDamage = attackDamage;
        this.attackDelay = attackDelay;
        this.speed = speed;
        coinDropValueRange.Min = minCoin;
        coinDropValueRange.Max = maxCoin;
        crystalDropValueRange.Min = minCrystal;
        crystalDropValueRange.Max = maxCrystal;
        this.attackSpeed = attackSpeed;
    }
    protected virtual void AnimController()
    {
        animator.SetInteger("State", (int)_state);
        animator.SetFloat("AttackSpeed", attackSpeed);
    }
    /// <summary>
    /// Move
    /// </summary>
    public virtual void Move()
    {
        if (_state != EnemyState.MOVE) return;
        if (attackCollisions[0].isCanAttack(this) && curAttackDelay < attackDelay) return;
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
        onDie += () => Player.Instance.DaggerSkill2(); // HOLLY SHIT
        onDie += () => CameraManager.Instance.CameraShake(0.1f, 0.4f, 0.05f);
        onDie += () => player.BloodGauntletAction(this);
        onDie += () => ObjectPool.Instance.DeleteObj(gameObject);
        onDie += () => _state = EnemyState.DIE;

        onDie.Invoke();
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
        rigid.AddForce(new Vector3(transform.position.x > atkEntity.transform.position.x ? 40 : -40, 0, 0));
        StartCoroutine(HitEffectCoroutine());
        HealthBarObj.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(hp / _maxHp, 1);
    }

    IEnumerator HitEffectCoroutine()
    {
        _state = EnemyState.HIT;
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _state = EnemyState.MOVE;
        sprite.color = Color.white;
    }

    public bool UseAttackCollision(int index, bool isForCheck = false)
    {
        foreach (AttackCollision attackCollision in attackCollisions)
        {
            if (attackCollision.index == index)
            {
                if (isForCheck)
                {
                    return attackCollision.isCanAttack(this);
                }
                else
                {
                    attackCollision.OnAttack(this);
                }
            }
        }
        return false;
    }


}
