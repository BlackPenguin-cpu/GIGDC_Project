using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackSmith : MonoBehaviour
{
    public static BlackSmith Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("��ȣ�ۿ� ��ư")]
    public Image F_Button; // ��ȣ�ۿ� ��ư
    public GameObject Upgrade; // ��ȣ�ۿ� ������Ʈ
    public Text Upgrade_Text; // ��ȣ�ۿ� �ؽ�Ʈ
    public bool Collision_Check = true; // �浹 �ߴ��� üũ

    [Header("���� ���� �� ��ȭ â")]
    private float timer; // â ������ �ӵ�
    public GameObject Pole_01; // ��_01
    public GameObject Pole_02; // ��_02
    public GameObject Malyeog_Window; // â ������Ʈ
    public RectTransform MalyeogRect_Window; // â

    public GameObject Weapon;
    public GameObject[] Weapon_Check = new GameObject[2];
    

    void Start()
    {
        Upgrade_Text.DOFade(0f, 0f);
        F_Button.DOFade(0f, 0f);
    }

    void Update()
    {
        BlackSmith_Click();
        #region ���� ��ǥ�� ��ũ�� ��ǥ�� ������ ���ش�.
        Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-3f, 0.3f, 0));
        #endregion
    }


    #region ��ư Ŭ��
    public void BlackSmith_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false)
            StartCoroutine(Open_Window());
    }

    public void Left_Arrow()
    {
        //Weapon_Check[0]
    }

    public void Right_Arrow()
    {

    }
    #endregion

    #region â ����
    public void Close() => StartCoroutine(Close_Window());

    public IEnumerator Open_Window()
    {
        Malyeog_Window.SetActive(true);
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(452, 0.5f);
        Pole_02.transform.DOLocalMoveY(-452, 0.5f);

        while (timer < 1)
        {
            MalyeogRect_Window.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(0, 931.6482f, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
    }

    public IEnumerator Close_Window()
    {
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(30, 0.5f);
        Pole_02.transform.DOLocalMoveY(-30, 0.5f);

        while (timer < 1)
        {
            MalyeogRect_Window.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(931.6482f, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        Malyeog_Window.SetActive(false);
    }
    #endregion

    #region �浹 üũ
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = false;
            Upgrade_Text.DOFade(1f, 0.5f);
            F_Button.DOFade(1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = true;
            Upgrade_Text.DOFade(0f, 0.5f);
            F_Button.DOFade(0f, 0.5f);
        }
    }
    #endregion
}
