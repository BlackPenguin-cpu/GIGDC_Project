using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IObjectPoolingObj
{
    [SerializeField] private GameObject ExplosionEffect;
    private BoxCollider2D boxCollider;
    public BaseEnemy ShadowMageComponenet;
    public void OnObjCreate()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, boxCollider.size, 0, Vector2.zero);

        foreach (RaycastHit2D ray in rays)
        {
            if (ray.collider.GetComponent<ITypePlayer>() != null)
            {
                //20은 검은사제의 메테오 공격력
                ShadowMageComponenet.Attack(Player.Instance, 20);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            ObjectPool.Instance.CreateObj(ExplosionEffect, transform.position, Quaternion.identity);
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
}
