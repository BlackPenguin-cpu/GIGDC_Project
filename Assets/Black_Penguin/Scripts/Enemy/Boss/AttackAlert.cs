using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAlert : MonoBehaviour, IObjectPoolingObj
{
    [SerializeField] private GameObject createObj;
    [SerializeField] private Vector3 createObjPos;
    public DimensionType dimensionType;
    private SpriteRenderer sprite;
    public void OnObjCreate()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(StartAlert());
    }
    IEnumerator StartAlert()
    {
        //����ũ�� ���� 0.4���� �۰�
        float value = transform.localScale.x * 0.6f;
        //����ũ�⺸�� 0.1�� ũ�� 
        float targetValue = transform.localScale.x + 0.1f;
        while (value < targetValue)
        {
            transform.localScale = new Vector2(value, value);
            sprite.color = new Color(1, 1, 1, value - 0.2f);
            value += Time.deltaTime;
            yield return null;
        }
        ObjectPool.Instance.CreateObj(createObj, transform.position + createObjPos * (dimensionType == DimensionType.OVER ? 1 : -1), transform.rotation);
        ObjectPool.Instance.DeleteObj(gameObject);
    }
}
