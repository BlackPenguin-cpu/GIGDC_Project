using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class AttackCollision : MonoBehaviour
{
    private SpriteRenderer parentSpriteRenderer;
    private new BoxCollider2D collider2D;
    [Header("�÷��̾� ���� ����")]
    public PlayerWeaponType weaponType;
    [Header("�ݶ��̴� �ѹ�")]
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
    /// ���� �������� �÷��̾� �������� �����ϱ����� �ڱ��ڽ��� �־���Ѵ�
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
    /// Enemy�� ȣ��
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
