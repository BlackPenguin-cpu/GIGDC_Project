using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Malyeog_Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum Malyeog
    {
        Magic,
        Body
    }
    public int Malyeog_Num;
    [SerializeField] Malyeog malyeog;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Malyeog_Num++;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (malyeog == Malyeog.Magic)
        {
            switch (Malyeog_Num)
            {
                case 0:
                    Foundation.Inst.Title.text = "보이지 않는 손";
                    Foundation.Inst.Explanation.text = "보이지 않는 손들이 함께 공격해 공격 속도가 10 / " + "<color=#877D78>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " 증가한다.";
                    break;
                case 1:
                    Foundation.Inst.Title.text = "보이지 않는 손";
                    Foundation.Inst.Explanation.text = "보이지 않는 손들이 함께 공격해 공격 속도가 10 / " + "<color=#FF0000>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " 증가한다.";
                    break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (malyeog == Malyeog.Magic)
        {
            switch (Malyeog_Num)
            {
                case 0:
                    Foundation.Inst.Title.text = "보이지 않는 손";
                    Foundation.Inst.Explanation.text = "보이지 않는 손들이 함께 공격해 공격 속도가 10 / " + "<color=#FF0000>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " 증가한다.";
                    break;
            }
        }
    }

}
