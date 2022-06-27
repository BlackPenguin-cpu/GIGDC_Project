using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Foundation : MonoBehaviour
{
    [Header("제단")]
    public GameObject Magic_Circle;
    public float Speed;

    [Header("업그레이드 버튼")]
    public GameObject Upgrade;
    public Text Upgrade_Text;
    public Image F_Button;
    public bool Collision_Check = true;

    [Header("마력강화 창")]
    private float timer;
    public GameObject Malyeog_Window;
    public RectTransform MalyeogRect_Window;
    public GameObject Pole_01;
    public GameObject Pole_02;

    void Start()
    {
        Upgrade_Text.DOFade(0f, 0f);
        F_Button.DOFade(0f, 0f);
    }

    void Update()
    {
        MagicCircle_Rotation();
        Foundation_Click();
        Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-5.2f, -4.4f, 0));
    }

    public void MagicCircle_Rotation() => Magic_Circle.transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));

    public void Foundation_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false)
        {
            StartCoroutine(Open_Window());
        }
    }

    #region 창 연출
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
    #endregion

    #region 충돌 체크
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collision_Check = false;
            Upgrade_Text.DOFade(1f, 0.5f);
            F_Button.DOFade(1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collision_Check = true;
            Upgrade_Text.DOFade(0f, 0.5f);
            F_Button.DOFade(0f, 0.5f);
        }
    }
    #endregion
}
