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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null ) && Skill_Window.Inst.Purchase == true && Skill_Window.Inst.SkillWindow == true)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
            Skill_Window.Inst.SkillColider_Check = true;
            Skill_Window.Inst.SkillNum = LeftRight_Nun;
            Skill_List.Inst.Skill_Num(LeftRight_Nun);
            StartCoroutine(Skill_Window.Inst.SkillWindow_Coroutine());
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null) && Skill_Window.Inst.Purchase == true && Skill_Window.Inst.SkillWindow == false)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
            Skill_Window.Inst.SkillColider_Check = false;
            StartCoroutine(Skill_Window.Inst.SkillWindowClose_Coroutine());
        }
    }

}
