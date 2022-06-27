using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonginusSpear : BaseSkill, IObjectPoolingObj
{
    [SerializeField] GameObject spear;

    private Player player;
    private float duration = 3;

    public void OnObjCreate()
    {
        duration = 3;
        player = Player.Instance;
        Action();
    }

    protected override void Action()
    {
        AttackProjectile projectile = ObjectPool.Instance.CreateObj(spear).GetComponent<AttackProjectile>();
        projectile.Init(player, SkillInfo.damagePercent / 100 * player.stat._attackDamage,20,0,ProjectileType.Basic);
    }
    private void Update()
    {
        duration = Time.deltaTime;
        if (duration < 0) ObjectPool.Instance.DeleteObj(gameObject);
    }

}
