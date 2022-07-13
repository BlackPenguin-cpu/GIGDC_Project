using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType = DimensionType.OVER;
    public SkillScript SkillInfo;
    public float StartPosY;

    public SpriteRenderer sprite;
    protected Player player;
    public virtual void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = Player.Instance;

        sprite.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
        sprite.flipY = dimensionType == DimensionType.UNDER;
    }
    public void Init()
    {
        if (!gameObject.GetComponent<SoulFarming>())
            sprite.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
        sprite.flipY = dimensionType == DimensionType.UNDER;
    }
    public float DefaultReturnDamage()
    {
        return SkillInfo.damagePercent / 100 * player.stat._attackDamage;
    }
    protected abstract void Action();
}
