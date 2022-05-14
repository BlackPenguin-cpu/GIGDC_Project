using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[System.Serializable]
public class PlayerStat
{
    public float maxSpeed;
    public float speed; // velocity
    public float crit;
    public float def;
    public float dashCooldown;
    public float attackDamage;
    public float attackSpeed;
}
public enum PlayerWeaponType
{
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

public enum PlayerPosiontion
{
    Up,
    Down
}

public class Player : Entity
{
    public static Player Instance;

    Animator animator;
    Rigidbody2D rigid;
    PlayerPosiontion posiontion;
    PlayerWeaponType weaponType;
    PlayerState state;
    public PlayerStat stat;
    public float JumpPower;

    float curDashCooltime = 0;

    bool canJump;
    public override float _Hp
    {
        get => base._Hp;
        set
        {
            if (value < Hp)
            {
                if (state == PlayerState.Dash) return;
                value -= stat.def;
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
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        InputManager();
        JumpCheck();
        curDashCooltime += Time.deltaTime;
    }
    void AnimationController()
    {
        //animator.SetInteger("State", (int)state);
        //animator.SetInteger("Weapon", (int)weaponType);
        switch (weaponType)
        {
            case PlayerWeaponType.Sword:
                switch (state)
                {
                    case PlayerState.Idle:
                        break;
                    case PlayerState.Walk:
                        break;
                    case PlayerState.Dash:
                        break;
                    case PlayerState.Attack:
                        break;
                    case PlayerState.Jump:
                        break;
                    case PlayerState.JumpAttack:
                        break;
                    case PlayerState.Die:
                        break;
                    default:
                        break;
                }
                break;
            case PlayerWeaponType.Dagger:
                switch (state)
                {
                    case PlayerState.Idle:
                        break;
                    case PlayerState.Walk:
                        break;
                    case PlayerState.Dash:
                        break;
                    case PlayerState.Attack:
                        break;
                    case PlayerState.Jump:
                        break;
                    case PlayerState.JumpAttack:
                        break;
                    case PlayerState.Die:
                        break;
                    default:
                        break;
                }
                break;
            case PlayerWeaponType.Axe:
                switch (state)
                {
                    case PlayerState.Idle:
                        break;
                    case PlayerState.Walk:
                        break;
                    case PlayerState.Dash:
                        break;
                    case PlayerState.Attack:
                        break;
                    case PlayerState.Jump:
                        break;
                    case PlayerState.JumpAttack:
                        break;
                    case PlayerState.Die:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
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
    //플레이어 인풋
    void Dash()
    {
        if (stat.dashCooldown < curDashCooltime)
        {
            curDashCooltime = 0;
            StartCoroutine(DashAction());
        }
    }
    IEnumerator DashAction()
    {
        state = PlayerState.Dash;

        float horizontal = Input.GetAxisRaw("Horizontal") / 5;
        Vector3 dir = new Vector3(horizontal, 0);
        for (int i = 0; i < 20; i++)
        {
            rigid.velocity = Vector2.zero;
            transform.position += dir;
            yield return new WaitForSeconds(0.002f);
        }
        state = PlayerState.Idle;

    }
    void Attack()
    {
        if (state == PlayerState.Dash) return;
    }
    void Jump()
    {

        if (state == PlayerState.Dash || state == PlayerState.Attack || state == PlayerState.JumpAttack) return;
        if (canJump)
        {
            canJump = false;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }
    void JumpCheck()
    {
        Vector2 size = new Vector2(100, 100);

        RaycastHit2D[] raycasts = Physics2D.BoxCastAll(transform.position, transform.lossyScale, 0, Vector2.down);
        if (raycasts != null)
            foreach (RaycastHit2D ray in raycasts)
            {
                if (ray.transform.gameObject.tag.Contains("Platform"))
                {
                    canJump = true;
                }
            }
    }
    private void Move()
    {
        if (state == PlayerState.Dash) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(rigid.velocity.x + horizontal) > stat.maxSpeed)
            return;

        Vector2 dir = new Vector2(horizontal, 0) * stat.speed * Time.deltaTime;
        rigid.AddForce(dir);
    }
    public override void Die()
    {
        throw new System.NotImplementedException();
    }
    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }
}
