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
public class Player : Entity
{
    public static Player Instance = null;

    Animator animator => GetComponent<Animator>();
    Rigidbody2D rigid => GetComponent<Rigidbody2D>();
    public new BoxCollider2D collider => GetComponent<BoxCollider2D>();
    public SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    PlayerWeaponType weaponType;
    PlayerState state;
    public PlayerStat stat;
    public float JumpPower;

    float curDashCooltime = 0;

    bool canJump = false;
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
    }
    public void CrystalCheck(int[] crystals)
    {
        for (int i = 0; i < (int)CrystalsType.END; i++)
        {
            //현재 보낸 배열을 마정석에 맞게 스텟 반영
        }
    }
    private void Update()
    {
        InputManager();
        JumpCheck();
        AnimationController();
        curDashCooltime += Time.deltaTime;
    }
    void AnimationController()
    {
        animator.SetInteger("State", (int)state);
        animator.SetInteger("Weapon", (int)weaponType);
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
    #region 플레이어 인풋
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

        float originGravity = rigid.gravityScale;
        rigid.gravityScale = 0;
        Vector3 dir = new Vector3(sprite.flipX == false ? 1 : -1, 0) / 2;
        var waitSec = new WaitForSeconds(0.01f);
        for (int i = 0; i < 10; i++)
        {
            rigid.velocity = Vector2.zero;
            transform.position += dir;
            yield return waitSec;
        }
        rigid.gravityScale = originGravity;
        state = PlayerState.Idle;
    }
    #region 공격관련함수
    void Attack()
    {
        if (state == PlayerState.Dash) return;
        state = PlayerState.Attack;
        StartCoroutine(AttackAction());
    }

    IEnumerator AttackAction()
    {

        yield return new WaitForSeconds(stat.attackSpeed);
        yield return new WaitForSeconds(0.5f);
        state = PlayerState.Idle;
    }

    //공격 관련 함수
    IEnumerator TestAttack()
    {
        RaycastHit2D[] raycasts = Physics2D.BoxCastAll(transform.position, transform.lossyScale, 0, sprite.flipX ? Vector2.left : Vector2.right);

        foreach (RaycastHit2D ray in raycasts)
        {
            if (ray.distance <= collider.size.x + 1 && ray.transform.TryGetComponent(out BaseEnemy enemy))
            {
                enemy._Hp -= stat.attackDamage;
            }
        }
        yield return new WaitForSeconds(0.5f);
        state = PlayerState.Idle;
    }
    #endregion
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

        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 1) sprite.flipX = false;
        if (horizontal == -1) sprite.flipX = true;

        if (Mathf.Abs(rigid.velocity.x + horizontal) > stat.maxSpeed)
        {
            return;
        }

        Vector2 dir = new Vector2(horizontal, 0) * stat.speed * Time.deltaTime;
        rigid.AddForce(dir);
    }
    public override void Die()
    {
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        print("깜펭바보");
        throw new System.NotImplementedException();
    }
    public override void OnHit()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
