using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonginusSpear : BaseSkill, IObjectPoolingObj
{
    [SerializeField] GameObject spear;

    private float duration = 1;

    public override void OnObjCreate()
    {
        base.OnObjCreate();
        duration = 1;

        sprite.flipX = player.sprite.flipX;
        Action();
    }

    protected override void Action()
    {
        AttackProjectile projectile = ObjectPool.Instance.CreateObj(spear, transform.position, Quaternion.Euler(0, 0, player.sprite.flipX ? 180 : 0)).GetComponent<AttackProjectile>();
        projectile.Init(player, DefaultReturnDamage(), 30, 0, ProjectileType.Basic);
        projectile.canPierce = true;

        SoundManager.instance.PlaySoundClip("SFX_Skill_longginus", SoundType.SFX);
    }
    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration > 0)
        {
            sprite.color = new Color(1, 1, 1, duration);
        }
        else
            ObjectPool.Instance.DeleteObj(gameObject);
    }

}
