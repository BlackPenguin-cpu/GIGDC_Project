using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPlayer : MonoBehaviour
{
    SpriteRenderer sprite;
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
