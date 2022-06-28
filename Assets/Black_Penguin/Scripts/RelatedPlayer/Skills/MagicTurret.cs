using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTurret : BaseSkill
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform posGameObject;

    public float AttackSpeed;

    private Animator animator;
    private float duration = 20;
    private bool nowAttack;
    private float curAttackSpeed;
    protected override void Action()
    {
        AttackProjectile projectile = ObjectPool.Instance.CreateObj
                  (Bullet, new Vector3((sprite.flipX ? -1 : 1) * posGameObject.localPosition.x, posGameObject.localPosition.y) + transform.position, Quaternion.Euler(0, 0, sprite.flipX ? 180 : 0)).GetComponent<AttackProjectile>();
        projectile.Init(player, DefaultReturnDamage(), 15, 0, ProjectileType.Basic);
    }

    public override void OnObjCreate()
    {
        base.OnObjCreate();
        animator = GetComponent<Animator>();
        duration = 20;

        animator.Play("TurretOnSummon");
        sprite.color = Color.white;
        sprite.flipX = player.sprite.flipX;

    }
    private void Start()
    {
        player = Player.Instance;
    }
    //애니메이터에서 발동
    public void StartAnimEnd()
    {
        nowAttack = true;
    }
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 1)
        {
            sprite.color = new Color(1, 1, 1, duration);
        }
        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }

        if (nowAttack)
            curAttackSpeed += Time.deltaTime;
        if (curAttackSpeed > AttackSpeed)
        {
            curAttackSpeed = 0;
            Action();
        }
    }
}
