using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{
    public GameObject Bar;

    void Start()
    {
        InvokeRepeating("Test", 0.5f, 0.5f);
    }

    void Update()
    {

    }

    public void Test()
    {
        //Debug.Log("0.5 °¨¼Ò");
        if (Bar.transform.localScale.y >= 0.001)
        {
            Bar.transform.localScale += new Vector3(0, -0.01f, 0);
        }

    }
}
