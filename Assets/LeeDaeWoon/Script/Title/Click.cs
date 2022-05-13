using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Click : MonoBehaviour
{
    [Header("속도")]
    public float Speed = 1f;

    [Header("창 연출 오브젝트")]
    public GameObject Pole_01;
    public GameObject Pole_02;
    public GameObject Window;

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

    public void TeamLogo_Click()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        Pole_01.transform.DOLocalMoveY(270f, 0.5f);
        Pole_02.transform.DOLocalMoveY(-330f, 0.5f);
        Window.transform.DOScaleY(30, 0.5f);
    }
}
