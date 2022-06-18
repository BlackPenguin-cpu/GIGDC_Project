using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Skill
{
    public string Name;
    public Sprite Icon;
    public string Explanation;
    public string CoolTime;

    public int Percent_01;
    public float Gold_01;

    public int Percent_02;
    public float Gold_02;

    public int Percent_03;
    public float Gold_03;
}

[CreateAssetMenu(fileName = "SkillSo", menuName = "Scriptable Object/SkillSo")]
public class SkillSo : ScriptableObject
{
    public List<Skill> Skills;
}
