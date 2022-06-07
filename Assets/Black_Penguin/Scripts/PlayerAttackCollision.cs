using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    public PlayerWeaponType weaponType;
    public SpriteRenderer spriteRenderer => transform.parent.GetComponent<SpriteRenderer>();
    public int index;
    BoxCollider2D collider2D => GetComponent<BoxCollider2D>();
    public void OnAttack()
    {
        RaycastHit2D[] raycastHits = Physics2D.BoxCastAll(transform.parent.position + (Vector3)collider2D.offset, collider2D.size, 0, spriteRenderer.flipX ? Vector2.left : Vector2.right);
        foreach (RaycastHit2D raycast in raycastHits)
        {
            if (raycast.collider.TryGetComponent(out BaseEnemy enemy) && raycast.distance < collider2D.size.x / 2 - collider2D.offset.x)
            {
                Debug.Log(enemy);
                Player.Instance.Attack(enemy, Player.Instance.stat._attackDamage);
            }
        }
    }
}
