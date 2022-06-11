using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class DropObject : MonoBehaviour
{
    [SerializeField] float duration = 2;
    [SerializeField] Rigidbody2D rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        rigid.AddTorque(Random.Range(-100, 100));
        rigid.AddForce(new Vector2(Random.Range(-15, 15), Random.Range(10, 15)));
    }
    void Update()
    {
        if (duration <= 0)
            Destroy(gameObject);
        duration -= Time.deltaTime;
    }
    private void OnDestroy()
    {
        //여기에 파티클 넣어야해...
    }
}
