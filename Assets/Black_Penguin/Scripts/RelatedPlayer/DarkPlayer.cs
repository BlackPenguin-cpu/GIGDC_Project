using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPlayer : Entity, ITypePlayer
{
    public static DarkPlayer Instance;

    Player player;
    AttackCollision[] attackCollisions;
    SpriteRenderer sprite;
    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void OnHit(Entity atkEntity, float Damage = 0)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected override void Start()
    {
        player = Player.Instance;
        attackCollisions = GetComponentsInChildren<AttackCollision>();
        sprite = GetComponent<SpriteRenderer>();
        base.Start();
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, -player.transform.position.y);
        sprite.sprite = player.sprite.sprite;
        sprite.flipX = player.sprite.flipX;
    }
    public void OnAttack(PlayerWeaponType weaponType, int index)
    {
        foreach (AttackCollision attackCollision in attackCollisions)
        {
            if (attackCollision.index == index && attackCollision.weaponType == weaponType)
            {
                attackCollision.OnAttack(this);
            }
        }
    }
}
