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

    [Header("구매 후 창")]
    public RectTransform AfterPurchase_Window;
    public RectTransform AfterPurchase_LeftDirection;
    public Image AfterPurchase_Top_Light;
    public Image AfterPurchase_Bottom_Light;
    private int UpDown_Num = 0;

    private bool SkillWindow = true;
    private bool Purchase = true;
    public float LeftRight_KeyNum = 0;

    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.F) && Purchase == true)
        {
            Purchase = false;
            SkillClose_Dot();
            if (LeftRight_KeyNum == 0)
            {
                this.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            }

            else if (LeftRight_KeyNum == 1)
            {
                this.gameObject.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            }

            else if (LeftRight_KeyNum == 2)
            {
                this.gameObject.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
            }

        }
    }

    #region 스킬 구매 후 왼쪽방향 화살표
    public void AfterPurchase_Left()
    {
        StartCoroutine(AfterPurchase_Left_forward());
    }

    public IEnumerator AfterPurchase_Left_forward()
    {
        AfterPurchase_LeftDirection.DOAnchorPosX(-670, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AfterPurchase_Left_Back());
    }

    public IEnumerator AfterPurchase_Left_Back()
    {
        AfterPurchase_LeftDirection.DOAnchorPosX(-658, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AfterPurchase_Left_forward());
    }
    #endregion

    #region 스킬구매 후 윗방향 화살표
    public void AfterPurchase_Top()
    {
        if (Purchase == false)
        {
            AfterPurchase_Window.DOAnchorPosY(5f, 1f).SetEase(Ease.OutBack);
        }
    }

    public void AfterPurchase_Enter_Top()
    {
        AfterPurchase_Top_Light.DOFade(1f, 1f);
    }

    public void AfterPurchase_Exit_Top()
    {
        AfterPurchase_Top_Light.DOFade(0f, 1f);
    }
    #endregion

    #region 스킬구매 후 아랫방향 화살표
    public void AfterPurchase_Bottom()
    {
        if (Purchase == false)
        {
            AfterPurchase_Window.DOAnchorPosY(-146f, 1f).SetEase(Ease.OutBack);
        }
    }

    public void AfterPurchase_Enter_Bottom()
    {
        AfterPurchase_Bottom_Light.DOFade(1f, 1f);
    }

    public void AfterPurchase_Exit_Bottom()
    {
        AfterPurchase_Bottom_Light.DOFade(0f, 1f);
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
