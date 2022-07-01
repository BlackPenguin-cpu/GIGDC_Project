using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EletricField : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    private float attackSpeed = 1;
    private float duration = 10;
    protected override void Action()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && enemy.dimensionType == dimensionType)
            {
                player.Attack(enemy, 0.3f * player.stat._attackDamage);
            }
        }
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        boxCollider2D = GetComponent<BoxCollider2D>();
        attackSpeed = 1;
        duration = 10;
    }
    private void Update()
    {
        duration -= Time.deltaTime;
        attackSpeed -= Time.deltaTime;
        if (attackSpeed < 0)
        {
            Action();
            attackSpeed = 1;
        }
        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
}
