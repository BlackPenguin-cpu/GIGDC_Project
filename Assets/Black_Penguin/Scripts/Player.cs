using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartStat
{
    public readonly float maxHp = 100;
    public readonly float speed = 20;
    public readonly float crit = 5;
    public readonly float def = 10;
    public readonly float cooldown = 0;
    public readonly float attackDamage = 10;
    public readonly float dashCooldown = 0.7f;
    public readonly int dashCount = 1;
}
[System.Serializable]
public class PlayerInfo
{
    StartStat startStat;
    public int level;
    public int _level
    {
        get { return _level; }
        set
        {
            switch (weaponType)
            {
                case PlayerWeaponType.Sword:
                    attackDamage = (10 * value) + 10 + startStat.attackDamage;
                    maxHp = (10 * value) + 10 + startStat.maxHp;
                    break;
                case PlayerWeaponType.Dagger:
                    attackDamage = (8 * value) + 8 + startStat.attackDamage;
                    crit = (value * 2) + startStat.crit;
                    break;
                case PlayerWeaponType.Axe:
                    attackDamage = (15 * value) + 20 + startStat.attackDamage;
                    def = (value * 5) + 5 + startStat.def;
                    break;
            }
            _level = value;
        }
    }

    public PlayerWeaponType weaponType;

    private float maxHp = 100;
    public float hp;
    private float speed = 20; // velocity
    private float crit = 5;
    private float def = 10;
    private float cooldown = 0;
    private float attackDamage = 10;
    public float dashCooldown = 0.7f;
    public float attackSpeed = 1;
    private int dashCount = 1;
    private int curDashCount;
    public int _dashCount
    {
        get
        {
            if (weaponType == PlayerWeaponType.Dagger)
                return dashCount + 1;
            else return dashCount;
        }
        set => dashCount = value;
    }
    public int _curDashCount
    {
        get { return curDashCount; }
        set
        {
            value = Mathf.Max(value, dashCount);
            curDashCount = value;
        }
    }
    public float _maxHp
    {
        get
        {
            float returnValue = maxHp;
            returnValue += Crystals[(int)CrystalsType.HEALTH] * 10;
            return returnValue;
        }
        set => maxHp = value;
    }
    public float _hp
    {
        get { return _hp; }
        set
        {

            _hp = value;
        }
    }
    public float _speed
    {
        get
        {
            float retrunValue = speed;
            retrunValue += speed * Crystals[(int)CrystalsType.SPEED] / 10;
            return retrunValue;
        }
        set => speed = value;
    }
    public float _crit
    {
        get
        {
            float returnValue = crit;
            return _crit;
        }
        set => crit = value;
    }
    public float _def
    {
        get
        {
            float returnValue = def;
            returnValue += cooldown + Crystals[(int)CrystalsType.DEFFENCE] * 2;
            return returnValue;
        }
        set { def = value; }
    }
    public float _cooldown
    {
        get
        {
            float returnValue = cooldown;
            returnValue += (cooldown * Crystals[(int)CrystalsType.TIME]) / 10;
            return returnValue;
        }
        set { cooldown = value; }
    }
    public float _attackDamage
    {
        get
        {
            float returnValue = attackDamage;
            returnValue += (returnValue * Crystals[(int)CrystalsType.POWER]) / 10;

            if (PlayerDATypeList.TheOneRing)
                returnValue *= 1.6f;
            return returnValue;
        }
        set { attackDamage = value; }
    }
    public float _attackSpeed
    {
        get
        {
            float returnValue = attackSpeed;
            returnValue += returnValue * Crystals[(int)CrystalsType.ATTACKSPEED];
            if (bloodGauntletDuration > 0)
                return returnValue * 1.5f;
            else
                return returnValue;
        }
        set { attackSpeed = value; }
    }
    public float bloodGauntletDuration;
    public PlayerDAType PlayerDATypeList;
    public int[] Crystals = new int[(int)CrystalsType.END];
}
[System.Serializable]
public class PlayerDAType
{
    public bool WindEarRing;
    public bool NeedleArmour;
    public bool KnifeCape;
    public bool CurseKnife;
    public bool BloodGauntlet;
    public bool CrystalOrb;
    public bool TheOneRing;
}
public enum PlayerWeaponType
{
    NONE,
    Sword,
    Dagger,
    Axe
}
public enum PlayerState
{
    Idle,
    Walk,
    Dash,
    Attack,
    Jump,
    JumpAttack,
    Die
}

public enum PlayerType
{
    Down = -1,
    Up = 1
}
[RequireComponent(typeof(Rigidbody2D))]

public class Player : Entity
{
    public static Player Instance = null;

    Animator animator => GetComponent<Animator>();
    Rigidbody2D rigid => GetComponent<Rigidbody2D>();
    new BoxCollider2D collider => GetComponent<BoxCollider2D>();
    public SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    PlayerState state;
    public PlayerInfo stat;
    public float JumpPower;

    float curDashCooltime = 0;

    new protected float maxHp;
    public float _maxHp
    {
        get => _maxHp + stat.Crystals[(int)CrystalsType.HEALTH] * 10;
        set => _maxHp = value;
    }
    bool canJump = false;

    public override float _Hp
    {
        get => base._Hp;
        set
        {
            if (value < Hp)
            {
                if (state == PlayerState.Dash) return;
                value -= stat._def;
                value = Mathf.Clamp(value, 0, Hp);
            }
            base._Hp = value;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        InputManager();
        JumpCheck();
        AnimationController();
        PlayerItemContoroller();

        curDashCooltime += Time.deltaTime;
        if (curDashCooltime > stat.dashCooldown && stat._dashCount > stat._curDashCount)
        {
            curDashCooltime = 0;
            stat._curDashCount++;
        }
    }
    void PlayerItemContoroller()
    {
        if (stat.PlayerDATypeList.CurseKnife && cursedKnifeCoolodwn < curCursedKnifeCoolodwn)
        {
            cursedKnifeAction();
            curCursedKnifeCoolodwn = 0;
        }
        curCursedKnifeCoolodwn += Time.deltaTime;
        curWindEarRingDashCooldown += Time.deltaTime;
        stat.bloodGauntletDuration -= Time.deltaTime;
    }
    void AnimationController()
    {
        animator.SetInteger("State", (int)state);
        animator.SetInteger("Weapon", (int)stat.weaponType);
        animator.SetBool("isAttack", isAttack);
        animator.SetFloat("AttackSpeed", stat.attackSpeed);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
    public override void OnHit(Entity entity, float Damage = 0)
    {
        if (stat.PlayerDATypeList.NeedleArmour && Random.Range(0, 10) == 0) needleArmourAction(entity);
    }
    #region 플레이어 인풋
    //플레이어 인풋
    void InputManager()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dash();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Jump();
        }
    }
    #region 공격관련함수
    bool isAttack;
    Coroutine nowAttackAction;
    public override void Attack()
    {
        if (state != PlayerState.Idle && state != PlayerState.Walk && state != PlayerState.Attack) return;
        state = PlayerState.Attack;
        switch (stat.weaponType)
        {
            case PlayerWeaponType.NONE:
                nowAttackAction = StartCoroutine(AttackAction());
                break;
            case PlayerWeaponType.Sword:
                if (nowAttackAction != null)
                    StopCoroutine(nowAttackAction);
                nowAttackAction = StartCoroutine(AttackAction());
                break;
            case PlayerWeaponType.Dagger:
                if (nowAttackAction != null)
                    StopCoroutine(nowAttackAction);
                nowAttackAction = StartCoroutine(AttackAction());
                break;
            case PlayerWeaponType.Axe:
                if (nowAttackAction != null)
                    StopCoroutine(nowAttackAction);
                nowAttackAction = StartCoroutine(AttackAction());
                break;
            default:
                break;
        }
    }

    IEnumerator AttackAction()
    {
        yield return null;
        isAttack = true;
        yield return new WaitForSeconds(1 / stat.attackSpeed);
        state = PlayerState.Idle;
        isAttack = false;
    }

    IEnumerator TestAttack()
    {
        RaycastHit2D[] raycasts = Physics2D.BoxCastAll(transform.position, transform.lossyScale, 0, sprite.flipX ? Vector2.left : Vector2.right);

        foreach (RaycastHit2D ray in raycasts)
        {
            if (ray.distance <= collider.size.x + 1 && ray.transform.TryGetComponent(out BaseEnemy enemy))
            {
                enemy._Hp -= stat._attackDamage;
            }
        }
        yield return new WaitForSeconds(0.5f);
        state = PlayerState.Idle;
    }
    void onAttackHit(Entity entity)
    {
        if (stat.PlayerDATypeList.BloodGauntlet)
        {
            BloodGauntletAction(entity);
        }
    }
    #endregion
    void Dash()
    {
        if (state != PlayerState.Walk && state != PlayerState.Idle) return;
        if (stat._curDashCount > 0)
        {
            stat._dashCount--;
            StartCoroutine(DashAction());
        }
        else if (stat.PlayerDATypeList.WindEarRing)
        {
            windEarRingAction();
        }
    }
    IEnumerator DashAction()
    {
        state = PlayerState.Dash;

        float originGravity = rigid.gravityScale;
        rigid.gravityScale = 0;
        Vector3 dir = new Vector3(sprite.flipX == false ? 1 : -1, 0) / 2;
        var waitSec = new WaitForSeconds(0.01f);

        var enemies = new List<BaseEnemy>();
        for (int i = 0; i < 10; i++)
        {
            if (stat.PlayerDATypeList.KnifeCape)
            {
                knifeCapeAction(enemies);
            }

            rigid.velocity = Vector2.zero;
            transform.position += dir;
            yield return waitSec;
        }
        rigid.gravityScale = originGravity;
        state = PlayerState.Idle;
    }
    void Jump()
    {
        if (state == PlayerState.Dash || state == PlayerState.Attack || state == PlayerState.JumpAttack) return;
        if (canJump)
        {
            canJump = false;
            rigid.velocity = new Vector3(rigid.velocity.x, 0);
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
    void JumpCheck()
    {
        RaycastHit2D[] raycasts = Physics2D.BoxCastAll(transform.position, transform.lossyScale, 0, Vector2.down);
        if (raycasts != null && rigid.velocity.y <= 0)
            foreach (RaycastHit2D ray in raycasts)
            {
                if (ray.transform.gameObject.tag.Contains("Platform") && ray.distance < collider.size.y / 2)
                {
                    canJump = true;
                }
            }
    }
    private void Move()
    {
        if (state == PlayerState.Dash || state == PlayerState.Attack)
        {
            return;
        }
        state = PlayerState.Walk;

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 1) sprite.flipX = false;
        if (horizontal == -1) sprite.flipX = true;

        Vector2 dir = new Vector2(horizontal, 0) * stat._speed * Time.deltaTime;
        rigid.velocity += dir;

        if (dir == Vector2.zero && state == PlayerState.Walk)
            state = PlayerState.Idle;
    }
    #endregion
    #region 플레이어 아이템

    float windEarRingDashCooldown => curDashCooltime;
    float curWindEarRingDashCooldown;
    void windEarRingAction()
    {
        if (curWindEarRingDashCooldown > windEarRingDashCooldown)
        {
            curWindEarRingDashCooldown = 0;
            StartCoroutine(DashAction());
        }
    }
    void needleArmourAction(Entity entity)
    {
        entity._Hp -= stat._attackDamage / 5;
    }
    void knifeCapeAction(List<BaseEnemy> enemies)
    {

        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, Vector2.zero);
        foreach (RaycastHit2D raycast in rays)
        {
            if (raycast.collider.TryGetComponent(out BaseEnemy enemy))
            {
                if (!enemies.Find(x => x == enemy))
                {
                    enemy._Hp -= 10;
                    enemies.Add(enemy);
                }
            }
        }
    }
    public float cursedKnifeCoolodwn = 10;
    float curCursedKnifeCoolodwn = 0;
    void cursedKnifeAction()
    {
        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        BaseEnemy target = null;
        float maxDistance = 0;

        foreach (BaseEnemy enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, transform.position);
            if (maxDistance < distance)
            {
                maxDistance = distance;
                target = enemy;
            }
        }

        CursedKnife obj = Instantiate(Resources.Load<CursedKnife>(""), transform.position, Quaternion.identity);
        obj.damage = stat._attackDamage * 2;
        obj.speed = stat._speed * 2;
        obj.rotatePower = 5;
        obj.target = target.gameObject;
    }
    void BloodGauntletAction(Entity entity)
    {
        stat.bloodGauntletDuration = 3;
    }
    public float crystalOrbCoolodwn = 40;
    float curCrystalOrbCoolodwn = 0;
    void CrystalOrbAction()
    {
        //겁나 큰 폭*발 (리소스 주면 함 ㄹㅇㅋㅋ)
    }
    void TheOneRing()
    {
        //참격도 리소스 주면 함 ㄹㅇㅋㅋ
    }
    #endregion
    #region 플레이어 장비 스킬
    #region 검
    void SwordSkill1()
    {

    }
    #endregion
    #region 단검
    void DaggerSkill1()
    {

    }
    #endregion
    #region 도끼
    void AxeSkill1()
    {

    }
    #endregion
    #endregion
}
