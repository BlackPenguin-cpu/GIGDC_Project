using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillScriptableObject", menuName = "Skill/SkillScriptableObject", order = 0)]
[System.Serializable]
public class SkillScript : ScriptableObject
{
    private Player player;

    public Sprite sprite;
    public string SkillName; 
    [TextArea]
    public string Description;
    /// <summary>
    /// 레벨마다 다른 가격을 표기
    /// </summary>
    public float[] price = new float[3];

    /// <summary>
    /// 데미지 배울 
    /// </summary>
    public float damagePercent;
    [SerializeField] private float cooldown;
    public float _cooldown
    {
        get
        {
            return cooldown * (1 - player.stat._cooldown);
        }
        set { cooldown = value; }
    }
    public float[] appearChance = new float[3];
    private void Awake()
    {
        player = Player.Instance;
    }
}
