using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("��ȭ")]
    public Text Gold_Text;
    public Text Dimensional_Text;
    public int Dimensional;
    public float Gold;

    [Header("Ÿ�̸�")]
    public Text Timer_Text;
    int Min;
    float Sec;

    [Header("ü��")]
    public float HP;
    public GameObject Bar;

    Player player;

    void Start()
    {
        player = Player.Instance;
    }

    void Update()
    {
        Timer_System();
        Money_System();
        HP_System();
    }

    #region Ÿ�̸�
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

    #region ��ȭ
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

    #region ü��
    public void HP_System()
    {
        HP = player.stat._hp;

        if (HP >= 0 && HP <= 100)
            Bar.transform.localScale = new Vector3(100, HP, 1);
    }
    #endregion
}
