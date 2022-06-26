using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Window : MonoBehaviour
{

    [Header("�ӵ�")]
    public float Window_timer = 0f;

    [Header("���� â")]
    public GameObject Left_Pole_01;
    public GameObject Left_Pole_02;
    public RectTransform Left_RectMask;

    [Header("��� â")]
    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_RectMask;


    [Header("������ â")]
    public GameObject Right_Pole_01;
    public GameObject Right_Pole_02;
    public RectTransform Right_RectMask;


    [Header("��")]
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
        Card_Manager.Inst.ItemCard_OpenCheck = true;
        Window_timer = 0;

        #region â ����(��, �Ʒ� ��)

        Left_Pole_01.transform.DOLocalMoveY(435f, 0.55f);
        Left_Pole_02.transform.DOLocalMoveY(-455f, 0.55f);

        Among_Pole_01.transform.DOLocalMoveY(334f, 0.55f);
        Among_Pole_02.transform.DOLocalMoveY(-552f, 0.55f);

        Right_Pole_01.transform.DOLocalMoveY(355f, 0.55f);
        Right_Pole_02.transform.DOLocalMoveY(-525f, 0.55f);

        #endregion

        while (Window_timer < 1)
        {
            Left_RectMask.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(0, 824.77f, Window_timer));
            Among_RectMask.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(0, 824.77f, Window_timer));
            Right_RectMask.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(0, 824.77f, Window_timer));

            Window_timer += Time.deltaTime * 3f;
            yield return null;
        }
        Card_Manager.Inst.ItemCard_OpenCheck = false;
    }
}
