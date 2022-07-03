using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType = DimensionType.NONE;
    public SkillScript SkillInfo;
    public float StartPosY;

    public SpriteRenderer sprite;
    protected Player player;
    public virtual void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = Player.Instance;

    }
    public void Init()
    {
        sprite.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
        sprite.flipY = dimensionType == DimensionType.UNDER;
    }
    public float DefaultReturnDamage()
    {
        return SkillInfo.damagePercent / 100 * player.stat._attackDamage;
    }
    protected abstract void Action();
}
