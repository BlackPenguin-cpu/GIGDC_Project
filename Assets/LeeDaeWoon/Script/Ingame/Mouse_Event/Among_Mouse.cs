using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Among_Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public static Among_Mouse Inst { get; private set; }
    void Awake() => Inst = this;

    private float timer = 0f;
    public int AmongClick_Check = 1;

    [Header("가운데 빛")]
    public bool Among_Pick = true;
    public Image Among_Light;

    [Header("아이템 창")]
    public GameObject Among_Window;

    [Header("아이템 봉 / 배경")]
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
        if (Left_Mouse.Inst.Left_Pick == true && Right_Mouse.Inst.Right_Pick == true)
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
        if (Among_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
        {
            Among_Pick = false;
            Left_Mouse.Inst.Left_Pick = false;
            Right_Mouse.Inst.Right_Pick = false;

            if (Card_Manager.Inst.DA_Among == false)
            {
                for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                {
                    if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.ItemDA_AmongCheck[0].Itme_Name)
                    {
                        Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.DABuffer[i]);
                        Card_Manager.Inst.DABuffer.RemoveAt(i);
                    }
                }
            }

            if (Card_Manager.Inst.Item_Among == false)
                Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.ItemDA_AmongCheck[0]);

            if (Card_Manager.Inst.Item_bool == true)
                Card_Manager.Inst.Item_bool = false;

            else if (Card_Manager.Inst.Item_bool == false)
                Card_Manager.Inst.Item_Check += AmongClick_Check;


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
