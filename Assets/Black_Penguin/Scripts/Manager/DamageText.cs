using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageText : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private TextMeshProUGUI tmpro;

    private string textString;
    private float duration = 2;

    public bool isCrit;
    public float damageValue;
    public Vector3 pos;
    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();

        textString = ((int)damageValue).ToString();
        transform.position = Camera.main.WorldToScreenPoint(pos);

        if (isCrit)
        {
            tmpro.color = Color.red;
        }
        else
        {
            tmpro.color = Color.white;
        }
        tmpro.text = textString;
        duration = 2;
        rigid.AddForce(new Vector3(0, 10, 0));
    }

}