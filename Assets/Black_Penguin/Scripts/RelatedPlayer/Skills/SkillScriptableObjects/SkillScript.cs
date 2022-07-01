using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillScriptableObject", menuName = "Skill/SkillScriptableObject", order = 0)]
[System.Serializable]
public class SkillScript : ScriptableObject
{
    public Sprite sprite;
    public string SkillName;
    [TextArea]
    public string Description;
    /// <summary>
    /// �������� �ٸ� ������ ǥ��
    /// </summary>
    public float[] price = new float[3];

    /// <summary>
    /// ������ ��� 
    /// </summary>
    public float damagePercent;
    public float originalCooldown;
    public float _cooldown
    {
        get
        {
            return originalCooldown * (1 - Player.Instance.stat._cooldown);
        }
        set { originalCooldown = value; }
    }
    public float[] appearChance = new float[3];
}
