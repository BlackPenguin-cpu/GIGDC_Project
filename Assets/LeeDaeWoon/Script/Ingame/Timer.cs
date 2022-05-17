using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float Sec;
    int Min;

    public Text Timer_Text;

    void Start()
    {

    }

    void Update()
    {
        Timer_System();
    }

    public void Timer_System()
    {
        Sec += Time.deltaTime;
        Timer_Text.text = string.Format("{0:D2}:{1:D2}", Min, (int)Sec);

        if ((int)Sec > 59)
        {
            Sec = 0;
            Min++;
        }
    }
}
