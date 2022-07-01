using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;
    public List<SkillScript> SkillScriptList = new List<SkillScript>();
    public Dictionary<string, BaseSkill> SkillList = new Dictionary<string, BaseSkill>();
    public Dictionary<string, float> SkillsCooldown = new Dictionary<string, float>();

    private Skill_Manager skillManager;
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
        skillManager = Skill_Manager.Inst;
        player = Player.Instance;
        BaseSkill[] Skills = Resources.LoadAll<BaseSkill>("Skills/SkillObj/");

        foreach (BaseSkill skill in Skills)
        {
            SkillList.Add(skill.name, skill);
            SkillsCooldown.Add(skill.name, 0);
        }
    }
    private void Update()
    {
        if (SkillsCooldown.ContainsKey(skillManager.Skill_Up[0].name))
            SkillsCooldown[skillManager.Skill_Up[0].name] -= Time.deltaTime;

        if (SkillsCooldown.ContainsKey(skillManager.Skill_Down[0].name))
            SkillsCooldown[skillManager.Skill_Down[0].name] -= Time.deltaTime;

        //������ ġƮŰ
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill("ZeusFury", DimensionType.OVER);
        }
    }

    //TODO: ��ų ��Ʈ���� ����ִ� Ŭ���� or ����ü�� ����� ��Ʈ������ �ִ� �μ��� �ּ�ȭ ��Ű��
    public void UseSkill(string name, DimensionType dimensionType)
    {
        BaseSkill skill = SkillList[name];
        if (SkillsCooldown.TryGetValue(name, out float cooldown) && cooldown < skill.SkillInfo._cooldown)
        {
            SkillsCooldown[name] = SkillList[name].SkillInfo._cooldown;
            ObjectPool.Instance.CreateObj
                (skill.gameObject, new Vector3(player.transform.position.x, skill.StartPosY * (dimensionType == DimensionType.OVER ? 1 : -1)), Quaternion.identity)
                .GetComponent<BaseSkill>().dimensionType = dimensionType;
        }
        Debug.Log($"�߸��� �̸�:{name} ��Ÿ��:{cooldown}");
    }

}
