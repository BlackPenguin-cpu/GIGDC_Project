using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    private SpriteRenderer parentSpriteRenderer;
    private new BoxCollider2D collider2D;
    public PlayerWeaponType weaponType;
    public int index;
    Player player;

    private void Start()
    {
        player = Player.Instance;
        collider2D = GetComponent<BoxCollider2D>(); ;
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }
    public void OnAttack()
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
}
