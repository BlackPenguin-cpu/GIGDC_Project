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
        HP_Control();
    }

    public void HP_Control()
    {
        if (HP >= 0 && HP <= 100)
            Bar.transform.localScale = new Vector3(100, HP, 1);

    }
}
