using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player_Vector : MonoBehaviour
{
    public static Player_Vector Inst;
    public GameObject Player;

    public bool M_VectorCheck = false;
    public bool I_VectorCheck = false;
    public bool D_VectorCheck = false;

    void Start()
    {
        
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        Scene_Vector();
    }

    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        DOTween.PauseAll();
        if (SceneManager.GetActiveScene().name == "Dimension")
        {
            Skill_Manager.Inst.Chang_Check = false;
            UI_Manager.Inst.PlayerMove_control = false;

            Potal.Inst.Player.DOFade(1f, 0f);
            Potal.Inst.Dark_Player.DOFade(1f, 0f);
            UI_Manager.Inst.FadeInOut.DOFade(0f, 0f);
            Debug.Log("asdf");
        }
    }

    #region 필요없을 듯

    public void Scene_Vector()
    {
        if (SceneManager.GetActiveScene().name == "Main" && M_VectorCheck == false)
        {
            M_VectorCheck = true;
            Player.transform.localPosition = new Vector3(-8.9f, -1.39f, 0f);
        }

        if (SceneManager.GetActiveScene().name == "test" && I_VectorCheck == false)
        {
            I_VectorCheck = true;
            Player.transform.localPosition = new Vector3(0f, 1f, 0f);
        }

        if (SceneManager.GetActiveScene().name == "Dimension" && D_VectorCheck == false)
        {
            D_VectorCheck = true;
            Player.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
    }
    #endregion
}
