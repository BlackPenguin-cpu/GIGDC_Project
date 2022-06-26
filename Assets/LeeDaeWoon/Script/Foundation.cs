using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foundation : MonoBehaviour
{
    [Header("제단")]
    public GameObject Magic_Circle; // 마법진
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
