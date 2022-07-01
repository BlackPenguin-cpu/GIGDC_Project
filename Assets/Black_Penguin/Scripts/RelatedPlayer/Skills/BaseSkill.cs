using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType = DimensionType.NONE;
    public SkillScript SkillInfo;
    public float StartPosY;

    protected SpriteRenderer sprite;
    protected Player player;
    public virtual void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = Player.Instance;
        dimensionType = DimensionType.NONE;
        if (dimensionType == DimensionType.NONE)
        {
            if (transform.position.y > 0)
            {
                dimensionType = DimensionType.OVER;
            }
            else if (transform.position.y < 0)
            {
                dimensionType = DimensionType.UNDER;
            }
        }

        sprite.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
    }
    public float DefaultReturnDamage()
    {
        return SkillInfo.damagePercent / 100 * player.stat._attackDamage;
    }
    protected abstract void Action();
}
