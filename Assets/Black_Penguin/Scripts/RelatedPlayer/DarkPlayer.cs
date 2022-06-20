using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPlayer : MonoBehaviour
{
    public static DarkPlayer instance;
    SpriteRenderer sprite;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.position = new Vector3(Player.Instance.transform.position.x, -Player.Instance.transform.position.y);
        sprite.sprite = Player.Instance.sprite.sprite;
        sprite.flipX = Player.Instance.sprite.flipX;
    }
}
