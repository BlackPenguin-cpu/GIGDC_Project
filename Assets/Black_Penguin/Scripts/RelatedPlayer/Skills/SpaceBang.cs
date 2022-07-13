using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBang : BaseSkill
{
    private BoxCollider2D boxCollider2D;
    private List<BaseEnemy> baseEnemies;
    protected override void Action()
    {
        SoundManager.instance.PlaySoundClip("SFX_Skill_Expansion", SoundType.SFX);
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
        boxCollider2D = GetComponent<BoxCollider2D>();
        baseEnemies = new List<BaseEnemy>();

        player = Player.Instance;
        sprite.flipY = dimensionType == DimensionType.UNDER;

        sprite.color = Color.white;
        transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        if (dimensionType == DimensionType.UNDER)
            boxCollider2D.offset = new Vector2(0, -2);
        else
            boxCollider2D.offset = new Vector2(0, 2);

        Action();
    }
    private void Update()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset * (int)dimensionType, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && !baseEnemies.Contains(enemy))
            {
                baseEnemies.Add(enemy);
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector3(transform.position.x < enemy.transform.position.x ? 10 : -10, 0), ForceMode2D.Impulse);
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
    }
}
