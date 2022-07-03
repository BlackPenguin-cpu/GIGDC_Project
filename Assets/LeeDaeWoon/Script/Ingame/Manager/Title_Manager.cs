using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Title_Manager : MonoBehaviour
{
    [Header("타이틀")]
    public GameObject Title_Logo;
    public GameObject Title_Circle01;
    public GameObject Title_Circle02;
    public Text Fade_Text;

    public Image Team_BackGround;
    private bool Team_BackGround_Check;
    //bool MoveMent_Check = true;

    void Start()
    {
        StartCoroutine(TeamLogo_BackGround());
    }

    void Update()
    {
        if (Input.anyKeyDown)
            StartCoroutine(Change_Scene());
    }

    private void Awake()
    {
        Sart_Coroutine();
    }

    public void Sart_Coroutine()
    {
        StartCoroutine(Circle01());
        StartCoroutine(FadeText_Full());
    }

    public IEnumerator Change_Scene()
    {
        if (Team_BackGround_Check == true)
        {
            DOTween.PauseAll();
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("Main");
        }

    }

    #region 타이틀 원
    public IEnumerator Circle01()
    {
        Title_Circle01.transform.DOLocalMoveY(327f, 3f).SetEase(Ease.InOutCubic);
        Title_Circle02.transform.DOLocalMoveY(-327f, 3f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Circle02());
    }

    public IEnumerator Circle02()
    {
        Title_Circle01.transform.DOLocalMoveY(142f, 3f).SetEase(Ease.InOutCubic);
        Title_Circle02.transform.DOLocalMoveY(-142f, 3f).SetEase(Ease.InOutCubic);
        yield return new WaitForSeconds(3f);
        StartCoroutine(Circle01());
    }
    #endregion

    #region FadeInOut
    public IEnumerator FadeText_Full()
    {
        Fade_Text.DOFade(0f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeText_Zero());
    }

    public IEnumerator FadeText_Zero()
    {
        Fade_Text.DOFade(1f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeText_Full());
    }
    #endregion

    #region 팀 배경
    public IEnumerator TeamLogo_BackGround()
    {
        yield return new WaitForSeconds(3f);
        Team_BackGround.DOFade(0f, 3f);
        yield return new WaitForSeconds(4f);
        Team_BackGround_Check = true;
    }
    #endregion
}
