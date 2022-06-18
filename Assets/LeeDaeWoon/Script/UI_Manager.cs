using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    public Text Gold_Text;
    public float Gold;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Gold += 1000;
        }

        Gold_Text.text = "" + Gold;
    }
}
