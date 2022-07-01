using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGodLight : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    protected override void Action()
    {
        CameraManager.Instance.ScreenFade(0.2f, 0.3f);
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && enemy.dimensionType == dimensionType)
            {
                player.Attack(enemy, DefaultReturnDamage());
                enemy.buffList.stun = 1.5f;
            }
        }
    }
    void AnimEnd()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        animator.Play("SolarGodLight");
    }

}
