using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AttackCollision : MonoBehaviour
{
    private SpriteRenderer parentSpriteRenderer;
    private new BoxCollider2D collider2D;
    [Header("플레이어 공격 관련")]
    public PlayerWeaponType weaponType;
    [Header("콜라이더 넘버")]
    public int index;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    RaycastHit2D[] DetectEntity()
    {
        return Physics2D.BoxCastAll(transform.parent.position, collider2D.size, 0, parentSpriteRenderer.flipX ? Vector2.left : Vector2.right
            , /*Mathf.Abs(entity.transform.position.x - enemy.transform.position.x) < */ collider2D.size.x / 2);
    }
    /// <summary>
    /// 몬스터 공격인지 플레이어 공격인지 구분하기위해 자기자신을 넣어야한다
    /// </summary>
    /// <param name="player"></param>
    public void OnAttack(Entity entity)
    {
        foreach (RaycastHit2D raycast in DetectEntity())
        {
            if (entity is Player)
            {
                if (raycast.collider.TryGetComponent(out BaseEnemy enemy))
                {
                    entity.Attack(enemy, Player.Instance.stat._attackDamage);
                }
            }
            else if (entity is BaseEnemy)
            {
                if (raycast.collider.TryGetComponent(out Player player))
                {
                    entity.Attack(player, entity.GetComponent<BaseEnemy>().attackDamage);
                }
            }
        }
    }

    /// <summary>
    /// Enemy만 호출
    /// </summary>
    public bool isCanAttack(Entity entity)
    {
        foreach (RaycastHit2D raycast in DetectEntity())
        {
            if (raycast.collider.TryGetComponent(out Player player))
            {
                return true;
            }
        }
        return false;
    }
}
