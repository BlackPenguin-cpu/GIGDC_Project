using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Inst;

    public bool PlayerMove_control = false;

    [Header("재화")]
    public int Gold;
    public Text Gold_Text;
    public int Dimensional;
    public Text Dimensional_Text;

    [Header("웨이브")]
    public Text Wave_Text;

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
    public bool Cursor_Fade;

    [Header("페이드인아웃")]
    public Image FadeInOut;


    void Start()
    {
        Cursor.SetCursor(MousePointer, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            SoundManager.instance.PlaySoundClip("BGM_Title (1)", SoundType.BGM);

        //Cursor.visible = Cursor_Fade;

        Timer_System();
        Money_System();
        HP_System();
        Wave();
        Cheats();
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
        GameManager.Instance._coin = Gold;
        GameManager.Instance.crystal = Dimensional;

        Gold_Text.text = "" + Gold;
        Dimensional_Text.text = "" + Dimensional;

        if (Input.GetKeyDown(KeyCode.G))
            Gold += 1000;
        if (Input.GetKeyDown(KeyCode.M))
            Dimensional += 1000;
    }

    #endregion

    #region 웨이브
    public void Wave()
    {
        // 인게임
        if (SceneManager.GetActiveScene().name == "test")
            Wave_Text.text = "Wave." + WaveManager.Instance.m_WaveNum;

        // 차원의 틈새
        else if (SceneManager.GetActiveScene().name == "Dimension")
            Wave_Text.text = "차원의 틈새";

        // 폐허가된 성
        else if (SceneManager.GetActiveScene().name == "Main")
            Wave_Text.text = "폐허가된 성";
    }
    #endregion

    #region 체력
    public void HP_System()
    {
        HP_Bar = Bar.transform.localScale.y;
        HP = Player.Instance.stat._hp / Player.Instance.stat._maxHp;


        if (HP_Bar > HP)
            Bar.transform.localScale = new Vector3(1, Mathf.Lerp(HP_Bar, HP - 0.00001f, Time.deltaTime * 20), 1);
        else
            Bar.transform.localScale = new Vector3(1, Mathf.Lerp(HP_Bar, HP, Time.deltaTime * 20), 1);
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
    }
    #endregion
}
