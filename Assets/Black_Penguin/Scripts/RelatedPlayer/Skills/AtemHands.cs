using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtemHands : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    private float attackSpeed = 1;
    private float duration;
    protected override void Action()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy))
            {
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();

        boxCollider2D = GetComponent<BoxCollider2D>();
        duration = 10;
        attackSpeed = 1;
    }
    private void Update()
    {
        duration -= Time.deltaTime;
        sprite.color = new Color(1, 1, 1, duration);

        if (duration <= 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }

        attackSpeed -= Time.deltaTime;
        if (attackSpeed <= 0)
        {
            attackSpeed = 1;
            Action();
        }
    }
}
