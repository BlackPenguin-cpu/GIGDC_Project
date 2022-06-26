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
    public GameObject MalyeogRect_Window;
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
        Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-5.2f, -4.4f,0));
    }

    public void MagicCircle_Rotation() => Magic_Circle.transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));

    public void Foundation_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false)
        {

        }
    }

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
