using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skill_Window : MonoBehaviour
{
    public static Skill_Window Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("스킬창 시간")]
    public float Timer = 0;

    [Header("스킬 창")]
    public RectTransform Skill_RectTransform;
    public RectTransform Pole_02;

    [Header("기본 스킬 이미지")]
    public Image Basics_Skill_A;
    public Image Basics_Skill_S;

    [Header("구매 후 창")]
    public RectTransform AfterPurchase_Window; // 구매 후 창
    public RectTransform AfterPurchase_LeftDirection; // 왼쪽 화살표
    public RectTransform AfterPurchase_Skill; // 구매 후 스킬 이미지
    public RectTransform AfterPurchase_Skill_Box; // 구매 후 스킬박스 이미지
    //public Image AfterPurchase_Top_Light;
    //public Image AfterPurchase_Bottom_Light;

    public bool UpDown = true; // 현재 위 인지 아래 인지 확인
    public bool UpDown_Limit = true; // 위아래 제한

    private bool SkillWindow = true;
    public bool Purchase = true;
    public int LeftRight_KeyNum = 0;
    public int RandomTest;
    Skill SeletSkill;

    void Start()
    {
        Basics_Skill_A = GameObject.Find("Basic_Skill01").GetComponent<Image>();
        Basics_Skill_S = GameObject.Find("Basic_Skill02").GetComponent<Image>();

        AfterPurchase_Left();

        if (SkillWindow == true)
        {
            SkillWindow = false;
            StartCoroutine(SkillWindow_Coroutine());
        }
    }

    void Update()
    {

        Skill_Dot();
        Skill_Purchase();
        AfterPurchase_UpDown();
    }



    public void Skill_Dot()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Purchase == true)
        {
            if (1 <= LeftRight_KeyNum && LeftRight_KeyNum <= 2)
            {
                SkillWindow = true;
                LeftRight_KeyNum -= 1;
                if (SkillWindow == true)
                {
                    SkillWindow = false;
                    StartCoroutine(SkillWindow_Coroutine());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Purchase == true)
        {
            if (0 <= LeftRight_KeyNum && LeftRight_KeyNum <= 1)
            {
                SkillWindow = true;
                LeftRight_KeyNum += 1;
                if (SkillWindow == true)
                {
                    SkillWindow = false;
                    StartCoroutine(SkillWindow_Coroutine());
                }
            }
        }
    }

    public void SkillClose_Dot()
    {
        Skill_RectTransform.DOAnchorPosY(226.43f, 0.5f);
        Pole_02.DOAnchorPosY(202.92f, 0.5f);
        StartCoroutine(SkillWindowClose_Coroutine());
    }

    public void Skill_Purchase()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Purchase == true)
            {
                SeletSkill = Skill_Manager.Inst.Skill[LeftRight_KeyNum];
                AfterPurchase_Skill.GetComponent<Image>().sprite = SeletSkill.Icon;

                Skill_Manager.Inst.Skill_Have.Add(Skill_Manager.Inst.Skill[LeftRight_KeyNum]);
                Skill_Manager.Inst.Skill.RemoveAt(LeftRight_KeyNum);


                for (int i = 0; i < 2; i++)
                {
                    Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill[0]);
                    Skill_Manager.Inst.Skill.RemoveAt(0);
                }


                Purchase = false;
                SkillClose_Dot();
                this.gameObject.transform.GetChild(LeftRight_KeyNum).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(LeftRight_KeyNum).GetChild(2).gameObject.SetActive(true);
            }

            else if (Purchase == false)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                AfterPurchase_Window.transform.GetChild(0).gameObject.SetActive(false);
                //AfterPurchase_Window.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

                StartCoroutine(SkillHave());

            }
        }
    }


    #region 구매 후 스킬 적용
    public IEnumerator SkillHave()
    {
        if (UpDown == true && UpDown_Limit == true)
        {
            //if (Wave가 5 이상 일 경우)
            //{
            //    Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Up[0]);
            //    Skill_Manager.Inst.Skill_Up.RemoveAt(0);
            //}
            Skill_Manager.Inst.Skill_Up.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);
            UpDown_Limit = false;
            AfterPurchase_Skill.DOAnchorPos(new Vector3(-779.92f, 60.7f, 0f), 1f).SetEase(Ease.InBack);
            AfterPurchase_Skill_Box.DOAnchorPos(new Vector3(-779.92f, 60.7f, 0f), 1f).SetEase(Ease.InBack);
            yield return new WaitForSeconds(1f);
            AfterPurchase_Skill_Box.SetParent(GameObject.Find("Up").transform);
            AfterPurchase_Skill.SetParent(GameObject.Find("Up").transform);

            if (Skill_Manager.Inst.AS_Limit == true)
            {
                Basics_Skill_A.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_S.sprite = SeletSkill.Icon;

            Destroy(AfterPurchase_Skill_Box.gameObject);
            Destroy(AfterPurchase_Skill.gameObject);
        }

        else if (UpDown == false && UpDown_Limit == true)
        {
            //if (Wave가 10 이상 일 경우)
            //{
            //    Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Down[0]);
            //    Skill_Manager.Inst.Skill_Down.RemoveAt(0);
            //}

            Skill_Manager.Inst.Skill_Down.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);
            UpDown_Limit = false;
            AfterPurchase_Skill.DOAnchorPos(new Vector3(-779.92f, 76.3f, 0f), 1f).SetEase(Ease.InBack);
            AfterPurchase_Skill_Box.DOAnchorPos(new Vector3(-779.92f, 76.3f, 0f), 1f).SetEase(Ease.InBack);
            yield return new WaitForSeconds(1f);
            AfterPurchase_Skill_Box.SetParent(GameObject.Find("Down").transform);
            AfterPurchase_Skill.SetParent(GameObject.Find("Down").transform);

            if (Skill_Manager.Inst.AS_Limit_02 == true)
            {
                Basics_Skill_S.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_A.sprite = SeletSkill.Icon;
            Destroy(AfterPurchase_Skill_Box.gameObject);
            Destroy(AfterPurchase_Skill.gameObject);
        }
    }
    #endregion

    #region 스킬 구매 후 왼쪽방향 화살표
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

    #region 스킬구매 후 위,아랫 방향 화살표
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

    #region 스킬 창
    private IEnumerator SkillWindow_Coroutine()
    {
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

    private IEnumerator SkillWindowClose_Coroutine()
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
        this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    #endregion
}
