using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    public Image FadeInOut;
    public Text Die_Text;
    public Text Any_Text;

    public bool Once_Check = false;

    void Start()
    {

    }

    void Update()
    {
        if (UI_Manager.Inst.HP_Bar <= 0 && Once_Check == false)
        {
            Once_Check = true;
            FadeInOut.DOFade(1f, 1f);
            Die_Text.DOFade(1f, 1f);
            Any_Text.DOFade(1f, 1f);

            if (Input.anyKeyDown)
                SceneManager.LoadScene("Main");
        }
    }
}
