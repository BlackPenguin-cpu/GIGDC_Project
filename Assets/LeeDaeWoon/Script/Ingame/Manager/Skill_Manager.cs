using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skill_Manager : MonoBehaviour
{
    public static Skill_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("A��ų, S��ų")]
    public RectTransform A_Skill = new RectTransform();
    public RectTransform S_Skill = new RectTransform();

    [Header("A��ų ��Ÿ��")]
    public float A_Skill_CoolTime = 0;
    public float A_Current_CoolTime;
    public Image FillAmount_Skill_A;
    public Text A_Skill_Text;
    public GameObject A_Skill_Text_Object;
    bool isCoolDown_01 = false;

    [Header("S��ų ��Ÿ��")]
    public float S_Skill_CoolTime = 0;
    public float S_Current_CoolTime;
    public Image FillAmount_Skill_S;
    public Text S_Skill_Text;
    public GameObject S_Skill_Text_Object;
    bool isCoolDown_02 = false;

    [Header("A��ų, S��ų ����")]
    public bool AS_Limit = true;
    public bool AS_Limit_02 = true;
    public bool Limit = true;

    [Header("��Ŭ ȹ�� üũ")]
    public Dictionary<SkillScript, bool> haveSkillInfo = new Dictionary<SkillScript, bool>();

    public int RandomTest;
    private int SumPer = 0;

    [SerializeField] SkillSo SkillSo;
    [SerializeField] GameObject SkillPrefab;

    public List<SkillScript> Skill_Up = new List<SkillScript>();
    public List<SkillScript> Skill_Down = new List<SkillScript>();
    public List<SkillScript> Skill_Have = new List<SkillScript>();
    public List<SkillScript> Skill = new List<SkillScript>();
    public List<SkillScript> Skill_Shop = new List<SkillScript>();
    public List<SkillScript> SkillBuffer = new List<SkillScript>();

    private SkillManager skillManager;

    void Start()
    {
        skillManager = SkillManager.Instance;
        FillAmount_Skill_A.fillAmount = 0f;
        AddList();
        AddSkill();
        
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
        SkillBuffer = skillManager.SkillScriptList;
    }

    public int Skill_Percent(List<SkillScript> Percent_Skill)
    {
        SumPer = 0;
        //if(Wave�� 5�� ���)
        //{
        foreach (SkillScript addper in Percent_Skill)
        {
            SumPer += (int)addper.appearChance[0];
        }
        int percent_01 = Random.Range(1, SumPer);
        for (int i = 0; i < Percent_Skill.Count; i++)
        {
            if (percent_01 < Percent_Skill[i].appearChance[0])
            {
                return i;
            }
            percent_01 -= (int)Percent_Skill[i].appearChance[0];
        }
        return 0;
        //}

        //if(Wave�� 10�� ���)
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

        //if(Wave�� 15�� ���)
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

    public void SkillHave_Check()
    {
        SkillScript[] skills = haveSkillInfo.Keys.ToArray();
        for (int i = 0; i < haveSkillInfo.Count; i++)
        {
            haveSkillInfo[skills[i]] = false;
        }

        haveSkillInfo[Skill_Up[0]] = true;
        haveSkillInfo[Skill_Down[0]] = true;
    }

    #region ��ų ��ȯ
    public void AddSkill()
    {
        if (SceneManager.GetActiveScene().name == "Dimension")
        {
            int SkillIndex = 0;
            // ��ų ��ȯ
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
    }
    #endregion

    #region A_��ų ��Ÿ��
    public void Skill_CoolTime_A() // ��ų A�� ��Ÿ��
    {
        if (Input.GetKeyDown(KeyCode.A) && isCoolDown_01 == false && AS_Limit == true)
        {
            A_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_A.fillAmount = 1f;
            StartCoroutine(A_CoolTime());

            A_Current_CoolTime = A_Skill_CoolTime;
            A_Skill_Text.text = "" + A_Current_CoolTime;

            StartCoroutine(A_CoolTimeCounter());

            skillManager.UseSkill(Skill_Up[0].name, DimensionType.OVER);
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

            Debug.Log("asd");
            isCoolDown_01 = true;
        }
    }

    public IEnumerator A_CoolTime() // ��Ÿ��
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

    public IEnumerator A_CoolTimeCounter() // ���� ��Ÿ���� ����� �ڸ�ƾ�� �����.
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

    #region S_��ų ��Ÿ��
    public void Skill_CoolTime_S() // ��ų S�� ��Ÿ��
    {
        if (Input.GetKeyDown(KeyCode.S) && isCoolDown_02 == false && AS_Limit_02 == true)
        {
            S_Skill_Text_Object.SetActive(true);
            FillAmount_Skill_S.fillAmount = 1f;
            StartCoroutine(S_CoolTime());

            S_Current_CoolTime = S_Skill_CoolTime;
            S_Skill_Text.text = "" + S_Current_CoolTime;

            skillManager.UseSkill(Skill_Down[0].name, DimensionType.UNDER);
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
    public IEnumerator S_CoolTime() // ��Ÿ��
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

    public IEnumerator S_CoolTimeCounter() // ���� ��Ÿ���� ����� �ڸ�ƾ�� �����.
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

    #region ��ų A, SŰ ��ġ ����
    public void AS_Location()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Skill_Change());
        }
    }

    public IEnumerator Skill_Change()
    {
        Skill_Up.Add(Skill_Down[0]);
        Skill_Down.Add(Skill_Up[0]);
        Skill_Up.RemoveAt(0);
        Skill_Down.RemoveAt(0);

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
