using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bar : MonoBehaviour
{
    public static HP_Bar Inst { get; private set; }
    void Awake() => Inst = this;

    public float HP;
    public GameObject Bar;

    void Start()
    {
    }

    void Update()
    {
        HP = Player.Instance.stat._hp;
        Test();
    }

    public void Test()
    {
        if (Bar.transform.localScale.y >= 0.001)
        {
            Bar.transform.localScale = new Vector3(100, HP, 1);
        }
    }
}
