using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodOfGockgangE : BaseSkill
{
    private float duration = 1;
    protected override void Action()
    {
        BaseEnemy[] enemies = FindObjectsOfType<BaseEnemy>();
        BaseEnemy target = null;
        float maxDistance = 0;

        SoundManager.instance.PlaySoundClip("SFX_Skill_Pick", SoundType.SFX);


        foreach (BaseEnemy enemy in enemies)
        {
            float distance = Vector2.Distance(player.transform.position, enemy.transform.position);
            if (maxDistance < distance && enemy.dimensionType == dimensionType)
            {
                target = enemy;
                maxDistance = distance;
            }
        }

        if (target != null)
        {
            transform.position = target.transform.position + Vector3.up;
            player.Attack(target, DefaultReturnDamage());
            GameManager.Instance._coin += (int)DefaultReturnDamage();
        }

    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();

        duration = 1;
        sprite.flipX = player.sprite.flipX;

        Action();
    }

    private void Update()
    {
        sprite.color = new Color(1, 1, 1, duration);
        duration -= Time.deltaTime;

        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
}
