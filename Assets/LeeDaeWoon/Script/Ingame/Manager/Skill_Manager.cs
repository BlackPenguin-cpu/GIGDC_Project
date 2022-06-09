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
    bool isCoolDown_01 = false;
    public float A_Skill_CoolTime = 0;
    public float EX_A_Skill_CoolTime;
    public Image FillAmount_Skill_A;
    public Text A_Skill_Text;

    [Header("S스킬 쿨타임")]
    bool isCoolDown_02 = false;
    public float S_Skill_CoolTime = 0;
    public Image FillAmount_Skill_S;
    public Text S_Skill_Text;

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

    public void Skill_CoolTime_A()
    {
        if (Input.GetKeyDown(KeyCode.A) && isCoolDown_01 == false && AS_Limit == true)
        {
            isCoolDown_01 = true;
            FillAmount_Skill_A.fillAmount = 1f;
        }

        else if (Input.GetKeyDown(KeyCode.S) && isCoolDown_01 == false && AS_Limit == false)
        {
            isCoolDown_01 = true;
            FillAmount_Skill_A.fillAmount = 1f;
        }

        if (isCoolDown_01)
        {
            FillAmount_Skill_A.fillAmount -= 1 / A_Skill_CoolTime * Time.deltaTime;
            if (FillAmount_Skill_A.fillAmount <= 0)
            {
                FillAmount_Skill_A.fillAmount = 0;
                isCoolDown_01 = false;
            }
        }
    }

    public void Skill_CoolTime_S()
    {
        if (Input.GetKeyDown(KeyCode.S) && isCoolDown_02 == false && AS_Limit_02 == true)
        {
            isCoolDown_02 = true;
            FillAmount_Skill_S.fillAmount = 1f;
        }

        else if (Input.GetKeyDown(KeyCode.A) && isCoolDown_02 == false && AS_Limit_02 == false)
        {
            isCoolDown_02 = true;
            FillAmount_Skill_S.fillAmount = 1f;
        }

        if (isCoolDown_02)
        {
            FillAmount_Skill_S.fillAmount -= 1 / S_Skill_CoolTime * Time.deltaTime;
            if (FillAmount_Skill_S.fillAmount <= 0)
            {
                FillAmount_Skill_S.fillAmount = 0;
                isCoolDown_02 = false;
            }
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
            A_Skill.DOAnchorPos3DY(-133.78f, 1f).SetEase(Ease.InOutBack);
            S_Skill.DOAnchorPos3DY(134.3f, 1f).SetEase(Ease.InOutBack);
            yield return new WaitForSeconds(1f);
            AS_Limit_02 = false;
            AS_Limit = false;
        }

        else if (AS_Limit == false && Limit == false)
        {
            Limit = true;
            A_Skill.DOAnchorPos3DY(0, 1f).SetEase(Ease.InOutBack);
            S_Skill.DOAnchorPos3DY(0f, 1f).SetEase(Ease.InOutBack);
            yield return new WaitForSeconds(1f);
            AS_Limit_02 = true;
            AS_Limit = true;
        }
    }
    #endregion
}
