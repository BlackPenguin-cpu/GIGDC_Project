using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    public bool PlayerMove_control = false;

    [Header("재화")]
    public float Gold;
    public Text Gold_Text;
    public int Dimensional;
    public Text Dimensional_Text;


    [Header("타이머")]
    public Text Timer_Text;
    int Min;
    float Sec;

    [Header("체력")]
    public float HP_Bar;

    public float HP;
    public GameObject Bar;

    [Header("마우스 포인터")]
    public Texture2D MousePointer;

    void Start()
    {
        Cursor.SetCursor(MousePointer, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        Timer_System();
        Money_System();
        HP_System();
        Cheats();
    }

    #region 타이머
    public void Timer_System()
    {
        Sec += Time.deltaTime;
        Timer_Text.text = string.Format("{0:D2}:{1:D2}", Min, (int)Sec);

        if ((int)Sec > 59)
        {
            Sec = 0;
            Min++;
        }
    }
    #endregion

    #region 재화
    public void Money_System()
    {
        Gold_Text.text = "" + Gold;
        Dimensional_Text.text = "" + Dimensional;

        if (Input.GetKeyDown(KeyCode.G))
            Gold += 1000;
        if (Input.GetKeyDown(KeyCode.M))
            Dimensional += 1000;
    }

    #endregion

    #region 체력
    public void HP_System()
    {
        HP_Bar = Bar.transform.localScale.y;
        HP = Player.Instance.stat._hp / Player.Instance.stat._maxHp;


        if (HP_Bar > HP)
            Bar.transform.localScale = new Vector3(1, Mathf.Lerp(HP_Bar, HP - 0.00001f, Time.deltaTime * 10), 1);

    }
    #endregion

    #region Cheat
    public void Cheats()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            DOTween.PauseAll();
            SceneManager.LoadScene("test");
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            DOTween.PauseAll();
            SceneManager.LoadScene("Dimension");

        }
        #endregion
    }
}
