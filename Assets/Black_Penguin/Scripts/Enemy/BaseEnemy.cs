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
    protected GameObject HealthBarObj;
    protected float hpShowDuration;

    protected new BoxCollider2D collider;
    protected AttackCollision[] attackCollisions;
    protected SpriteRenderer sprite;
    protected Player player;
    protected Animator animator;
    public System.Action onDie;

    public Range coinDropValueRange;
    public Range crystalDropValueRange;
    public EnemyBuffList buffList = new EnemyBuffList();
    public int HealingOrbChance;

    [SerializeField] protected EnemyState state;
    private GameObject HealingOrbObj;
    public virtual EnemyState _state
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

        OnDieActionAdd();
    }
    public virtual void OnDieActionAdd()
    {
        onDie += () => ObjectPool.Instance.CreateObj(GameManager.Instance.DropGoods, transform.position, transform.rotation);
        onDie += () => Player.Instance.DaggerSkill2(); // HOLY SHIT
        onDie += () => CameraManager.Instance.CameraShake(0.1f, 0.4f, 0.05f);
        onDie += () => player.BloodGauntletAction(this);
        onDie += () => _state = EnemyState.DIE;
        onDie += () => DropHealingOrbObj();
        onDie += () => ObjectPool.Instance.DeleteObj(gameObject);
    }
    protected void DropHealingOrbObj()
    {
        if (Random.Range(0, 100) < HealingOrbChance)
        {
            GameObject obj = ObjectPool.Instance.CreateObj(HealingOrbObj, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            obj.GetComponent<SpriteRenderer>().flipY = sprite.flipY;
        }
    }
    public virtual void OnObjCreate()
    {
        player = Player.Instance;
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        attackCollisions = GetComponentsInChildren<AttackCollision>();

        state = EnemyState.MOVE;
        hp = _maxHp;
        sprite.color = Color.white;
        if (transform.position.y < 0)
        {
            rigid.gravityScale = -1;
            sprite.flipY = true;
            dimensionType = DimensionType.UNDER;

            sprite.material = dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial;
        }
        else
        {
            dimensionType = DimensionType.OVER;
            rigid.gravityScale = 1;
            sprite.flipY = false;
            sprite.material = dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial;
        }
        if (HealthBarObj == null)
        {
            HealthBarObj = Instantiate(Resources.Load<GameObject>("HealthBar"), transform);
            HealthBarObj.transform.localScale = new Vector3(collider.size.x, 1, 1);
            HealthBarObj.transform.localPosition = new Vector3(0, dimensionType == DimensionType.OVER ? collider.size.y : -collider.size.y, 0);
        }

    }
    protected virtual void Update()
    {
        HealthBarObj.SetActive(hpShowDuration > 0);
        AnimController();
        if (player._hp <= 0)
        {
            _state = EnemyState.HIT;
            return;
        }
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
        MaterialDrop();
        onDie.Invoke();
    }

    protected void MaterialDrop()
    {
        int crystalDropValue = crystalDropValueRange.randomRangeIntReturn();
        int coinDropValue = crystalDropValueRange.randomRangeIntReturn();
        GameManager.Instance.crystal += crystalDropValue;
        GameManager.Instance._coin += coinDropValue;
        Debug.Log(GameManager.Instance.crystal);
    }
    /// <summary>
    /// OnHit
    /// </summary>
    public override void OnHit(Entity atkEntity, float Damage)
    {
        SoundManager.instance.PlaySoundClip("SFX_Hit", SoundType.SFX);
        hpShowDuration = 3;
        rigid.AddForce(new Vector3(transform.position.x > atkEntity.transform.position.x ? 40 : -40, 0, 0));
        StartCoroutine(HitEffectCoroutine());
        HealthBarObj.transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(hp / _maxHp, 1);
    }

    public IEnumerator HitEffectCoroutine()
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
