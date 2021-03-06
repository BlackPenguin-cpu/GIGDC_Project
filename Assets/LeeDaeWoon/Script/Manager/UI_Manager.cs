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

    public Image FadeInOut_Die;
    public Text Die_Text;
    public Text Any_Text;

    public bool Once_Check = false;

    [Header("마우스 포인터")]
    public Texture2D MousePointer;
    public bool Cursor_Fade;

    [Header("페이드인아웃")]
    public Image FadeInOut;

    public bool King_Check = false;

    public bool DarkPlayerGet_Check;

    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(MousePointer, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        Die_System();

        if (DarkPlayerGet_Check == true && SceneManager.GetActiveScene().name == "Main")
        {
            DarkPlayerGet_Check = false;
            Destroy(GameObject.Find("DarkPlayer"));
        }

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

    private void OnLevelWasLoaded(int level)
    {
        if (Once_Check == true && SceneManager.GetActiveScene().name == "Main")
        {
            Once_Check = false;
            DarkPlayerGet_Check = true;

            Player.Instance._hp = Player.Instance._maxHp;
            Player.Instance.state = PlayerState.Idle;
            WaveManager.Instance.m_WaveNum = 1;
            Sec = 0;
            Min = 0;

            FadeInOut_Die.color = new Color(0, 0, 0, 0);
            Die_Text.color = new Color(255, 255, 255, 0);
            Any_Text.color = new Color(255, 255, 255, 0);
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
        Gold_Text.text = GameManager.Instance._coin.ToString();
        Dimensional_Text.text = GameManager.Instance.crystal.ToString();

        if (Input.GetKeyDown(KeyCode.G))
            GameManager.Instance._coin += 1000;
        if (Input.GetKeyDown(KeyCode.M))
            GameManager.Instance.crystal += 1000;
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

    public void Die_System()
    {
        if (SceneManager.GetActiveScene().name == "test")
        {
            if (Input.anyKeyDown && Once_Check == true)
                SceneManager.LoadScene("Main");

            if (Once_Check == false && HP_Bar <= 0)
            {
                FadeInOut_Die.DOFade(0.5f, 1f);
                Die_Text.DOFade(1f, 1f);
                Any_Text.DOFade(1f, 1f);
                Once_Check = true;
            }
        }
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
