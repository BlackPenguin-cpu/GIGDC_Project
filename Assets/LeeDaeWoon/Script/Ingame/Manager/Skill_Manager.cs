using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour
{
    public static Skill_Manager Inst { get; private set; }
    void Awake() => Inst = this;

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
        AddList();
    }

    private void Update()
    {
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
}
