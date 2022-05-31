using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedKnife : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float damage;
    public float rotatePower;

    void Update()
    {
        Vector2 dir = Vector3.Normalize(target.transform.position - transform.position);
        transform.Rotate(dir * Time.deltaTime * rotatePower);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseEnemy enemy))
        {
            enemy._Hp -= damage;
            Destroy(gameObject);
        }
    }
}
