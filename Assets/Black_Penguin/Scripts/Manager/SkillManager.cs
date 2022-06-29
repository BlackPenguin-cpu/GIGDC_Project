using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    public Dictionary<string, BaseSkill> SkillList = new Dictionary<string, BaseSkill>();

    private Player player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = Player.Instance;
        BaseSkill[] Skills = Resources.LoadAll<BaseSkill>("Skills/SkillObj/");

        foreach (BaseSkill skill in Skills)
        {
            SkillList[skill.name] = skill;
        }
    }
    
    public void UseSkill(string name, DimensionType dimensionType)
    {
        BaseSkill skill = SkillList[name];
        ObjectPool.Instance.CreateObj
            (skill.gameObject, new Vector3(player.transform.position.x, skill.StartPosY * (dimensionType == DimensionType.OVER ? 1 : -1)), Quaternion.identity)
            .GetComponent<BaseSkill>().dimensionType = dimensionType;
    }

}
