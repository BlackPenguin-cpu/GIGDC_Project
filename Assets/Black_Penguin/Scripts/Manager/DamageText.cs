using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageText : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private TextMesh textMesh;

    private string textString;
    [SerializeField] private float duration;

    public bool isCrit;
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
        OnEnable();
    }
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        textMesh = GetComponent<TextMesh>();

        textString = ((int)damageValue).ToString();

        textMesh.text = textString;
        duration = 0.5f;
        rigid.AddForce(new Vector3(Random.Range(-30, 30), 100, 0));


        if (isCrit)
        {
            textMesh.color = new Color(1, 0, 0, 0.8f);
            textMesh.fontStyle = FontStyle.Bold;
        }
        else
        {
            textMesh.color = new Color(1, 1, 1, 0.8f);
        }
    }

}