using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        collider2D = GetComponent<BoxCollider2D>(); ;
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// 몬스터 공격인지 플레이어 공격인지 구분하기위해 자기자신을 넣어야한다
    /// </summary>
    /// <param name="player"></param>
    public void OnAttack(Player player)
    {
        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(transform.parent.position, collider2D.size, 0, parentSpriteRenderer.flipX ? Vector2.left : Vector2.right);
        foreach (RaycastHit2D raycast in raycastHits)
        {
            if (raycast.collider.TryGetComponent(out BaseEnemy enemy)
                && Mathf.Abs(player.transform.position.x - enemy.transform.position.x) < (collider2D.offset.x + collider2D.size.x / 2))
            {
                player.Attack(enemy, Player.Instance.stat._attackDamage);
            }
        }
    }
    public void OnAttack(BaseEnemy enemy)
    {
        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(transform.parent.position, collider2D.size, 0, parentSpriteRenderer.flipX ? Vector2.left : Vector2.right);
        foreach (RaycastHit2D raycast in raycastHits)
        {
            if (raycast.collider.TryGetComponent(out Player player)
                && Mathf.Abs(enemy.transform.position.x - player.transform.position.x) < (collider2D.offset.x + collider2D.size.x / 2))
            {
                enemy.Attack(player, enemy.attackDamage);
            }
        }
    }
    public bool isCanAttack(Entity entity)
    {
        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(transform.parent.position, collider2D.size, 0, parentSpriteRenderer.flipX ? Vector2.left : Vector2.right);
        if (entity.GetComponent<BaseEnemy>())
        {
            foreach (RaycastHit2D raycast in raycastHits)
            {
                if (raycast.collider.TryGetComponent(out Player player)
                    && Mathf.Abs(entity.transform.position.x - player.transform.position.x) < (collider2D.offset.x + collider2D.size.x / 2))
                {
                    return true;
                }
            }
        }
        else if (entity.GetComponent<Player>())
        {
            foreach (RaycastHit2D raycast in raycastHits)
            {
                if (raycast.collider.TryGetComponent(out BaseEnemy enemy)
                    && Mathf.Abs(Player.Instance.transform.position.x - enemy.transform.position.x) < (collider2D.offset.x + collider2D.size.x / 2))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
