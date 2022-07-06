using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoom : MonoBehaviour, IObjectPoolingObj
{
    private BoxCollider2D boxCollider2D;
    public ShadowMage shadowMage;
    public void OnObjCreate()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, boxCollider2D.size, 0, Vector2.right, 0);
        foreach (RaycastHit2D ray in rays)
        {
            if (ray.collider.GetComponent<ITypePlayer>() != null)
            {
                shadowMage.Attack(Player.Instance, 15);
            }
        }
    }
    void DeleteThis()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }
}
