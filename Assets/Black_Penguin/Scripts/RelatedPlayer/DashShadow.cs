using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashShadow : MonoBehaviour , IObjectPoolingObj
{
    private SpriteRenderer sprite;
    [HideInInspector]
    public System.Action onDisappear;
    private void Start()
    {
        onDisappear += () => ObjectPool.Instance.DeleteObj(gameObject);
    }
    IEnumerator DoFade()
    {
        Color minusColor = new Color(0, 0, 0.1f);
        while (sprite.color.a > 0)
        {
            sprite.color -= minusColor * Time.deltaTime;
            yield return null;
        }
        onDisappear.Invoke();
    }
    public void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
        sprite.sprite = Player.Instance.sprite.sprite;
        sprite.flipX = Player.Instance.sprite.flipX;
        StartCoroutine(DoFade());
    }
}
