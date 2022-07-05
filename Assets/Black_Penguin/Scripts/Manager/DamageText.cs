using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageText : MonoBehaviour, IObjectPoolingObj
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private TextMesh textMesh;

    private string textString;
    [SerializeField] private float duration;

    public bool isCrit;
    public DimensionType dimensionType;
    public float damageValue;
    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
    private void Start()
    {
        OnObjCreate();
    }
    public void Init()
    {
        textString = ((int)damageValue).ToString();

        textMesh.text = textString;
        duration = 0.5f;

        if (isCrit)
        {
            textMesh.color = new Color(1, 1, 0, 0.8f);
            textMesh.fontStyle = FontStyle.Bold;
        }
        else
        {
            textMesh.color = new Color(1, 0, 0, 0.8f);
        }

        if (dimensionType == DimensionType.OVER)
        {
            rigid.AddForce(new Vector3(Random.Range(-30, 30), 100, 0));
        }
        else
        {
            rigid.AddForce(new Vector3(Random.Range(-30, 30), -100, 0));
        }

    }
    public void OnObjCreate()
    {
        rigid = GetComponent<Rigidbody2D>();
        textMesh = GetComponent<TextMesh>();
    }
}