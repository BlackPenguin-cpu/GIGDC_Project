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
                    Foundation.Inst.Title.text = "������ �ʴ� ��";
                    Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� 10 / " + "<color=#877D78>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " �����Ѵ�.";
                    break;
                case 1:
                    Foundation.Inst.Title.text = "������ �ʴ� ��";
                    Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� 10 / " + "<color=#FF0000>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " �����Ѵ�.";
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
                    Foundation.Inst.Title.text = "������ �ʴ� ��";
                    Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� 10 / " + "<color=#FF0000>" + "20" + "</color>" + " / " + "<color=#877D78>" + "30" + "</color>" + " / " + "<color=#877D78>" + "40" + "</color>" + " / " + " �����Ѵ�.";
                    break;
            }
        }
    }

}
