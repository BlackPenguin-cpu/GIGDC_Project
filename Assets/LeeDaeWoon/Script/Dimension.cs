using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour
{
    [Header("¸¶¹ýÁø")]
    public GameObject Magic_Circle;
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
