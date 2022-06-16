using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{
    public float HP;
    public GameObject Bar;

    void Start()
    {
        HP = Player.Instance._hp;

    }

    void Update()
    {
    }

    public void Test()
    {
        //if (Bar.transform.localScale.y >= 0.001)
        //{
        //    Bar.transform.localScale += new Vector3(0, -0.01f, 0);
        //}


    }
}
