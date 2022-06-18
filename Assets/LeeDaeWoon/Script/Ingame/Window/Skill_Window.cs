using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skill_Window : MonoBehaviour
{
    public static Skill_Window Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("��ųâ �ð�")]
    public float Timer = 0;

    [Header("��ų â")]
    public RectTransform Skill_RectTransform;
    public RectTransform Pole_02;

    [Header("�⺻ ��ų �̹���")]
    public Image Basics_Skill_A;
    public Image Basics_Skill_S;

    [Header("���� �� â")]
    public GameObject AfterPurchase_Window_Prefab; // ��ų ���� â ������
    public GameObject AfterPurchase_Key; // ���� Ű ������Ʈ
    public RectTransform AfterPurchase_Skill; // ��ų �����ϱ� �� ��ų �̹���
    public RectTransform AfterPurchase_Window; // ��ų���� â
    public RectTransform AfterPurchase_Skill_Box; // ��ų �����ϱ� �� ��ų�ڽ� �̹���
    public RectTransform AfterPurchase_LeftDirection; // ���� ȭ��ǥ

    [Header("��ų ��ǥ")]
    [SerializeField] GameObject Skill_Shop;

    //public Image AfterPurchase_Top_Light;
    //public Image AfterPurchase_Bottom_Light;

    public bool UpDown = true; // ���� �� ���� �Ʒ� ���� Ȯ��
    public bool SkillWindow = true; // ��ų â�� �������� Ȯ��
    public bool Purchase = true; // ���� ���������� �ƴ��� Ȯ��
    public bool SkillColider_Check; // ���� ���� ��ų��� �浹 �ߴ��� üũ Ȯ��
    public int SkillNum; // ���� �� ��° ���� ��ų�� �浹�ߴ��� ���� Ȯ��

    public bool UpDown_Limit = true; // ���Ʒ� ����
    public int RandomTest;

    private bool MoreThanOnce_Purchase = true; // 1�� �̻� ��ų�� ������ ��
    private bool UP_MoreThanOnce_Purchase = true; // �� ��ų�� 1�� �̻� ��ų�� ������ ��
    private bool Down_MoreThanOnce_Purchase = true; // �Ʒ� ��ų�� 1�� �̻� ��ų�� ������ ��

    Skill SeletSkill;


    void Start()
    {
        #region GameObject.Find
        Basics_Skill_A = GameObject.Find("Basic_Skill01").GetComponent<Image>();
        Basics_Skill_S = GameObject.Find("Basic_Skill02").GetComponent<Image>();

        AfterPurchase_Key = GameObject.Find("Direction_Key");
        AfterPurchase_Window = GameObject.Find("After_Purchase").GetComponent<RectTransform>();
        AfterPurchase_Skill = GameObject.Find("After_Skill_Image").GetComponent<RectTransform>();
        AfterPurchase_Skill_Box = GameObject.Find("After_Skill_Box").GetComponent<RectTransform>();
        AfterPurchase_LeftDirection = GameObject.Find("Left_Direction").GetComponent<RectTransform>();
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

    void ScreentoWorld()
    {
        // ����Ƽ ���� ��ǥ�� ��ũ�� ��ǥ�� ������ ���ش�.
        transform.localPosition = Camera.main.WorldToScreenPoint(Skill_Shop.gameObject.transform.position + new Vector3(-17.5f, -5, 0));
    }

    public void Skill_Window_Active()
    {
        // �� ��ũ��Ʈ�� �� �ִ� ������Ʈ�� 3��° �ڽ�(��ų â)�� ���ش�.
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void SkillClose_Dot()
    {
        // ��ų â�� �ݾ��ִ� �Լ�
        Skill_RectTransform.DOAnchorPosY(226.43f, 0.5f);
        Pole_02.DOAnchorPosY(202.92f, 0.5f);
        StartCoroutine(SkillWindowClose_Coroutine());
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
                Skill_Manager.Inst.Skill_Shop.RemoveAt(SkillNum);


                for (int i = 0; i < 2; i++)
                {
                    //Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill[0]);
                    //Skill_Manager.Inst.Skill.RemoveAt(0);
                }

                Purchase = false; // �̰��� ���Ͽ� ��ų���� -> ��ų�������� �Ѱ��ش�.
                SkillClose_Dot();
                this.gameObject.transform.GetChild(SkillNum).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(SkillNum).GetChild(2).gameObject.SetActive(true);
            }

            // ��ų����
            else if (Purchase == false)
            {
                AfterPurchase_Key.gameObject.SetActive(false);
                StartCoroutine(SkillHave());
                Purchase = true; // �̰��� ���Ͽ� ��ų���� -> ��ų���ŷ� �Ѱ��ش�.
            }
        }
    }


    #region ���� �� ��ų ����
    public IEnumerator SkillHave()
    {
        // �� �κп� ��ų�� ���� �� ��
        if (UpDown == true && UpDown_Limit == true)
        {
            if (UP_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Up[0]);
                Skill_Manager.Inst.Skill_Up.RemoveAt(0);
            }

            Skill_Manager.Inst.Skill_Up.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);
            UpDown_Limit = false;
            AfterPurchase_Skill.DOAnchorPos(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.DOAnchorPos(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(0.5f);
            AfterPurchase_Skill.SetParent(GameObject.Find("Up").transform);
            AfterPurchase_Skill_Box.SetParent(GameObject.Find("Up").transform);

            if (Skill_Manager.Inst.AS_Limit == true)
            {
                Basics_Skill_A.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_S.sprite = SeletSkill.Icon;

            Destroy(AfterPurchase_Skill.gameObject); // ���� �� ���� ��ų�� �����ش�.
            Destroy(AfterPurchase_Skill_Box.gameObject); // ���� �� ���� ��ų ���� �����ش�.
            yield return new WaitForSeconds(0.5f);
            Instantiate(AfterPurchase_Window_Prefab, AfterPurchase_Window.transform.position, Quaternion.identity, GameObject.Find("Skill_Purchase_Canvas").transform);
            if (MoreThanOnce_Purchase == false)
            {
                Destroy(GameObject.Find("After_Purchase(Clone)")); // ��ų ���� ������Ʈ�� �����ش�.
                GameObject.Find("After_Purchase(Clone)").SetActive(false);
            }
            Destroy(GameObject.Find("After_Purchase")); // ��ų ���� ������Ʈ�� �����ش�.
            MoreThanOnce_Purchase = false;
            UP_MoreThanOnce_Purchase = false;
            UpDown_Limit = true;
            #region GameObject.Find()
            AfterPurchase_Skill = GameObject.Find("After_Skill_Image").GetComponent<RectTransform>();
            AfterPurchase_Skill_Box = GameObject.Find("After_Skill_Box").GetComponent<RectTransform>();
            AfterPurchase_Window = GameObject.Find("After_Purchase(Clone)").GetComponent<RectTransform>();
            AfterPurchase_LeftDirection = GameObject.Find("Left_Direction").GetComponent<RectTransform>();
            AfterPurchase_Key = GameObject.Find("Direction_Key");
            #endregion

            GameObject.Find("After_Purchase(Clone)").SetActive(false);
        }

        // �Ʒ� �κп� ��ų�� �����Ҷ� �� ��
        else if (UpDown == false && UpDown_Limit == true)
        {
            if (Down_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Down[0]);
                Skill_Manager.Inst.Skill_Down.RemoveAt(0);
            }

            Skill_Manager.Inst.Skill_Down.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);
            UpDown_Limit = false;
            AfterPurchase_Skill.DOAnchorPos(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.DOAnchorPos(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(0.5f);
            AfterPurchase_Skill.SetParent(GameObject.Find("Down").transform);
            AfterPurchase_Skill_Box.SetParent(GameObject.Find("Down").transform);

            if (Skill_Manager.Inst.AS_Limit_02 == true)
            {
                Basics_Skill_S.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_A.sprite = SeletSkill.Icon;

            Destroy(AfterPurchase_Skill.gameObject); // ���� �� ���� ��ų�� �����ش�.
            Destroy(AfterPurchase_Skill_Box.gameObject); // ���� �� ���� ��ų ���� �����ش�.
            yield return new WaitForSeconds(0.5f);
            Instantiate(AfterPurchase_Window_Prefab, AfterPurchase_Window.transform.position, Quaternion.identity, GameObject.Find("Skill_Purchase_Canvas").transform);
            if (MoreThanOnce_Purchase == false)
            {
                Destroy(GameObject.Find("After_Purchase(Clone)")); // ��ų ���� ������Ʈ�� �����ش�.
                GameObject.Find("After_Purchase(Clone)").SetActive(false);
            }
            Destroy(GameObject.Find("After_Purchase")); // ��ų ���� ������Ʈ�� �����ش�.
            MoreThanOnce_Purchase = false;
            Down_MoreThanOnce_Purchase = false;
            UpDown_Limit = true;
            #region GameObject.Find()
            AfterPurchase_Skill = GameObject.Find("After_Skill_Image").GetComponent<RectTransform>();
            AfterPurchase_Skill_Box = GameObject.Find("After_Skill_Box").GetComponent<RectTransform>();
            AfterPurchase_Window = GameObject.Find("After_Purchase(Clone)").GetComponent<RectTransform>();
            AfterPurchase_LeftDirection = GameObject.Find("Left_Direction").GetComponent<RectTransform>();
            AfterPurchase_Key = GameObject.Find("Direction_Key");
            #endregion

            GameObject.Find("After_Purchase(Clone)").SetActive(false);
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
        AfterPurchase_LeftDirection.DOAnchorPosX(-570, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AfterPurchase_Left_Back());
    }

    public IEnumerator AfterPurchase_Left_Back()
    {
        AfterPurchase_LeftDirection.DOAnchorPosX(-550, 1f).SetEase(Ease.InOutBack);
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
            AfterPurchase_Window.DOAnchorPosY(5f, 1f).SetEase(Ease.OutBack);

        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && Purchase == false && UpDown == true && UpDown_Limit == true)
        {
            UpDown = false;
            AfterPurchase_Window.DOAnchorPosY(-145f, 1f).SetEase(Ease.OutBack);
        }
    }
    #endregion

    #region ��ų â
    public IEnumerator SkillWindow_Coroutine()
    {
        SkillWindow = false;

        Timer = 0;
        while (Timer < 1)
        {
            Skill_RectTransform.anchoredPosition = new Vector2(1.995371f, Mathf.Lerp(226.43f, 32.97299f, Timer));
            Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(5.9433f, 392.86f, Timer));
            Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(202.92f, -176.01f, Timer));
            Timer += Time.deltaTime * 3f;
            yield return null;
        }
    }

    public IEnumerator SkillWindowClose_Coroutine()
    {
        Timer = 0;
        while (Timer < 1)
        {
            Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(392.86f, 5.9433f, Timer));
            Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(-176.01f, 202.92f, Timer));
            Timer += Time.deltaTime * 3f;
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
