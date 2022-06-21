using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerSkillObj : MonoBehaviour
{
    public float damage;
    [SerializeField] float speed = 20;
    float duration = 3;
    SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    void Update()
    {
        transform.position += speed * Time.deltaTime * (sprite.flipX ? Vector3.left : Vector3.right);
        transform.Rotate(new Vector3(0, 0, 720 * Time.deltaTime));
        //나중에 오브젝트 풀링 만들면 좋을듯
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        duration -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out BaseEnemy enemy))
        {
            enemy._hp -= damage;
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
}
