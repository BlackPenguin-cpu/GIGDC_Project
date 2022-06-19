using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    [Header("신성 창 좌표")]
    [SerializeField] RectTransform Healing_Window_Position;

    [Header("신성 창 시간")]
    public float Timer = 0;

    [Header("신성 창")]
    public GameObject Healing_Window;
    public RectTransform Pole_02;
    public RectTransform Healing_RectTransform;
    public Text Healing_Gold_Text;

    public float Healing_Gold = 0;
    public float Heal = 0;

    bool Healing_Colider_Check = true;
    bool Healing_Purchase_Check = true;


    void Start()
    {
        Healing_Window.SetActive(false);
        Healing_Price();

    }

    void Update()
    {
        ScreentoWorld();
        Healing_Purchase();
    }

    void ScreentoWorld()
    {
        // 월드 좌표를 스크린 좌표로 변경을 해준다.
        Healing_Window_Position.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(2.6f, -3.95f, 0));
    }

    public void Healing_Price()
    {
        //if (Wave가 5일경우)
        Healing_Gold = 560f;
        Heal = 50f;
        //else if (Wave가 10일경우)
        //{
        //  Healing_Gold = 1230f;
        //  Heal = 80f;
        //}
        //else if (Wave가 15일경우)
        //{
        //  Healing_Gold = 2116f;
        //  Heal = 120f;
        //}
        Healing_Gold_Text.text = "" + Healing_Gold;
    }

    public void Healing_Purchase()
    {
        if (Input.GetKeyDown(KeyCode.F) && Healing_Colider_Check == false && UI_Manager.Inst.Gold >= Healing_Gold && Healing_Purchase_Check == true)
        {
            UI_Manager.Inst.Gold -= Healing_Gold;
            HP_Bar.Inst.HP += Heal;

            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            StartCoroutine(HealingWindow_Close_Coroutine());
            Healing_Purchase_Check = false;
        }
    }

    #region 신성 창
    IEnumerator HealingWindow_Coroutine()
    {
        Timer = 0;
        while (Timer < 1)
        {
            Healing_RectTransform.anchoredPosition = new Vector2(1.995371f, Mathf.Lerp(-135f, -244f, Timer));
            Healing_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(0, 264.2f, Timer));
            Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(-153f, -382f, Timer));
            Timer += Time.deltaTime * 4f;
            yield return null;
        }
    }

    IEnumerator HealingWindow_Close_Coroutine()
    {
        Timer = 0;
        while (Timer < 1)
        {
            Healing_RectTransform.anchoredPosition = new Vector2(1.995371f, Mathf.Lerp(-244f, -135f, Timer));
            Healing_RectTransform.sizeDelta = new Vector2(1724.1f, Mathf.Lerp(264.2f, 0, Timer));
            Pole_02.anchoredPosition = new Vector2(1.9954f, Mathf.Lerp(-382f, -153f, Timer));
            Timer += Time.deltaTime * 4f;
            yield return null;
        }

        Healing_Window.SetActive(false);
    }
    #endregion

    #region 충돌체크
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Healing_Colider_Check == true && Healing_Purchase_Check == true)
        {
            Healing_Colider_Check = false;
            Healing_Window.SetActive(true);
            StartCoroutine(HealingWindow_Coroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Healing_Colider_Check == false && Healing_Purchase_Check == true)
        {
            Healing_Colider_Check = true;
            StartCoroutine(HealingWindow_Close_Coroutine());
        }
    }
    #endregion
}
