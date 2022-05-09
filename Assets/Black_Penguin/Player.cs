using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[System.Serializable]
public class PlayerStat
{
    public float speed;
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

public class Player : Entity
{
    public static Player Instance;
    
    public Vector2 maxSpeed;
    Rigidbody2D rigid;
    PlayerWeaponType weaponType;
    PlayerState state;
    public PlayerStat stat;
    public override float _Hp
    {
        get => base._Hp;
        set
        {
            if (value < Hp)
            {
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
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        InputManager();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void AnimationController()
    {
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
    //플레이어 행동
    void Dash()
    {

    }
    void Attack()
    {

    }
    void Jump()
    {

    }
    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(rigid.velocity.x + vertical) > maxSpeed.x)
            vertical = 0;

        Vector2 dir = new Vector2(0, vertical) * speed * Time.deltaTime;
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
