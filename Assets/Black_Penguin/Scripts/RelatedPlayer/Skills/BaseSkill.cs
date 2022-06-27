using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType = DimensionType.NONE;
    public SkillScript SkillInfo;
    protected SpriteRenderer sprite;

    public virtual void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        dimensionType = DimensionType.NONE;
        if (dimensionType == DimensionType.NONE)
            dimensionType = (transform.position.y > 0 ? DimensionType.OVER : DimensionType.UNDER);

        sprite.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
    }

    protected abstract void Action();
}
