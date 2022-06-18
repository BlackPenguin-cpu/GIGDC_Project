using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_List : MonoBehaviour
{
    public static Skill_List Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("왼쪽 스킬")]
    public Image Left_Skill_Icon;
    public Text Left_Name;
    public Text Left_CoolTime;
    public Text Left_Explanation;
    public float Left_Gold;
    public Text Left_Gold_01;
    public Text Left_Gold_02;
    public Text Left_Gold_03;

    [Header("가운데 스킬")]
    public Image Among_Skill_Icon;
    public Text Among_Name;
    public Text Among_CoolTime;
    public Text Among_Explanation;
    public float Among_Gold;
    public Text Among_Gold_01;
    public Text Among_Gold_02;
    public Text Among_Gold_03;

    [Header("오른쪽 스킬")]
    public Image Right_Skill_Icon;
    public Text Right_Name;
    public Text Right_CoolTime;
    public Text Right_Explanation;
    public float Right_Gold;
    public Text Right_Gold_01;
    public Text Right_Gold_02;
    public Text Right_Gold_03;

    public Skill Left_Skill;
    public Skill Among_Skill;
    public Skill Right_Skill;
    void Start()
    {

    }

    public void Skill_Num(int i)
    {
        if (i == 0)
        {
            Left_Name.text = this.Left_Skill.Name;
            Left_CoolTime.text = this.Left_Skill.CoolTime;
            Left_Explanation.text = this.Left_Skill.Explanation;
        }

        else if (i == 1)
        {
            Among_Name.text = this.Among_Skill.Name;
            Among_CoolTime.text = this.Among_Skill.CoolTime;
            Among_Explanation.text = this.Among_Skill.Explanation;
        }

        else if (i == 2)
        {
            Right_Name.text = this.Right_Skill.Name;
            Right_CoolTime.text = this.Right_Skill.CoolTime;
            Right_Explanation.text = this.Right_Skill.Explanation;
        }

        return;
    }
    void Update()
    {

    }

    public void SkillCard(Skill skill, int skillIndex)
    {
        switch (skillIndex)
        {
            case 0:
                this.Left_Skill = skill;
                Left_Name.text = this.Left_Skill.Name;
                Left_CoolTime.text = this.Left_Skill.CoolTime;
                Left_Explanation.text = this.Left_Skill.Explanation;
                //if (Wave가 5일 경우)
                //{
                    Left_Gold = this.Left_Skill.Gold_01;
                    Left_Gold_01.text = "" + Left_Gold;
                //}
                //if (Wave가 10일 경우)
                //{
                //  Left_Gold = this.Left_Skill.Gold_02;
                //  Left_Gold_02.text = "" + Left_Gold;
                //}
                //if (Wave가 15일 경우)
                //{
                //  Left_Gold = this.Left_Skill.Gold_03;
                //  Left_Gold_03.text = "" + Left_Gold;
                //}
                Left_Skill_Icon.sprite = this.Left_Skill.Icon;
                break;

            case 1:
                this.Among_Skill = skill;

                Among_Name.text = this.Among_Skill.Name;
                Among_CoolTime.text = this.Among_Skill.CoolTime;
                Among_Explanation.text = this.Among_Skill.Explanation;
                //if (Wave가 5일 경우)
                //{
                    Among_Gold = this.Among_Skill.Gold_01;
                    Among_Gold_01.text = "" + Among_Gold;
                //}
                //if (Wave가 10일 경우)
                //{
                //  Among_Gold = this.Among_Skill.Gold_02;
                //  Among_Gold_02.text = "" + Among_Gold;
                //}
                //if (Wave가 15일 경우)
                //{
                //  Among_Gold = this.Among_Skill.Gold_03;
                //  Among_Gold_03.text = "" + Among_Gold;
                //}
                Among_Skill_Icon.sprite = this.Among_Skill.Icon;
                break;

            case 2:
                this.Right_Skill = skill;
                Right_Name.text = this.Right_Skill.Name;
                Right_CoolTime.text = this.Right_Skill.CoolTime;
                Right_Explanation.text = this.Right_Skill.Explanation;
                //if (Wave가 5일 경우)
                //{
                    Right_Gold = this.Right_Skill.Gold_01;
                    Right_Gold_01.text = "" + Right_Gold;
                //}
                //if (Wave가 10일 경우)
                //{
                //  Right_Gold = this.Right_Skill.Gold_02;
                //  Right_Gold_02.text = "" + Right_Gold;
                //}
                //if (Wave가 15일 경우)
                //{
                //  Right_Gold = this.Right_Skill.Gold_03;
                //  Right_Gold_03.text = "" + Right_Gold;
                //}

                Right_Skill_Icon.sprite = this.Right_Skill.Icon;
                break;

        }
    }
}
