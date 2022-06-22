using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Left_Mouse : SingletonMono<Left_Mouse>, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float timer = 0f;

    [Header("øﬁ¬  ∫˚")]
    public bool Left_Pick = true;
    public Image Left_Light;

    [Header("æ∆¿Ã≈€ √¢")]
    public GameObject Left_Window;
    public RectTransform Among_Window;
    public RectTransform Right_Window;

    [Header("æ∆¿Ã≈€ ∫¿ / πË∞Ê")]
    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_Rect;

    public GameObject Right_Pole_01;
    public GameObject Right_Pole_02;
    public RectTransform Right_Rect;

    private bool Window_Check = true;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Among_Mouse.In.Among_Pick == true && Right_Mouse.In.Right_Pick == true)
        {
            Left_Light.DOFade(1f, 0.5f);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Left_Light.DOFade(0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Left_Pick == true)
        {
            Left_Pick = false;
            Among_Mouse.In.Among_Pick = false;
            Right_Mouse.In.Right_Pick = false;

            if (Card_Manager.Inst.DA_Left == false)
            {
                for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                {
                    if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.DA_LeftCheck[0].Itme_Name)
                    {
                        Card_Manager.Inst.DABuffer.RemoveAt(i);
                    }
                }
            }

            Left_Light.DOFade(1f, 0.1f);
            Left_Window.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.InQuad);
            StartCoroutine(Close_Dot());
        }

    }

    public IEnumerator Close_Dot()
    {
        Among_Pole_01.transform.DOLocalMoveY(-53f, 0.5f);
        Among_Pole_02.transform.DOLocalMoveY(-125f, 0.5f);

        Right_Pole_01.transform.DOLocalMoveY(-32f, 0.5f);
        Right_Pole_02.transform.DOLocalMoveY(-108f, 0.5f);

        while (timer < 1)
        {
            Among_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, 0, timer));
            Right_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        Destroy(GameObject.Find("Item_Window(Clone)"));
    }
}
