using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skill_Window : MonoBehaviour
{
    public static Skill_Window Inst { get; private set; }

    [Header("��ųâ �ð�")]
    public float Timer = 0;

    [Header("��ų â")]
    public RectTransform Pole_01 = new RectTransform();
    public RectTransform Pole_02 = new RectTransform();
    public RectTransform Skill_RectTransform = new RectTransform();

    [Header("�⺻ ��ų �̹���")]
    public Image Basics_Skill_A;
    public Image Basics_Skill_S;

    [Header("���� �� â")]
    public GameObject AfterPurchase_Window_Prefab; // ��ų ���� â ������
    public GameObject AfterPurchase_Key; // ���� Ű ������Ʈ


    public GameObject AfterPurchase_Skill; // ��ų �����ϱ� �� ��ų �̹���
    public GameObject AfterPurchase_Window; // ��ų���� â
    public GameObject AfterPurchase_Skill_Box; // ��ų �����ϱ� �� ��ų�ڽ� �̹���
    public GameObject AfterPurchase_LeftDirection; // ���� ȭ��ǥ
/*  public RectTransform AfterPurchase_Skill = new RectTransform(); // ��ų �����ϱ� �� ��ų �̹���
    public RectTransform AfterPurchase_Window = new RectTransform(); // ��ų���� â
    public RectTransform AfterPurchase_Skill_Box = new RectTransform(); // ��ų �����ϱ� �� ��ų�ڽ� �̹���
    public RectTransform AfterPurchase_LeftDirection = new RectTransform(); // ���� ȭ��ǥ*/

    [Header("��ų ��ǥ")]
    [SerializeField] GameObject Skill_Shop;

    //public Image AfterPurchase_Top_Light;
    //public Image AfterPurchase_Bottom_Light;

    public GameObject Save_Clone;

    public int SkillNum; // ���� �� ��° ���� ��ų�� �浹�ߴ��� ���� Ȯ��
    public bool UpDown = true; // ���� �� ���� �Ʒ� ���� Ȯ��
    public bool Purchase = true; // ���� ���������� �ƴ��� Ȯ��
    public bool SkillWindow = true; // ��ų â�� �������� Ȯ��
    public bool UpDown_Limit = true; // ���Ʒ� ����
    public bool SkillColider_Check; // ���� ���� ��ų��� �浹 �ߴ��� üũ Ȯ��

    public int RandomTest;

    public bool MoreThanOnce_Purchase = true; // 1�� �̻� ��ų�� ������ ��
    private bool UP_MoreThanOnce_Purchase = true; // �� ��ų�� 1�� �̻� ��ų�� ������ ��
    private bool Down_MoreThanOnce_Purchase = true; // �Ʒ� ��ų�� 1�� �̻� ��ų�� ������ ��

    Skill SeletSkill = new Skill();

    void Start()
    {
        #region GameObject.Find
        Basics_Skill_A = GameObject.Find("Basic_Skill01").GetComponent<Image>();
        Basics_Skill_S = GameObject.Find("Basic_Skill02").GetComponent<Image>();

        AfterPurchase_Window = GameObject.Find("After_Purchase");
        AfterPurchase_Key = GameObject.Find("Direction_Key");
        AfterPurchase_Skill = GameObject.Find("After_Skill_Image");
        AfterPurchase_Skill_Box = GameObject.Find("After_Skill_Box");
        AfterPurchase_LeftDirection = GameObject.Find("Left_Direction");
   /*     AfterPurchase_Skill = GameObject.Find("After_Skill_Image").GetComponent<RectTransform>();
        AfterPurchase_Skill_Box = GameObject.Find("After_Skill_Box").GetComponent<RectTransform>();
        AfterPurchase_LeftDirection = GameObject.Find("Left_Direction").GetComponent<RectTransform>();*/
        #endregion

        AfterPurchase_Left();
        SkillColider_Check = false;
        AfterPurchase_Window.gameObject.SetActive(false);

        // ������ ������ �� ������Ʈ�� 3��° �ڽ�(��ų â)�� ���ش�.
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }

    void Update()
    {
        ScreentoWorld();
        Skill_Purchase();
        AfterPurchase_UpDown();
    }

    private void Awake()
    {
        Inst = this;
    /*    if (Salesman.Inst.Apply_Check == true)
            AfterPurchase_Window = GameObject.Find("After_Purchase").GetComponent<RectTransform>();
        else
            AfterPurchase_Window = GameObject.Find("After_Purchase(Clone)").GetComponent<RectTransform>();*/
    }
    void ScreentoWorld()
    {
        // ���� ��ǥ�� ��ũ�� ��ǥ�� ������ ���ش�.
        transform.localPosition = Camera.main.WorldToScreenPoint(Skill_Shop.gameObject.transform.position + new Vector3(-17.5f, -5, 0));
    }

    public void Skill_Window_Active()
    {
        // �� ��ũ��Ʈ�� �� �ִ� ������Ʈ�� 3��° �ڽ�(��ų â)�� ���ش�.
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Skill_Purchase()
    {
        // FŰ�� ���Ͽ� ���� Ȥ�� ��ų������ �� �� �ִ�.
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ��ų����
            if (Purchase == true && SkillColider_Check == true && (UI_Manager.Inst.Gold >= Skill_List.Inst.Left_Gold || UI_Manager.Inst.Gold >= Skill_List.Inst.Among_Gold || UI_Manager.Inst.Gold >= Skill_List.Inst.Right_Gold))
            {
                SeletSkill = Skill_Manager.Inst.Skill[SkillNum];
                AfterPurchase_Skill.GetComponent<Image>().sprite = SeletSkill.Icon;

                //if (Wave�� 5�� ���)
                //{
                UI_Manager.Inst.Gold -= SeletSkill.Gold_01;
                //}
                //else if (Wave�� 10�� ���)
                //{
                //  UI_Manager.Inst.Gold -= SeletSkill.Gold_02;
                //}
                //else if (Wave�� 15�� ���)
                //{
                //  UI_Manager.Inst.Gold -= SeletSkill.Gold_03;
                //}

                Skill_Manager.Inst.Skill_Have.Add(SeletSkill);
                Skill_Manager.Inst.Skill_Shop.Add(SeletSkill);

                Purchase = false; // �̰��� ���Ͽ� ��ų���� -> ��ų�������� �Ѱ��ش�.
                SkillClose_Dot(); // ��ų â�� �ݾ��ش�.

                this.gameObject.transform.GetChild(SkillNum).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(SkillNum).GetChild(2).gameObject.SetActive(true);
            }

            // ��ų����
            else if (Purchase == false)
            {
                AfterPurchase_Key.gameObject.SetActive(false);
                StartCoroutine(SkillHave()); // SkillHave �ڷ�ƾ�� �����Ų��.
                Purchase = true; // �̰��� ���Ͽ� ��ų���� -> ��ų���ŷ� �Ѱ��ش�.
            }
        }
    }

   
    #region ���� �� ��ų ����
    public IEnumerator SkillHave()
    {
        // �� �κп� ��ų�� �����ҷ� �� ��
        if (UpDown == true && UpDown_Limit == true)
        {
            UpDown_Limit = false;

            // �� �κп� 1�� �̻��� ��ų�� ������ �� �� �����ϱ� ���� ��ų�� �ٽ� �������� �Ѿ��.
            if (UP_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Up[0]);
                Skill_Manager.Inst.Skill_Up.RemoveAt(0);
            }

            // ������ ��ų�� �� �κп� �־��ش�.
            Skill_Manager.Inst.Skill_Up.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);

            Vector3[] SaveSkillPos = new Vector3[2];
            SaveSkillPos[0] = AfterPurchase_Skill.transform.position;
            SaveSkillPos[1] = AfterPurchase_Skill_Box.transform.position;

            //��ų ���� �ִϸ��̼�
            AfterPurchase_Skill.transform.DOLocalMove(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.transform.DOLocalMove(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);

            yield return new WaitForSeconds(0.5f);

            // AS_Limit = Shift�� ���� ��ų ��ȯ üũ
            if (Skill_Manager.Inst.AS_Limit == true) // true�� ��� A��ų�� ������ ��ų�� �����Ų��.
            {
                Basics_Skill_A.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_S.sprite = SeletSkill.Icon; // false�� ��� S��ų�� ������ ��ų�� �����Ų��.

            // �� �� �̸� ��ų�� �����ų �� �����Ų��.
            AfterPurchase_Skill.transform.position = SaveSkillPos[0];
            AfterPurchase_Skill_Box.transform.position = SaveSkillPos[1];
            AfterPurchase_Key.gameObject.SetActive(true);
            if (MoreThanOnce_Purchase == true)
            {
                AfterPurchase_Window.SetActive(false);
                MoreThanOnce_Purchase = false;
                UP_MoreThanOnce_Purchase = false;
            }

            // �� �� �̻� ��ų�� �����ų �� �����Ų��.
            else
            {
                AfterPurchase_Window.SetActive(false);
            }
            UpDown_Limit = true;
        }

        // �Ʒ� �κп� ��ų�� �����ҷ� �� ��
        else if (UpDown == false && UpDown_Limit == true)
        {
            UpDown_Limit = false;

            // �� �κп� 1�� �̻��� ��ų�� ������ �� �� �����ϱ� ���� ��ų�� �ٽ� �������� �Ѿ��.
            if (Down_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Down[0]);
                Skill_Manager.Inst.Skill_Down.RemoveAt(0);
            }

            // ������ ��ų�� �Ʒ� �κп� �־��ش�.
            Skill_Manager.Inst.Skill_Down.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);

            Vector3[] SaveSkillPos = new Vector3[2];
            SaveSkillPos[0] = AfterPurchase_Skill.transform.position;
            SaveSkillPos[1] = AfterPurchase_Skill_Box.transform.position;

            //��ų ���� �ִϸ��̼�
            AfterPurchase_Skill.transform.DOLocalMove(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.transform.DOLocalMove(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);

            yield return new WaitForSeconds(0.5f);

            // AS_Limit = Shift�� ���� ��ų ��ȯ üũ
            if (Skill_Manager.Inst.AS_Limit_02 == true) // true�� ��� S��ų�� ������ ��ų�� �����Ų��.
            {
                Basics_Skill_S.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_A.sprite = SeletSkill.Icon;

            // �� �� �̸� ��ų�� �����ų �� �����Ų��.
            AfterPurchase_Skill.transform.position = SaveSkillPos[0];
            AfterPurchase_Skill_Box.transform.position = SaveSkillPos[1];
            AfterPurchase_Key.gameObject.SetActive(true);
            if (MoreThanOnce_Purchase == true)
            {
                AfterPurchase_Window.SetActive(false);
                MoreThanOnce_Purchase = false;
                Down_MoreThanOnce_Purchase = false;
            }
            // �� �� �̻� ��ų�� �����ų �� �����Ų��.
            else
            {
                AfterPurchase_Window.SetActive(false);
            }
            UpDown_Limit = true;
        }
    }
    #endregion

    #region ��ų ���� �� ���ʹ��� ȭ��ǥ
    public void AfterPurchase_Left()
    {
        StartCoroutine(AfterPurchase_Left_forward());
    }

    public IEnumerator AfterPurchase_Left_forward()
    {
        AfterPurchase_LeftDirection.transform.DOLocalMoveX(-570, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AfterPurchase_Left_Back());
    }

    public IEnumerator AfterPurchase_Left_Back()
    {
        AfterPurchase_LeftDirection.transform.DOLocalMoveX(-550, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AfterPurchase_Left_forward());
    }
    #endregion

    #region ��ų���� �� ��,�Ʒ� ���� ȭ��ǥ
    public void AfterPurchase_UpDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && Purchase == false && UpDown == false && UpDown_Limit == true)
        {
            UpDown = true;
            AfterPurchase_Window.transform.DOLocalMoveY(5f, 1f).SetEase(Ease.OutBack);
            //AfterPurchase_Window.DOAnchorPosY(5f, 1f).SetEase(Ease.OutBack);

        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && Purchase == false && UpDown == true && UpDown_Limit == true)
        {
            UpDown = false;
            AfterPurchase_Window.transform.DOLocalMoveY(-145f, 1f).SetEase(Ease.OutBack);
            //AfterPurchase_Window.DOAnchorPosY(-145f, 1f).SetEase(Ease.OutBack);
        }
    }
    #endregion

    #region ��ų â

    public void SkillClose_Dot()
    {
        // ��ų â�� �ݾ��ִ� �Լ�
        Skill_RectTransform.DOAnchorPosY(226.43f, 0.5f);
        Pole_02.DOAnchorPosY(202.92f, 0.5f);
        StartCoroutine(SkillWindowClose_Coroutine());
    }

    public IEnumerator SkillWindow_Coroutine()
    {
        // ��ų â�� �����ִ� �ڷ�ƾ
        SkillWindow = false;

        Timer = 0;
        if (SkillNum == 0)
        {
            while (Timer < 1)
            {
                Skill_RectTransform.anchoredPosition = new Vector2(1.995371f, Mathf.Lerp(226.43f, 32.97299f, Timer));
                Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(5.9433f, 392.86f, Timer));
                Pole_01.anchoredPosition = new Vector3(1.9954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(202.92f, -176.01f, Timer));
                Timer += Time.deltaTime * 4f;
                yield return null;
            }
        }

        else if (SkillNum == 1)
        {
            while (Timer < 1)
            {
                Skill_RectTransform.anchoredPosition = new Vector2(402.6954f, Mathf.Lerp(226.43f, 32.97299f, Timer));
                Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(5.9433f, 392.86f, Timer));
                Pole_01.anchoredPosition = new Vector3(402.6954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(402.6954f, Mathf.Lerp(202.92f, -176.01f, Timer));
                Timer += Time.deltaTime * 4f;
                yield return null;
            }
        }

        else if (SkillNum == 2)
        {
            while (Timer < 1)
            {
                Skill_RectTransform.anchoredPosition = new Vector2(839.6954f, Mathf.Lerp(226.43f, 32.97299f, Timer));
                Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(5.9433f, 392.86f, Timer));
                Pole_01.anchoredPosition = new Vector3(839.6954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(839.6954f, Mathf.Lerp(202.92f, -176.01f, Timer));
                Timer += Time.deltaTime * 4f;
                yield return null;
            }
        }
    }

    public IEnumerator SkillWindowClose_Coroutine()
    {
        //asdf
        // ��ų â�� �ݾ��ִ� �ڷ�ƾ

        Timer = 0;
        while (Timer < 1)
        {
            Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(392.86f, 5.9433f, Timer));

            if (SkillNum == 0)
            {
                Pole_01.anchoredPosition = new Vector3(1.9954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(-176.01f, 202.92f, Timer));
            }

            else if (SkillNum == 1)
            {
                Pole_01.anchoredPosition = new Vector3(402.6954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(402.6954f, Mathf.Lerp(-176.01f, 202.92f, Timer));
            }
            
            else if (SkillNum == 2)
            {
                Pole_01.anchoredPosition = new Vector3(839.6954f, 244, 0);
                Pole_02.anchoredPosition = new Vector2(839.6954f, Mathf.Lerp(-176.01f, 202.92f, Timer));
            }

            Timer += Time.deltaTime * 4f;
            yield return null;
        }

        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        SkillWindow = true;

        if (Purchase == false)
        {
            AfterPurchase_Window.gameObject.SetActive(true);
        }
    }
    #endregion
}
