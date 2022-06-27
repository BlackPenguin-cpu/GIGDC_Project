using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BoxCollider2D))]
public class AttackCollision : MonoBehaviour
{
    private SpriteRenderer parentSpriteRenderer;
    private new BoxCollider2D collider2D;
    private Player player;
    private DarkPlayer darkPlayer;
    [Header("�÷��̾� ���� ����")]
    public PlayerWeaponType weaponType;
    [Header("�ݶ��̴� �ѹ�")]
    public int index;

    private void Start()
    {
        player = Player.Instance;
        darkPlayer = DarkPlayer.Instance;
        collider2D = GetComponent<BoxCollider2D>();
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }

    RaycastHit2D[] DetectEntity()
    {
        return Physics2D.BoxCastAll(transform.parent.position + new Vector3((parentSpriteRenderer.flipX ? -1 : 1) * collider2D.offset.x, collider2D.offset.y), collider2D.size, 0, parentSpriteRenderer.flipX ? Vector2.left : Vector2.right, 0); ;
    }
    /// <summary>
    /// ���� �������� �÷��̾� �������� �����ϱ����� �ڱ��ڽ��� �־���Ѵ�
    /// </summary>
    /// <param name="player"></param>
    public void OnAttack(Entity entity)
    {
        foreach (RaycastHit2D raycast in DetectEntity())
        {
            if (entity.GetComponent<ITypePlayer>() != null)
            {
                if (raycast.collider.TryGetComponent(out BaseEnemy enemy) && raycast.collider.GetComponent<Entity>().dimensionType == entity.dimensionType)
                {
                    player.Attack(enemy, player.stat._attackDamage);
                }
            }
            else if (entity is BaseEnemy)
            {
                if (raycast.collider.gameObject.GetComponent<ITypePlayer>() != null && raycast.collider.GetComponent<Entity>().dimensionType == entity.dimensionType)
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
            //���ݹ����� �÷��̾ �ְ� ������ �������
            if (raycast.collider.gameObject.GetComponent<ITypePlayer>() != null && raycast.collider.GetComponent<Entity>().dimensionType == entity.dimensionType)
            {
                return true;
            }
        }
        return false;
    }
}
