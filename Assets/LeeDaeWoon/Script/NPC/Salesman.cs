using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Salesman : MonoBehaviour
{
    [Header("�ٸ� ��ǰ ����")]
    public GameObject Different_Product;
    public Text Different_Product_Text;
    public Text Gold_Text;
    public Image Gold_Image;
    public Image F_Button;
    public float Gold_Num;
    private bool Collision_Check = true;

    void Start()
    {
        #region ������Ʈ ã��
        Different_Product = GameObject.Find("Salesman");
        Different_Product_Text = GameObject.Find("Different_Product_Text").GetComponent<Text>();
        Gold_Text = GameObject.Find("Salesman_Gold_Text").GetComponent<Text>();
        Gold_Image = GameObject.Find("Salesman_Gold_Image").GetComponent<Image>();
        F_Button = GameObject.Find("F_Image").GetComponent<Image>();
        #endregion

        //if (Wave�� 5�� ���)
        //{
        Gold_Num = 600;
        //}

        //else if (Wave�� 10�� ���)
        //{
        //Gold_Num = 1052;
        //}

        //else if (Wave�� 15�� ���)
        //{
        //Gold_Num = 2019;
        //}

        Gold_Text.text = "" + Gold_Num;


        Different_Product_Text = GameObject.Find("Different_Product_Text").GetComponent<Text>();
        F_Button = GameObject.Find("F_Image").GetComponent<Image>();
    }

    void Update()
    {
        Different_Product.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-8, -4.9f, 0));
        Re_Roll();
    }

    private void Re_Roll()
    {
        if (UI_Manager.Inst.Gold >= Gold_Num)
        {
            if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false)
            {
                UI_Manager.Inst.Gold -= Gold_Num;
                Gold_Text.text = "" + (Gold_Num += 200);
            }
        }
    }

    #region �浹üũ

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collision_Check = false;
            Different_Product_Text.DOFade(1f, 0.5f);
            F_Button.DOFade(1f, 0.5f);
            Gold_Text.DOFade(1f, 0.5f);
            Gold_Image.DOFade(1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collision_Check = true;
            Different_Product_Text.DOFade(0f, 0.5f);
            F_Button.DOFade(0f, 0.5f);
            Gold_Text.DOFade(0f, 0.5f);
            Gold_Image.DOFade(0f, 0.5f);
        }
    }
    #endregion
}
