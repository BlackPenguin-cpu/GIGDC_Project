using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanyMagic : BaseSkill
{
    BoxCollider2D boxCollider2D;
    private float duration;
    protected override void Action()
    {
        float Jini_volume = 0.05f;

        Debug.Log(dimensionType);
        RaycastHit2D[] rays = Physics2D.BoxCastAll
            ((Vector2)transform.position + new Vector2(boxCollider2D.offset.x * (sprite.flipX ? -1 : 1)
            , dimensionType == DimensionType.OVER ? boxCollider2D.offset.y : -boxCollider2D.offset.y)
            , boxCollider2D.size, 0, Vector2.right, 0);

        SoundManager.instance.PlaySoundClip("SFX_Skill_Jini", SoundType.SFX, Jini_volume);


        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy))
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
        CameraManager.Instance.CameraShake(0.3f, 0.3f, 0.05f);
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();

        duration = 1;
        sprite.flipX = player.sprite.flipX;
        boxCollider2D = GetComponent<BoxCollider2D>();
        Invoke("Action",0.01f);
    }
    private void Update()
    {
        duration -= Time.deltaTime;
        sprite.color = new Color(1, 1, 1, duration);
        if (duration < 0) ObjectPool.Instance.DeleteObj(gameObject);
    }
}
