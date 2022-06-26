using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Window : MonoBehaviour, IPointerEnterHandler
{
    public int Item_Log;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Stop_Manager.Inst.Player_Item_Name.text = Stop_Manager.Inst.ItemDA_Have[Item_Log].Itme_Name;
        Stop_Manager.Inst.Player_Item_Icon.sprite = Stop_Manager.Inst.ItemDA_Have[Item_Log].Item_Icon;
        Stop_Manager.Inst.Player_Item_Explanation.text = Stop_Manager.Inst.ItemDA_Have[Item_Log].Item_Explanation;
    }
}
