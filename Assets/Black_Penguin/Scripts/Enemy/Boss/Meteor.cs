using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour, IObjectPoolingObj
{
    public BaseEnemy ShadowMageComponenet;
    [SerializeField] private GameObject ExplosionEffect;
    private Rigidbody2D rigid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            //20�� ���������� ���׿� ���ݷ�
            ShadowMageComponenet.Attack(Player.Instance, 20);
        }
        if (collision.CompareTag("Platform"))
        {
            ObjectPool.Instance.CreateObj(ExplosionEffect, new Vector3(transform.position.x, 0), Quaternion.identity);
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }

    public void OnObjCreate()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (transform.position.y < 0)
        {
            rigid.gravityScale = -rigid.gravityScale;
        }
    }
}
