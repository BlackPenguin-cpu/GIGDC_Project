using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skill_Window : MonoBehaviour
{
    [Header("스킬창 시간")]
    public float Timer = 0;

    [Header("스킬 창")]
    public GameObject Skill_Shop;
    public RectTransform Skill_RectTransform;
    public RectTransform Pole_02;

    private float SkillWindow_Num = 0;

    void Start()
    {

    }

    void Update()
    {
        Skill_Dot();
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Skill_Shop.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Skill_Shop.activeSelf == true)
            {
                SkillClose_Dot();
                Skill_Shop.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                Skill_Shop.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            }

        }
    }

    #region 스킬 창

    public void Skill_Dot()
    {
        if (Skill_Shop.activeSelf == true && SkillWindow_Num == 0)
        {
            SkillWindow_Num += 1;
            Skill_RectTransform.DOAnchorPosY(32.973f, 0.5f);
            Pole_02.DOAnchorPosY(-176.01f, 0.5f);
            StartCoroutine(SkillWindow_Coroutine());
        }
    }

    public void SkillClose_Dot()
    {
        Skill_RectTransform.DOAnchorPosY(226.43f, 0.5f);
        Pole_02.DOAnchorPosY(202.92f, 0.5f);
        StartCoroutine(SkillWindowClose_Coroutine());
    }

    private IEnumerator SkillWindow_Coroutine()
    {
        Timer = 0;
        while (Timer < 1)
        {
            Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(5.9433f, 392.86f, Timer));
            Timer += Time.deltaTime * 3f;
            yield return null;
        }
    }

    private IEnumerator SkillWindowClose_Coroutine()
    {
        Timer = 0;
        while (Timer < 1)
        {
            Skill_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(392.86f, 5.9433f, Timer));
            Timer += Time.deltaTime * 3f;
            yield return null;
        }
        Skill_Shop.transform.GetChild(3).gameObject.SetActive(false);
    }

    #endregion
}
