using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foundation : MonoBehaviour
{
    [Header("����")]
    public GameObject Magic_Circle; // ������
    public float Speed;

    void Start()
    {

    }

    void Update()
    {
        MagicCircle_Rotation();
    }

    public void MagicCircle_Rotation()
    {
        Magic_Circle.transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
}
