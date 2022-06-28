using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCyclone : BaseSkill
{
    private float duration = 5;
    private List<BaseEnemy> baseEnemies;
    private BoxCollider2D boxCollider2D;
    private int value;
    protected override void Action()
    {

    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        sprite.flipX = player.sprite.flipX;

        boxCollider2D = GetComponent<BoxCollider2D>();
        baseEnemies = new List<BaseEnemy>();
        duration = 5;
        value = 4;
    }
    private void Update()
    {
        transform.Translate(sprite.flipX ? Vector2.left : Vector2.right * 3 * Time.deltaTime);
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
        else if (duration < 1)
        {
            sprite.color = new Color(1, 1, 1, duration);
        }

        if (duration < value)
        {
            value--;
            baseEnemies = new List<BaseEnemy>();
        }

        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && !baseEnemies.Contains(enemy))
            {
                baseEnemies.Add(enemy);
                enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
    }
}
