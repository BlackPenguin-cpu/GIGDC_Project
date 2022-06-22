using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Among_Mouse : SingletonMono<Among_Mouse>, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float timer = 0f;

    [Header("��� ��")]
    public bool Among_Pick = true;
    public Image Among_Light;

    [Header("������ â")]
    public GameObject Among_Window;

    [Header("������ �� / ���")]
    public GameObject Left_Pole_01;
    public GameObject Left_Pole_02;
    public RectTransform Left_Rect;

    public GameObject Right_Pole_01;
    public GameObject Right_Pole_02;
    public RectTransform Right_Rect;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Left_Mouse.In.Left_Pick == true && Right_Mouse.In.Right_Pick == true)
        {
            Among_Light.DOFade(1f, 0.5f);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Among_Light.DOFade(0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Among_Pick == true)
        {
            Among_Pick = false;
            Left_Mouse.In.Left_Pick = false;
            Right_Mouse.In.Right_Pick = false;

            if (Card_Manager.Inst.DA_Among == false)
            {
                for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                {
                    if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.DA_AmongCheck[0].Itme_Name)
                    {
                        Card_Manager.Inst.DABuffer.RemoveAt(i);
                    }
                }
            }

            Among_Light.DOFade(1f, 0.1f);
            Among_Window.transform.DOLocalMoveY(1150, 0.5f).SetEase(Ease.InQuad);
            StartCoroutine(Close_Dot());
        }
    }

    public IEnumerator Close_Dot()
    {
        Left_Pole_01.transform.DOLocalMoveY(50f, 0.5f);
        Left_Pole_02.transform.DOLocalMoveY(-26f, 0.5f);

        Right_Pole_01.transform.DOLocalMoveY(-32f, 0.5f);
        Right_Pole_02.transform.DOLocalMoveY(-108f, 0.5f);

        while (timer < 1)
        {
            Left_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, 0, timer));
            Right_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        Destroy(GameObject.Find("Item_Window(Clone)"));
    }
}
