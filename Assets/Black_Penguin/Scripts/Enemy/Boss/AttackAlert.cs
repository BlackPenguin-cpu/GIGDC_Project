using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAlert : MonoBehaviour, IObjectPoolingObj
{
    public DimensionType dimensionType;
    [SerializeField] private GameObject createObj;
    [SerializeField] private Vector3 createObjPos;
    private SpriteRenderer sprite;
    [SerializeField] private Vector2 startScale;
    public void OnObjCreate()
    {
        if (startScale.x != 0)
            startScale = transform.localScale;
        else
            transform.localScale = startScale;
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(StartAlert());
    }
    IEnumerator StartAlert()
    {
        //����ũ�� ���� 0.4���� �۰�
        float value = transform.localScale.x * 0.6f;
        //����ũ�⺸�� 0.1�� ũ�� 
        float targetValue = transform.localScale.x;
        while (value < targetValue)
        {
            transform.localScale = new Vector2(value, value);
            sprite.color = new Color(1, 1, 1, value - 0.2f);
            value += Time.deltaTime;
            yield return null;
        }
        ObjectPool.Instance.CreateObj(createObj, transform.position + createObjPos * (dimensionType == DimensionType.OVER ? 1 : -1), Quaternion.Euler(0, 0, sprite.flipY ? 180 : 0));
        ObjectPool.Instance.DeleteObj(gameObject);
    }
}
