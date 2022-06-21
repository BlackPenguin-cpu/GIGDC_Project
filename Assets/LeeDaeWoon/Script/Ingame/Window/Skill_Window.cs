using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skill_Window : MonoBehaviour
{
    public static Skill_Window Inst { get; private set; }

    [Header("스킬창 시간")]
    public float Timer = 0;

    [Header("스킬 창")]
    public RectTransform Pole_01 = new RectTransform();
    public RectTransform Pole_02 = new RectTransform();
    public RectTransform Skill_RectTransform = new RectTransform();

    [Header("기본 스킬 이미지")]
    public Image Basics_Skill_A;
    public Image Basics_Skill_S;

    [Header("구매 후 창")]
    public GameObject AfterPurchase_Window_Prefab; // 스킬 적용 창 프리팹
    public GameObject AfterPurchase_Key; // 선택 키 오브젝트


    public GameObject AfterPurchase_Skill; // 스킬 적용하기 전 스킬 이미지
    public GameObject AfterPurchase_Window; // 스킬적용 창
    public GameObject AfterPurchase_Skill_Box; // 스킬 적용하기 전 스킬박스 이미지
    public GameObject AfterPurchase_LeftDirection; // 왼쪽 화살표
/*  public RectTransform AfterPurchase_Skill = new RectTransform(); // 스킬 적용하기 전 스킬 이미지
    public RectTransform AfterPurchase_Window = new RectTransform(); // 스킬적용 창
    public RectTransform AfterPurchase_Skill_Box = new RectTransform(); // 스킬 적용하기 전 스킬박스 이미지
    public RectTransform AfterPurchase_LeftDirection = new RectTransform(); // 왼쪽 화살표*/

    [Header("스킬 좌표")]
    [SerializeField] GameObject Skill_Shop;

    //public Image AfterPurchase_Top_Light;
    //public Image AfterPurchase_Bottom_Light;

    public GameObject Save_Clone;

    public int SkillNum; // 현재 몇 번째 구매 스킬과 충돌했는지 숫자 확인
    public bool UpDown = true; // 현재 위 인지 아래 인지 확인
    public bool Purchase = true; // 현재 구매중인지 아닌지 확인
    public bool SkillWindow = true; // 스킬 창이 나오는지 확인
    public bool UpDown_Limit = true; // 위아래 제한
    public bool SkillColider_Check; // 현재 구매 스킬들과 충돌 했는지 체크 확인

    public int RandomTest;

    public bool MoreThanOnce_Purchase = true; // 1번 이상 스킬을 구매할 시
    private bool UP_MoreThanOnce_Purchase = true; // 윗 스킬에 1번 이상 스킬을 적용할 시
    private bool Down_MoreThanOnce_Purchase = true; // 아랫 스킬에 1번 이상 스킬을 적용할 시

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

        // 게임이 시작할 때 오브젝트의 3번째 자식(스킬 창)을 꺼준다.
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
        // 월드 좌표를 스크린 좌표로 변경을 해준다.
        transform.localPosition = Camera.main.WorldToScreenPoint(Skill_Shop.gameObject.transform.position + new Vector3(-17.5f, -5, 0));
    }

    public void Skill_Window_Active()
    {
        // 이 스크립트가 들어가 있는 오브젝트의 3번째 자식(스킬 창)을 켜준다.
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    public void Skill_Purchase()
    {
        // F키를 통하여 구매 혹은 스킬적용을 할 수 있다.
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 스킬구매
            if (Purchase == true && SkillColider_Check == true && (UI_Manager.Inst.Gold >= Skill_List.Inst.Left_Gold || UI_Manager.Inst.Gold >= Skill_List.Inst.Among_Gold || UI_Manager.Inst.Gold >= Skill_List.Inst.Right_Gold))
            {
                SeletSkill = Skill_Manager.Inst.Skill[SkillNum];
                AfterPurchase_Skill.GetComponent<Image>().sprite = SeletSkill.Icon;

                //if (Wave가 5일 경우)
                //{
                UI_Manager.Inst.Gold -= SeletSkill.Gold_01;
                //}
                //else if (Wave가 10일 경우)
                //{
                //  UI_Manager.Inst.Gold -= SeletSkill.Gold_02;
                //}
                //else if (Wave가 15일 경우)
                //{
                //  UI_Manager.Inst.Gold -= SeletSkill.Gold_03;
                //}

                Skill_Manager.Inst.Skill_Have.Add(SeletSkill);
                Skill_Manager.Inst.Skill_Shop.Add(SeletSkill);

                Purchase = false; // 이것을 통하여 스킬구매 -> 스킬적용으로 넘겨준다.
                SkillClose_Dot(); // 스킬 창을 닫아준다.

                this.gameObject.transform.GetChild(SkillNum).GetChild(3).gameObject.SetActive(false);
                this.gameObject.transform.GetChild(SkillNum).GetChild(2).gameObject.SetActive(true);
            }

            // 스킬적용
            else if (Purchase == false)
            {
                AfterPurchase_Key.gameObject.SetActive(false);
                StartCoroutine(SkillHave()); // SkillHave 코루틴을 실행시킨다.
                Purchase = true; // 이것을 통하여 스킬적용 -> 스킬구매로 넘겨준다.
            }
        }
    }

   
    #region 구매 후 스킬 적용
    public IEnumerator SkillHave()
    {
        // 윗 부분에 스킬을 적용할려 할 떄
        if (UpDown == true && UpDown_Limit == true)
        {
            UpDown_Limit = false;

            // 윗 부분에 1개 이상의 스킬을 적용을 할 때 적용하기 전의 스킬은 다시 상점으로 넘어간다.
            if (UP_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Up[0]);
                Skill_Manager.Inst.Skill_Up.RemoveAt(0);
            }

            // 구매한 스킬을 윗 부분에 넣어준다.
            Skill_Manager.Inst.Skill_Up.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);

            Vector3[] SaveSkillPos = new Vector3[2];
            SaveSkillPos[0] = AfterPurchase_Skill.transform.position;
            SaveSkillPos[1] = AfterPurchase_Skill_Box.transform.position;

            //스킬 적용 애니메이션
            AfterPurchase_Skill.transform.DOLocalMove(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.transform.DOLocalMove(new Vector3(-779.92f, 60.7f, 0f), 0.5f).SetEase(Ease.InOutQuad);

            yield return new WaitForSeconds(0.5f);

            // AS_Limit = Shift를 통한 스킬 전환 체크
            if (Skill_Manager.Inst.AS_Limit == true) // true일 경우 A스킬에 구매한 스킬을 적용시킨다.
            {
                Basics_Skill_A.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_S.sprite = SeletSkill.Icon; // false일 경우 S스킬에 구매한 스킬을 적용시킨다.

            // 한 번 미만 스킬을 적용시킬 시 실행시킨다.
            AfterPurchase_Skill.transform.position = SaveSkillPos[0];
            AfterPurchase_Skill_Box.transform.position = SaveSkillPos[1];
            AfterPurchase_Key.gameObject.SetActive(true);
            if (MoreThanOnce_Purchase == true)
            {
                AfterPurchase_Window.SetActive(false);
                MoreThanOnce_Purchase = false;
                UP_MoreThanOnce_Purchase = false;
            }

            // 한 번 이상 스킬을 적용시킬 시 실행시킨다.
            else
            {
                AfterPurchase_Window.SetActive(false);
            }
            UpDown_Limit = true;
        }

        // 아랫 부분에 스킬을 적용할려 할 떄
        else if (UpDown == false && UpDown_Limit == true)
        {
            UpDown_Limit = false;

            // 윗 부분에 1개 이상의 스킬을 적용을 할 때 적용하기 전의 스킬은 다시 상점으로 넘어간다.
            if (Down_MoreThanOnce_Purchase == false)
            {
                Skill_Manager.Inst.SkillBuffer.Add(Skill_Manager.Inst.Skill_Down[0]);
                Skill_Manager.Inst.Skill_Down.RemoveAt(0);
            }

            // 구매한 스킬을 아랫 부분에 넣어준다.
            Skill_Manager.Inst.Skill_Down.Add(Skill_Manager.Inst.Skill_Have[0]);
            Skill_Manager.Inst.Skill_Have.RemoveAt(0);

            Vector3[] SaveSkillPos = new Vector3[2];
            SaveSkillPos[0] = AfterPurchase_Skill.transform.position;
            SaveSkillPos[1] = AfterPurchase_Skill_Box.transform.position;

            //스킬 적용 애니메이션
            AfterPurchase_Skill.transform.DOLocalMove(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);
            AfterPurchase_Skill_Box.transform.DOLocalMove(new Vector3(-779.92f, 76.3f, 0f), 0.5f).SetEase(Ease.InOutQuad);

            yield return new WaitForSeconds(0.5f);

            // AS_Limit = Shift를 통한 스킬 전환 체크
            if (Skill_Manager.Inst.AS_Limit_02 == true) // true일 경우 S스킬에 구매한 스킬을 적용시킨다.
            {
                Basics_Skill_S.sprite = SeletSkill.Icon;
            }
            else Basics_Skill_A.sprite = SeletSkill.Icon;

            // 한 번 미만 스킬을 적용시킬 시 실행시킨다.
            AfterPurchase_Skill.transform.position = SaveSkillPos[0];
            AfterPurchase_Skill_Box.transform.position = SaveSkillPos[1];
            AfterPurchase_Key.gameObject.SetActive(true);
            if (MoreThanOnce_Purchase == true)
            {
                AfterPurchase_Window.SetActive(false);
                MoreThanOnce_Purchase = false;
                Down_MoreThanOnce_Purchase = false;
            }
            // 한 번 이상 스킬을 적용시킬 시 실행시킨다.
            else
            {
                AfterPurchase_Window.SetActive(false);
            }
            UpDown_Limit = true;
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

    #region 스킬구매 후 위,아랫 방향 화살표
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

    #region 스킬 창

    public void SkillClose_Dot()
    {
        // 스킬 창을 닫아주는 함수
        Skill_RectTransform.DOAnchorPosY(226.43f, 0.5f);
        Pole_02.DOAnchorPosY(202.92f, 0.5f);
        StartCoroutine(SkillWindowClose_Coroutine());
    }

    public IEnumerator SkillWindow_Coroutine()
    {
        // 스킬 창을 열어주는 코루틴
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
        // 스킬 창을 닫아주는 코루틴

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
