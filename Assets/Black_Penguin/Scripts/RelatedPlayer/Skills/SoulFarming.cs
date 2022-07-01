using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFarming : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    protected override void Action()
    {
        StartCoroutine(OnAttack());
    }
    IEnumerator OnAttack()
    {
        yield return null;

    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

}
