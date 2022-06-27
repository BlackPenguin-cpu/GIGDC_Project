using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType = DimensionType.NONE;
    public SkillScript SkillInfo;
    SpriteRenderer SpriteRenderer;

    public virtual void OnObjCreate()
    {
        if (dimensionType == DimensionType.NONE)
            dimensionType = transform.position.y > 0 ? DimensionType.OVER : DimensionType.UNDER;

           SpriteRenderer.material = (dimensionType == DimensionType.OVER ? GameManager.Instance.OverMaterial : GameManager.Instance.UnderMaterial);
    }

    protected abstract void Action();
}
