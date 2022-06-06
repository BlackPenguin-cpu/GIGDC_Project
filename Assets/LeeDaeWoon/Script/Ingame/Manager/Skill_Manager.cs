using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour
{
    public static Skill_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    private int RandomMix;

    [SerializeField] SkillSo SkillSo;
    [SerializeField] GameObject SkillPrefab;

    List<Skill> SkillBuffer = new List<Skill>();

    void Start()
    {
        AddList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
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
        int percent = Random.Range(0, 61);
        for (int i = 0; i < Percent_Skill.Count; i++)
        {
            if (percent < Percent_Skill[i].Percent_01)
            {
                return i;
            }
            percent -= Percent_Skill[i].Percent_01;
        }
        return 0;
    }

    public void AddSkill()
    {
        int SkillIndex = 0;
        List<Skill> Skill = new List<Skill>();
        // 스킬 소환
        var SkillObject = Instantiate(SkillPrefab, this.transform.position, Quaternion.identity, GameObject.Find("SkillShop_Canvas").transform);
        var card = SkillObject.GetComponent<Skill_List>();

        for (int i = 0; i < 3; i++)
        {
            int RandomTest = Skill_Percent(SkillBuffer);
            for (int j = 0; j < Skill.Count; j++)
            {
                while (Skill[j] == SkillBuffer[RandomTest])
                {
                    RandomTest = Skill_Percent(SkillBuffer);
                }
            }
            Skill.Add(SkillBuffer[RandomTest]);
            card.SkillCard(SkillBuffer[RandomTest], SkillIndex++);
            // 아이템 클릭 시 if문 달아주기
            SkillBuffer.RemoveAt(RandomTest);
        }
    }
}
