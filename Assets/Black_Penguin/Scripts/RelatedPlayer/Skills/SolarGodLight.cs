using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGodLight : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    protected override void Action()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);
        SoundManager.instance.PlaySoundClip("SFX_Blunt", SoundType.SFX);


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
        CameraManager.Instance.ScreenFade(1.5f, 0.5f);
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        animator.Play("SolarGodLight");
    }

}
