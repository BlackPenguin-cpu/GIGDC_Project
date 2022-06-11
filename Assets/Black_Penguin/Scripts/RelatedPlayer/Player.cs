using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct TagName
{
    public const string Platform = "Platform";
}
[System.Serializable]
public class StartStat
{
    public readonly float originalMaxHp = 100;
    public readonly float originalSpeed = 20;
    public readonly float originalCrit = 5;
    public readonly float originalDef = 10;
    public readonly float originalCooldown = 0;
    public readonly float originalDashCooldown = 0.7f;
    public readonly int originalDashCount = 1;
    public readonly float originalAttackDamage = 10;
}
[System.Serializable]
public class PlayerInfo
{
    public int level;
    private StartStat startStat;
    public int _level
    {
        get { return _level; }
        set
        {
            switch (weaponType)
            {
                case PlayerWeaponType.Sword:
                    attackDamage = (10 * value) + 10 + startStat.originalAttackDamage;
                    maxHp = (10 * value) + 10 + startStat.originalMaxHp;
                    break;
                case PlayerWeaponType.Dagger:
                    attackDamage = (8 * value) + 8 + startStat.originalAttackDamage;
                    crit = (value * 2) + startStat.originalCrit;
                    break;
                case PlayerWeaponType.Axe:
                    attackDamage = (15 * value) + 20 + startStat.originalAttackDamage;
                    def = (value * 5) + 5 + startStat.originalDef;
                    break;
            }
            _level = value;
        }
    }

    public PlayerWeaponType weaponType;

    private float maxHp = 100;
    public float hp;
    public float speed = 20; // velocity
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

            if (value < hp && weaponType == PlayerWeaponType.Sword)
            {
                value = Mathf.Min(value + 5, hp);
            }
            if (value <= 0)
            {
                if (weaponType == PlayerWeaponType.Sword && level >= 5 && swordSkill3Boolean == false)
                {
                    value = 1;
                    swordSkill3Boolean = true;
                }
            }
            _hp = value;
        }
    }
    public float _speed
    {
        get
        {
            float returnValue = speed;
            returnValue += returnValue * Crystals[(int)CrystalsType.SPEED] / 10;
            if (weaponType == PlayerWeaponType.Axe)
            {
                returnValue *= 0.8f;
            }
            else if (weaponType == PlayerWeaponType.Dagger)
            {
                returnValue *= 1.1f;
                if (level >= 1)
                {
                    returnValue *= 1.1f;
                }
                if (level >= 3)
                {
                    returnValue += returnValue * ((daggerSkill2Count * 5) * 0.01f);
                }
            }

            return returnValue;
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
            returnValue += Crystals[(int)CrystalsType.DEFFENCE] * 5;
            if (weaponType == PlayerWeaponType.Sword && level >= 1)
            {
                returnValue *= 1.15f;
                if (hp / maxHp <= 0.3f && level >= 3)
                {
                    returnValue *= 1.3f;
                }
            }
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

            if (weaponType == PlayerWeaponType.Sword && hp / maxHp <= 0.3f && level >= 3)
                returnValue *= 1.3f;

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
            if (weaponType == PlayerWeaponType.Axe)
                returnValue *= 0.8f;
            if (weaponType == PlayerWeaponType.Dagger)
                returnValue *= 1.1f;
            returnValue += returnValue * Crystals[(int)CrystalsType.ATTACKSPEED];

            if (weaponType == PlayerWeaponType.Dagger && level >= 3)
            {
                returnValue *= (daggerSkill2Count * 5) * 0.01f;
            }

            if (bloodGauntletDuration > 0)
                return returnValue * 1.5f;
            else
                return returnValue;
        }
        set { attackSpeed = value; }
    }

    readonly float ConDefValue = 40;
    public float ReturnDefValue()
    {
        return def - (def / ConDefValue);
    }
    public float bloodGauntletDuration;
    public PlayerDAType PlayerDATypeList;
    public int[] Crystals = new int[(int)CrystalsType.END];

    //무기 관련 인덱스

    //죽으면 초기화..
    public bool swordSkill3Boolean = false;

    public int daggerSkill2Count = 0;
    public float daggerSkill2PassedTime = 0;
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
    Animator animator;
    Rigidbody2D rigid;
    new BoxCollider2D collider;
    public SpriteRenderer sprite;
    public AttackCollision[] attackCollisions;

    [SerializeField] PlayerState state;
    public PlayerInfo stat;
    public float JumpPower;

    float curDashCooltime = 0;

    bool canJump = false;

    public override float _Hp
    {
        get => stat._hp;
        set
        {
            if (value < Hp)
            {
                if (state == PlayerState.Dash) return;
                value -= stat._def;
                value = Mathf.Clamp(value, 0, Hp);
            }
            stat._hp = base._Hp = value;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        attackCollisions = GetComponentsInChildren<AttackCollision>();
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
        if (stat.PlayerDATypeList.CurseKnife && cursedKnifeCooldown < curCursedKnifeCooldown)
        {
            cursedKnifeAction();
            curCursedKnifeCooldown = 0;
        }
        if (stat.daggerSkill2PassedTime < 0)
        {
            stat.daggerSkill2Count = 0;
        }
        curCursedKnifeCooldown += Time.deltaTime;
        curWindEarRingDashCooldown += Time.deltaTime;
        stat.bloodGauntletDuration -= Time.deltaTime;
        stat.daggerSkill2PassedTime -= Time.deltaTime;
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
            OnAttack();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Jump();
        }
    }
    private void Dash()
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
    private IEnumerator DashAction()
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
            if (stat.weaponType == PlayerWeaponType.Axe && stat.level >= 1)
            {
                AxeSkill1(enemies);
            }

            rigid.velocity = Vector2.zero;
            transform.position += dir;
            yield return waitSec;
        }
        rigid.gravityScale = originGravity;
        state = PlayerState.Idle;
    }
    private void Jump()
    {
        if (state == PlayerState.Dash || state == PlayerState.Attack || state == PlayerState.JumpAttack) return;
        if (canJump == false) return;

        canJump = false;
        rigid.velocity = new Vector3(rigid.velocity.x, 0);
        rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }
    private void JumpCheck()
    {
        RaycastHit2D[] raycasts = Physics2D.BoxCastAll(transform.position, transform.lossyScale, 0, Vector2.down);
        if (raycasts != null && rigid.velocity.y <= 0)
        {
            foreach (RaycastHit2D ray in raycasts)
            {
                if (ray.transform.gameObject.tag.Contains("Platform") && ray.distance < collider.size.y / 2)
                {
                    canJump = true;
                }
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
        transform.Translate(dir);

        if (dir == Vector2.zero && state == PlayerState.Walk)
            state = PlayerState.Idle;
    }
    #region 공격관련함수
    bool isAttack;
    Coroutine nowAttackAction;
    public void OnAttack()
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
    public override void Attack(Entity target, float atkDmg)
    {
        base.Attack(target, atkDmg);
    }
    public void AnimAttackFunc(int index)
    {
        foreach (AttackCollision attackCollision in attackCollisions)
        {
            if (attackCollision.index == index && attackCollision.weaponType == stat.weaponType)
            {
                if (stat.weaponType == PlayerWeaponType.Dagger && Input.GetAxisRaw("Horizontal") == (sprite.flipX ? -1 : 1))
                {
                    rigid.AddForce(new Vector2((sprite.flipX ? -1 : 1) * 5, 0), ForceMode2D.Impulse);
                }
                if (stat.weaponType == PlayerWeaponType.Axe)
                {
                    CameraManager.instance.CameraShake(0.1f, 0.1f, 0.05f);
                }
                attackCollision.OnAttack(this);
            }
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
    public void onAttackHit(Entity entity)
    {
        entity.GetComponent<Rigidbody2D>().AddForce(new Vector3(sprite.flipX ? -50 : 50, 30, 0));
        if (stat.PlayerDATypeList.BloodGauntlet)
        {
            BloodGauntletAction(entity);
        }
    }
    #endregion

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
        Attack(entity, stat._attackDamage / 5);
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
    public float cursedKnifeCooldown = 10;
    float curCursedKnifeCooldown = 0;
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
    #region 단검
    //Enemy에서 발동시킴
    public void DaggerSkill2()
    {
        if (stat.level >= 3 && stat.weaponType == PlayerWeaponType.Dagger)
        {
            stat.daggerSkill2Count++;
            stat.daggerSkill2PassedTime = 5;
            stat.daggerSkill2Count = Mathf.Max(stat.daggerSkill2Count, 5);
        }
    }
    //Animator에서 발동시킴
    public void DaggerSkill3()
    {
        if (stat.level >= 5 && stat.weaponType == PlayerWeaponType.Dagger)
        {
            DaggerSkillObj obj = Instantiate(Resources.Load<DaggerSkillObj>(""), transform.position, Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().flipX = sprite.flipX;
            obj.damage = stat._attackDamage / 3;
        }
    }
    #endregion
    #region 도끼
    void AxeSkill1(List<BaseEnemy> enemies)
    {
        float forcePower = 30;

        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, Vector2.zero);
        foreach (RaycastHit2D raycast in rays)
        {
            if (raycast.collider.TryGetComponent(out BaseEnemy enemy))
            {
                if (!enemies.Find(x => x == enemy))
                {
                    enemy._Hp -= stat._attackDamage / 4;
                    enemy.GetComponent<Rigidbody2D>().AddForce(sprite.flipX ? Vector2.left : Vector2.right * forcePower);
                    enemies.Add(enemy);
                }
            }
        }
    }
    public void AxeSkill2(List<BaseEnemy> enemies)
    {
        foreach (BaseEnemy enemy in enemies)
        {
            enemy.buffList.stun = 2;
        }
    }
    void AxeSkill3()
    {
        //리소스 들어오면 제작 시작
    }

    #endregion
    #endregion
}
