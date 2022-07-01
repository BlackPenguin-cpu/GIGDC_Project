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
    public RectTransform A_Skill = new RectTransform();
    public RectTransform S_Skill = new RectTransform();

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

    [Header("스클 획득 체크")]
    public bool Have_MagicTurret;
    public bool Have_DeathStrom;
    public bool Have_SolarGodLightt;
    public bool Have_GodOfGockGang_E;
    public bool Have_Jeany;
    //public bool Have_MagicTurret; // 혹한기
    public bool Have_AtemHands;
    public bool Have_ZeusFury;
    //public bool Have_MagicTurret; // 영혼 거두기
    //public bool Have_MagicTurret; // 대마법사 유물
    public bool Have_LonginusSpear;
    public bool Have_SpaceBang;

    public int RandomTest;
    private int SumPer = 0;

    [SerializeField] SkillSo SkillSo;
    [SerializeField] GameObject SkillPrefab;

    public List<Skill> Skill_Up = new List<Skill>();
    public List<Skill> Skill_Down = new List<Skill>();
    public List<Skill> Skill_Have = new List<Skill>();
    public List<Skill> Skill = new List<Skill>();
    public List<Skill> Skill_Shop = new List<Skill>();
    public List<Skill> SkillBuffer = new List<Skill>();

    void Start()
    {
        FillAmount_Skill_A.fillAmount = 0f;
        AddList();
        AddSkill();

        Skill_Up.Add(SkillSo.Skills[10]);
        Skill_Down.Add(SkillSo.Skills[11]);
    }

    private void Update()
    {
        Skill_CoolTime_A();
        Skill_CoolTime_S();
        SkillHave_Check();
        AS_Location();
    }

    public void AddList()
    {
        for (int i = 0; i < SkillSo.Skills.Count; i++)
            SkillBuffer.Add(SkillSo.Skills[i]);
    }

    public int Skill_Percent(List<Skill> Percent_Skill)
    {
        SumPer = 0;
        //if(Wave가 5일 경우)
        //{
        foreach (Skill addper in Percent_Skill)
        {
            SumPer += addper.Percent_01;
        }
        int percent_01 = Random.Range(1, SumPer);
        for (int i = 0; i < Percent_Skill.Count; i++)
        {
            if (percent_01 < Percent_Skill[i].Percent_01)
            {
                return i;
            }
            percent_01 -= Percent_Skill[i].Percent_01;
        }
        return 0;
        //}

        //if(Wave가 10일 경우)
        //{
        //foreach (Skill addper in Percent_Skill)
        //{
        //    SumPer += addper.Percent_02;


        //}
        //int percent_02 = Random.Range(1, SumPer);
        //for (int i = 0; i < percent_skill.Count; i++)
        //{
        //    if (percent_02 < Percent_Skill[i].Percent_02)
        //    {
        //        return i;
        //    }
        //    percent_02 -= Percent_Skill[i].Percent_02;
        //}
        //return 0;
        //}        

            //if(Wave가 15일 경우)
            //{
            //foreach (Skill addper in Percent_Skill)
            //{
            //    SumPer += addper.Percent_03;
            //}
            //int percent_03 = Random.Range(1, SumPer);
            //for (int i = 0; i < Percent_Skill.Count; i++)
            //{
            //    if (percent_03 < Percent_Skill[i].Percent_03)
            //    {
            //        return i;
            //    }
            //    percent_03 -= Percent_Skill[i].Percent_03;
            //}
            //return 0;
            //}
    }

    #region 스킬 획득 확인
    public void SkillHave_Check()
    {
        #region 마법포탑
        if (Skill_Up.Contains(SkillSo.Skills[0]) || Skill_Down.Contains(SkillSo.Skills[0]))
            Have_MagicTurret = true;
        else
            Have_MagicTurret = false;
        #endregion
        #region 죽음의 태풍
        if (Skill_Up.Contains(SkillSo.Skills[1]) || Skill_Down.Contains(SkillSo.Skills[1]))
            Have_DeathStrom = true;
        else
            Have_DeathStrom = false;
        #endregion
        #region 태양신의 빛
        if (Skill_Up.Contains(SkillSo.Skills[2]) || Skill_Down.Contains(SkillSo.Skills[2]))
            Have_SolarGodLightt = true;
        else
            Have_SolarGodLightt = false;
        #endregion
        #region 신의 곡괭이
        if (Skill_Up.Contains(SkillSo.Skills[3]) || Skill_Down.Contains(SkillSo.Skills[3]))
            Have_GodOfGockGang_E = true;
        else
            Have_GodOfGockGang_E = false;
        #endregion
        #region 지니의 마법
        if (Skill_Up.Contains(SkillSo.Skills[4]) || Skill_Down.Contains(SkillSo.Skills[4]))
            Have_Jeany = true;
        else
            Have_Jeany = false;
        #endregion
        #region 혹한기
        //if (Skill_Up.Contains(SkillSo.Skills[5]) || Skill_Down.Contains(SkillSo.Skills[5]))
        //    Have_LonginusSpear = true;
        //else
        //    Have_LonginusSpear = false;
        #endregion
        #region 명계의 손길
        if (Skill_Up.Contains(SkillSo.Skills[6]) || Skill_Down.Contains(SkillSo.Skills[6]))
            Have_AtemHands = true;
        else
            Have_AtemHands = false;
        #endregion
        #region 제우스의 천벌
        if (Skill_Up.Contains(SkillSo.Skills[7]) || Skill_Down.Contains(SkillSo.Skills[7]))
            Have_ZeusFury = true;
        else
            Have_ZeusFury = false;

        #endregion
        #region 영혼 거두기
        //if (Skill_Up.Contains(SkillSo.Skills[8]) || Skill_Down.Contains(SkillSo.Skills[8]))
        //    Have_LonginusSpear = true;
        //else
        //    Have_LonginusSpear = false;
        #endregion
        #region 대마법사의 유물
        if (Skill_Up.Contains(SkillSo.Skills[9]) || Skill_Down.Contains(SkillSo.Skills[9]))
            Have_LonginusSpear = true;
        else
            Have_LonginusSpear = false;
        #endregion
        #region 롱기누스의 창
        if (Skill_Up.Contains(SkillSo.Skills[10]) || Skill_Down.Contains(SkillSo.Skills[10]))
            Have_LonginusSpear = true;
        else
            Have_LonginusSpear = false;
        #endregion
        #region SpaceBang
        if (Skill_Up.Contains(SkillSo.Skills[11]) == false || Skill_Down.Contains(SkillSo.Skills[11]))
            Have_SpaceBang = true;
        else
            Have_SpaceBang = false;
        #endregion 
    }
    #endregion

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
