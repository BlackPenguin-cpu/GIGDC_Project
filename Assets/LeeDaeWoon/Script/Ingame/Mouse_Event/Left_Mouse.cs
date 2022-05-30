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
    public float Left_num = 1f;
    public Image Left_Light;

    [Header("æ∆¿Ã≈€ √¢")]
    public GameObject Left_Window;
    public GameObject Among_Window;
    public GameObject Right_Window;

    [Header("æ∆¿Ã≈€ ∫¿ / πË∞Ê")]
    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_Rect;

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
        if (Among_Mouse.In.Among_num == 0 && Right_Mouse.In.Right_num == 0)
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
        if (Left_num == 0)
        {
            Left_num += 1f;
            Left_Light.DOFade(1f, 0.1f);
            Left_Window.transform.DOLocalMoveY(1058, 0.5f).SetEase(Ease.InQuad);
            StartCoroutine(Close_Dot());

        }

    }

    public IEnumerator Close_Dot()
    {
        Among_Pole_01.transform.DOLocalMoveY(0f, 0.5f);
        Among_Pole_02.transform.DOLocalMoveY(0f, 0.5f);
        Among_Pole_01.transform.DOScaleY(0f, 0.5f);
        Among_Pole_02.transform.DOScaleY(0f, 0.5f);

        Right_Pole_01.transform.DOLocalMoveY(0f, 0.5f);
        Right_Pole_02.transform.DOLocalMoveY(0f, 0.5f);
        Right_Pole_01.transform.DOScaleY(0f, 0.5f);
        Right_Pole_02.transform.DOScaleY(0f, 0.5f);

        while (timer < 1)
        {
            Among_Rect.sizeDelta = new Vector2(1224, Mathf.Lerp(915, 0, timer));
            Right_Rect.sizeDelta = new Vector2(1224, Mathf.Lerp(915, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(GameObject.Find("Item_Window(Clone)"));
    }
}
