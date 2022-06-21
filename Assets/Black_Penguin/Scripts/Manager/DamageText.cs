using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class DamageText : MonoBehaviour
{
    Rigidbody2D rigid;
    TextMeshProUGUI tmpro;

    string textString;
    bool isCrit;
    DamageText(string text, bool isCrit)
    {
        this.textString = text;
        this.isCrit = isCrit;
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rigid.AddForce(new Vector3(0, 10, 0));
    }

}