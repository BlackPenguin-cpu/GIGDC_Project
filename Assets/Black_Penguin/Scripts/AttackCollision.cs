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
    [Header("플레이어 공격 관련")]
    public PlayerWeaponType weaponType;
    [Header("콜라이더 넘버")]
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
    /// 몬스터 공격인지 플레이어 공격인지 구분하기위해 자기자신을 넣어야한다
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
    /// Enemy만 호출
    /// </summary>
    public bool isCanAttack(Entity entity)
    {
        foreach (RaycastHit2D raycast in DetectEntity())
        {
            //공격범위에 플레이어가 있고 차원이 같을경우
            if (raycast.collider.gameObject.GetComponent<ITypePlayer>() != null && raycast.collider.GetComponent<Entity>().dimensionType == entity.dimensionType)
            {
                return true;
            }
        }
        return false;
    }
}
