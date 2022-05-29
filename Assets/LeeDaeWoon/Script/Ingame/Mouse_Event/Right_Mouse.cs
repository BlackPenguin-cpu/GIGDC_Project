using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Right_Mouse : SingletonMono<Right_Mouse>, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private float timer = 0f;

    [Header("오른쪽 빛")]
    public float Right_num = 3f;
    public Image Right_Light;

    [Header("아이템 창")]
    public GameObject Right_Window;

    [Header("아이템 봉 / 배경")]
    public GameObject Left_Pole_01;
    public GameObject Left_Pole_02;
    public RectTransform Left_Rect;

    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_Rect;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Left_Mouse.In.Left_num == 0 && Among_Mouse.In.Among_num == 0)
        {
            Right_Light.DOFade(1f, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Right_Light.DOFade(0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Right_num == 0)
        {
            Right_num += 1f;
            Right_Light.DOFade(1f, 0.1f);
            Right_Window.transform.DOLocalMoveY(1058, 0.5f).SetEase(Ease.InQuad);
            StartCoroutine(Close_Dot());
        }
    }

    public IEnumerator Close_Dot()
    {
        Left_Pole_01.transform.DOLocalMoveY(0f, 0.5f);
        Left_Pole_02.transform.DOLocalMoveY(0f, 0.5f);
        Left_Pole_01.transform.DOScaleY(0f, 0.5f);
        Left_Pole_02.transform.DOScaleY(0f, 0.5f);

        Among_Pole_01.transform.DOLocalMoveY(0f, 0.5f);
        Among_Pole_02.transform.DOLocalMoveY(0f, 0.5f);
        Among_Pole_01.transform.DOScaleY(0f, 0.5f);
        Among_Pole_02.transform.DOScaleY(0f, 0.5f);

        while (timer < 1)
        {
            Left_Rect.sizeDelta = new Vector2(1224, Mathf.Lerp(915, 0, timer));
            Among_Rect.sizeDelta = new Vector2(1224, Mathf.Lerp(915, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(GameObject.Find("Item_Window(Clone)"));
    }
}
