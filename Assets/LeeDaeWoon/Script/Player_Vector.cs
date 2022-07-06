using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Vector : MonoBehaviour
{
    public static Player_Vector Inst;
    public GameObject Player;

    public bool M_VectorCheck = false;
    public bool I_VectorCheck = false;

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

    #region 필요없을 듯
    //private void OnLevelWasLoaded(int level)
    //{
    //    Player.transform.localPosition = new Vector3(0, 0, 0);
    //}

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
    }
    #endregion
}
