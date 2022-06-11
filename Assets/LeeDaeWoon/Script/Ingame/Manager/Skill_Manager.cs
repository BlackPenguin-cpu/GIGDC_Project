using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Skill_Manager : MonoBehaviour
{
    public static Skill_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("A스킬, S스킬")]
    public RectTransform A_Skill;
    public RectTransform S_Skill;

    [Header("A스킬 쿨타임")]
    public float A_Skill_CoolTime = 0;
    public float A_Current_CoolTime;
    public Image FillAmount_Skill_A;
    public Text A_Skill_Text;
    public GameObject A_Skill_Text_Object;
    bool isCoolDown_01 = false;

    [Header("S스킬 쿨타임")]
    public float S_Skill_CoolTime = 0;
    public float S_Current_CoolTime;
    public Image FillAmount_Skill_S;
    public Text S_Skill_Text;
    public GameObject S_Skill_Text_Object;
    bool isCoolDown_02 = false;

    [Header("A스킬, S스킬 제한")]
    public bool AS_Limit = true;
    public bool AS_Limit_02 = true;
    public bool Limit = true;

    public int RandomTest;
    private int SumPer = 0;

    [SerializeField] SkillSo SkillSo;
    [SerializeField] GameObject SkillPrefab;

    public List<Skill> Skill_Up = new List<Skill>();
    public List<Skill> Skill_Down = new List<Skill>();
    public List<Skill> Skill_Have = new List<Skill>();
    public List<Skill> Skill = new List<Skill>();
    public List<Skill> SkillBuffer = new List<Skill>();

    void Start()
    {
        FillAmount_Skill_A.fillAmount = 0f;
        AddList();
    }

    private void Update()
    {
        Skill_CoolTime_A();
        Skill_CoolTime_S();

        AS_Location();

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.P))
        {
            AddSkill();
        }
    }

    public void AddList()
    {
        for (int i = 0; i < SkillSo.Skills.Count; i++)
        {
            SkillBuffer.Add(SkillSo.Skills[i]);
        }
    }

    public int Skill_Percent(List<Skill> Percent_Skill)
    {
        //if(Wave가 5일 경우)
        //{
        foreach (Skill addper in Percent_Skill)
        {
            SumPer += addper.Percent_01;
        }
        int percent = Random.Range(1, SumPer);
        for (int i = 0; i < Percent_Skill.Count; i++)
        {
            if (percent < Percent_Skill[i].Percent_01)
            {
                return i;
            }
            percent -= Percent_Skill[i].Percent_01;
        }
        return 0;
        //}

        //if(Wave가 10일 경우)
        //{
        // 퍼센트만 바꿔주면 된다.
        //}        

        //if(Wave가 15일 경우)
        //{
        // 퍼센트만 바꿔주면 된다.
        //}
    }

    #region 스킬 소환
    public void AddSkill()
    {
        int SkillIndex = 0;
        // 스킬 소환
        Skill.Clear();
        var SkillObject = Instantiate(SkillPrefab, this.transform.position, Quaternion.identity, GameObject.Find("SkillShop_Canvas").transform);
        var card = SkillObject.GetComponent<Skill_List>();

        for (int i = 0; i < 3; i++)
        {
            RandomTest = Skill_Percent(SkillBuffer);
            Skill.Add(SkillBuffer[RandomTest]);
            card.SkillCard(Skill[i], SkillIndex++);
            SkillBuffer.RemoveAt(RandomTest);
        }

    }
    #endregion

    #region A_스킬 쿨타임
    public void Skill_CoolTime_A() // 스킬 A의 쿨타임
    {
        if (Input.GetKeyDown(KeyCode.A) && isCoolDown_01 == false && AS_Limit == true)
        {
            A_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_A.fillAmount = 1f;
            StartCoroutine(A_CoolTime());

            A_Current_CoolTime = A_Skill_CoolTime;
            A_Skill_Text.text = "" + A_Current_CoolTime;

            StartCoroutine(A_CoolTimeCounter());

            isCoolDown_01 = true;
        }

        else if (Input.GetKeyDown(KeyCode.S) && isCoolDown_01 == false && AS_Limit == false)
        {
            A_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_A.fillAmount = 1f;
            StartCoroutine(A_CoolTime());

            A_Current_CoolTime = A_Skill_CoolTime;
            A_Skill_Text.text = "" + A_Current_CoolTime;

            StartCoroutine(A_CoolTimeCounter());

            isCoolDown_01 = true;
        }
    }

    public IEnumerator A_CoolTime() // 쿨타임
    {
        while (FillAmount_Skill_A.fillAmount > 0)
        {
            FillAmount_Skill_A.fillAmount -= 1 * Time.deltaTime / A_Skill_CoolTime;
            yield return null;
        }

        isCoolDown_01 = false;
        A_Skill_Text_Object.SetActive(false);
        yield break;
    }

    public IEnumerator A_CoolTimeCounter() // 남은 쿨타임을 계산할 코르틴을 만든다.
    {
        while (A_Current_CoolTime > 0)
        {
            yield return new WaitForSeconds(1f);
            A_Current_CoolTime -= 1f;
            A_Skill_Text.text = "" + A_Current_CoolTime;
        }
        yield break;
    }
    #endregion

    #region S_스킬 쿨타임
    public void Skill_CoolTime_S() // 스킬 S의 쿨타임
    {
        if (Input.GetKeyDown(KeyCode.S) && isCoolDown_02 == false && AS_Limit_02 == true)
        {
            S_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_S.fillAmount = 1f;
            StartCoroutine(S_CoolTime());

            S_Current_CoolTime = S_Skill_CoolTime;
            S_Skill_Text.text = "" + S_Current_CoolTime;

            StartCoroutine(S_CoolTimeCounter());

            isCoolDown_02 = true;
        }

        else if (Input.GetKeyDown(KeyCode.A) && isCoolDown_02 == false && AS_Limit_02 == false)
        {
            S_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_S.fillAmount = 1f;
            StartCoroutine(S_CoolTime());

            S_Current_CoolTime = S_Skill_CoolTime;
            S_Skill_Text.text = "" + S_Current_CoolTime;

            StartCoroutine(S_CoolTimeCounter());

            isCoolDown_02 = true;
        }


    }
    public IEnumerator S_CoolTime() // 쿨타임
    {
        while (FillAmount_Skill_S.fillAmount > 0)
        {
            FillAmount_Skill_S.fillAmount -= 1 * Time.deltaTime / S_Skill_CoolTime;
            yield return null;
        }

        isCoolDown_02 = false;
        S_Skill_Text_Object.SetActive(false);
        yield break;
    }

    public IEnumerator S_CoolTimeCounter() // 남은 쿨타임을 계산할 코르틴을 만든다.
    {
        while (S_Current_CoolTime > 0)
        {
            yield return new WaitForSeconds(1f);
            S_Current_CoolTime -= 1f;
            S_Skill_Text.text = "" + S_Current_CoolTime;
        }
        yield break;
    }
    #endregion

    #region 스킬 A, S키 위치 설정
    public void AS_Location()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Skill_Change());
        }
    }

    public IEnumerator Skill_Change()
    {
        if (AS_Limit == true && Limit == true)
        {
            Limit = false;
            A_Skill.DOAnchorPos3DY(-133.78f, 0.5f);
            S_Skill.DOAnchorPos3DY(134.3f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            AS_Limit_02 = false;
            AS_Limit = false;
        }

        else if (AS_Limit == false && Limit == false)
        {
            Limit = true;
            A_Skill.DOAnchorPos3DY(0f, 0.5f);
            S_Skill.DOAnchorPos3DY(0f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            AS_Limit_02 = true;
            AS_Limit = true;
        }
    }
    #endregion
}
