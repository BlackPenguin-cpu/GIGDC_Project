using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Window : MonoBehaviour
{
    [Header("속도")]
    public float timer = 0f;

    [Header("왼쪽 창")]
    public GameObject Left_Pole_01;
    public GameObject Left_Pole_02;
    public RectTransform Left_Window;

    [Header("가운데 창")]
    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_Window;

    [Header("오른쪽 창")]
    public GameObject Right_Pole_01;
    public GameObject Right_Pole_02;
    public RectTransform Right_Window;

    [Header("빛")]
    public Image Left_Light;
    public Image Among_Light;
    public Image Right_Light;

    public int Light_num;

    void Start()
    {
        StartCoroutine(itemWindow());
    }

    void Update()
    {

    }


    private IEnumerator itemWindow()
    {
        #region 창 연출(위, 아래 봉 ( 리소스 나오면 지워도 됨 ))

        Left_Pole_01.transform.DOLocalMoveY(447f, 0.5f);
        Left_Pole_02.transform.DOLocalMoveY(-440f, 0.5f);

        Among_Pole_01.transform.DOLocalMoveY(370f, 0.5f);
        Among_Pole_02.transform.DOLocalMoveY(-513f, 0.5f);

        Right_Pole_01.transform.DOLocalMoveY(370f, 0.5f);
        Right_Pole_02.transform.DOLocalMoveY(-513f, 0.5f);

        #endregion

        while (timer < 1)
        {

            Left_Window.sizeDelta = new Vector2(1224, Mathf.Lerp(1, 915, timer));
            Among_Window.sizeDelta = new Vector2(1224, Mathf.Lerp(1, 915, timer));
            Right_Window.sizeDelta = new Vector2(1224, Mathf.Lerp(1, 915, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }

    }
}
