using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<BaseSkill> Skills;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ObjectPool.Instance.CreateObj(Skills[0].gameObject, new Vector3(Player.Instance.transform.position.x, 1.5f), Quaternion.identity);
        }
    }
}
