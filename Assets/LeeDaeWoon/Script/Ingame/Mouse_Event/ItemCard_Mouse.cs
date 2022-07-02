//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//using DG.Tweening;

//public class ItemCard_Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
//{
//    public enum Direction
//    {
//        Left,
//        Among,
//        Right
//    }

//    public Direction direction;
//    float timer = 0;

//    [Header("확인")]
//    int LeftClick_Check = 1;
//    bool LeftCloseWindow_Check = true;

//    int AmongClick_Check = 1;
//    bool AmongCloseWindow_Check = true;

//    int RightClick_Check = 1;
//    bool RightCloseWindow_Check = true;

//    [Header("빛")]
//    public Image Left_Light;
//    public Image Among_Light;
//    public Image Right_Light;

//    public bool Left_Pick = true;
//    public bool Among_Pick = true;
//    public bool Right_Pick = true;

//    [Header("아이템 창")]
//    public GameObject Left_Window;
//    public RectTransform Among_Window;
//    public RectTransform Right_Window;

//    [Header("아이템 봉 / 배경")]
//    //왼쪽
//    public GameObject Left_Pole_01;
//    public GameObject Left_Pole_02;
//    public RectTransform Left_Rect;

//    // 가운데
//    public GameObject Among_Pole_01;
//    public GameObject Among_Pole_02;
//    public RectTransform Among_Rect;

//    // 오른쪽
//    public GameObject Right_Pole_01;
//    public GameObject Right_Pole_02;
//    public RectTransform Right_Rect;




//    void Start()
//    {

//    }

//    void Update()
//    {

//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        switch (direction)
//        {
//            case Direction.Left:
//                if (Among_Pick == true && Right_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
//                    Left_Light.DOFade(1f, 0.5f);
//                break;

//            case Direction.Among:
//                if (Left_Pick == true && Right_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
//                    Among_Light.DOFade(1f, 0.5f);
//                break;

//            case Direction.Right:
//                if (Left_Pick == true && Among_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
//                    Right_Light.DOFade(1f, 0.5f);
//                break;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (direction == Direction.Left)
//            Left_Light.DOFade(0f, 0.5f);

//        if (direction == Direction.Among)
//            Among_Light.DOFade(0f, 0.5f);

//        if (direction == Direction.Right)
//            Right_Light.DOFade(0f, 0.5f);
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        if (Left_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
//        {
//            Left_Pick = false;
//            Among_Pick = false;
//            Right_Pick = false;

//            if (Card_Manager.Inst.DA_Left == false)
//            {
//                for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
//                {
//                    if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.ItemDA_LeftCheck[0].Itme_Name)
//                    {
//                        Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.DABuffer[i]);
//                        Card_Manager.Inst.DABuffer.RemoveAt(i);
//                    }
//                }
//            }

//            if (Card_Manager.Inst.Item_Left == false)
//                Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.ItemDA_LeftCheck[0]);

//            if (Card_Manager.Inst.Item_bool == true)
//                Card_Manager.Inst.Item_bool = false;

//            else if (Card_Manager.Inst.Item_bool == false)
//                Card_Manager.Inst.Item_Check += LeftClick_Check;


//            if (Card_Manager.Inst.TimeItem_Count <= 2)
//            {
//                Card_Manager.Inst.Time_Item_Limit.Add(Card_Manager.Inst.ItemDA_LeftCheck[0]);
//                for (int i = 0; i < Card_Manager.Inst.Time_Item_Limit.Count; i++)
//                {
//                    if (Card_Manager.Inst.Time_Item_Limit[i].Itme_Name.Contains(Card_Manager.Inst.ItemBuffer[4].Itme_Name))
//                    {
//                        Card_Manager.Inst.TimeItem_Count++;
//                        Card_Manager.Inst.Time_Item_Limit.Clear();
//                    }
//                }
//            }

//            Left_Light.DOFade(1f, 0.1f);
//            Left_Window.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.InQuad);
//            StartCoroutine(Close_Dot());
//        }
//    }

//    public IEnumerator Close_Dot()
//    {
//        timer = 0;
//        if (direction == Direction.Left)
//        {
//            Among_Pole_01.transform.DOLocalMoveY(-53f, 0.5f);
//            Among_Pole_02.transform.DOLocalMoveY(-125f, 0.5f);

//            Right_Pole_01.transform.DOLocalMoveY(-32f, 0.5f);
//            Right_Pole_02.transform.DOLocalMoveY(-108f, 0.5f);

//            while (timer < 1)
//            {
//                Among_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
//                Right_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
//                timer += Time.deltaTime * 3f;
//                yield return null;
//            }

//            LeftCloseWindow_Check = false;
//            if (LeftCloseWindow_Check == false)
//            {
//                yield return new WaitForSeconds(0.2f);
//                Destroy(GameObject.Find("Item_Window(Clone)"));
//            }
//        }
//    }
//}
