using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBang : BaseSkill
{
    private Player player;
    private BoxCollider2D collider2D;
    private float duration;

    protected override void Action()
    {
        StartCoroutine(OnStart());
    }
    IEnumerator OnStart()
    {
        float value = 1;
        while (value < 1.5f)
        {
            transform.localScale = new Vector3(value, value, 1);
            value += Time.deltaTime * 5;
            yield return null;
        }
        value = 1;
        while (value > 0)
        {
            sprite.color = new Color(1, 1, 1, value);
            value -= Time.deltaTime;
            yield return null;
        }
        ObjectPool.Instance.DeleteObj(gameObject);
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        collider2D = GetComponent<BoxCollider2D>();

        player = Player.Instance;
        sprite.flipY = dimensionType == DimensionType.UNDER;

        sprite.color = Color.white;
        transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        if (dimensionType == DimensionType.UNDER)
            collider2D.offset = new Vector2(0, -2);

        Action();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseEnemy baseEnemy))
        {
            baseEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector3(transform.position.x < baseEnemy.transform.position.x ? 10 : -10, 0), ForceMode2D.Impulse);
            player.Attack(baseEnemy, (SkillInfo.damagePercent / 100) * player.stat._attackDamage);
        }
    }
}
