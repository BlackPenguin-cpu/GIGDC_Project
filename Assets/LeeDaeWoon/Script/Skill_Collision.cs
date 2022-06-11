using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Collision : MonoBehaviour
{
    public int LeftRight_Nun;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Skill_Window.Inst.Purchase == true && Skill_Window.Inst.SkillWindow == false)
        {
            Skill_Window.Inst.SkillClose_Dot();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Skill_Window.Inst.Purchase == true && Skill_Window.Inst.SkillWindow == true)
        {
            Skill_Window.Inst.SkillNum = LeftRight_Nun;
            Skill_List.Inst.Skill_Num(LeftRight_Nun);
            Skill_Window.Inst.Skill_Window_Active();
            StartCoroutine(Skill_Window.Inst.SkillWindow_Coroutine());
        }
    }
}
