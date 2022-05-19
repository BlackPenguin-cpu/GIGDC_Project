using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Click : MonoBehaviour
{
    [Header("�ӵ�")]
    public float Speed = 1f;
    public float timer = 0f;

    [Header("â ���� ������Ʈ")]
    public GameObject Pole_01;
    public GameObject Pole_02;
    public RectTransform Window;

    void Start()
    {

    }

    void Update()
    {
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Main");
    }

    #region ���ΰ� ����
    public void TeamLogo_Click()
    {
        timer = 0;
        transform.GetChild(2).gameObject.SetActive(true);
        Pole_01.transform.DOLocalMoveY(270f, 0.5f);
        Pole_02.transform.DOLocalMoveY(-330f, 0.5f);

        StartCoroutine("TeamLogo_Coroutine");
    }

    private IEnumerator TeamLogo_Coroutine()
    {
        while (timer < 1)
        {
            Window.sizeDelta = new Vector2(1200, Mathf.Lerp(20, 600, timer));
            timer += Time.deltaTime*3f;
            yield return null;
        }
    }
    #endregion

    #region ���ΰ� �ݱ�
    public void TeamLogo_Close()
    {
        Pole_01.transform.DOLocalMoveY(-14f, 0.5f);
        Pole_02.transform.DOLocalMoveY(-55f, 0.5f);

        StartCoroutine("TeamLogoClose_Coroutine");
    }

    private IEnumerator TeamLogoClose_Coroutine()
    {
        timer = 0;
        while (timer < 1)
        {
            Window.sizeDelta = new Vector2(1200, Mathf.Lerp(600, 20, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        transform.GetChild(2).gameObject.SetActive(false);  
    }
    #endregion
}
