using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Foundation : MonoBehaviour
{
    public static Foundation Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("����")]
    public float Speed; // ������ ���ư��� �ӵ�
    public SpriteRenderer Magic_Circle; // ������

    [Header("���׷��̵� ��ư")]
    public Image F_Button; // ��ȣ�ۿ� ��ư
    public GameObject Upgrade; // ��ȣ�ۿ� ������Ʈ
    public Text Upgrade_Text; // ��ȣ�ۿ� �ؽ�Ʈ
    public bool Collision_Check = true; // �浹 �ߴ��� üũ

    [Header("���°�ȭ â")]
    private float timer; // â ������ �ӵ�
    public GameObject Pole_01; // ��_01
    public GameObject Pole_02; // ��_02
    public GameObject Malyeog_Window; // â ������Ʈ
    public RectTransform MalyeogRect_Window; // â2
    bool WindowOpen_Check = false;

    public Image FadeInout;

    public Text Title; // ���� �̸�
    public Text Explanation; // ���� ����
    public GameObject Close_Btn; // �ݱ� ��ư
    public GameObject Price_obj; // ���� ������Ʈ
    public Text Dimensional_Price; // ���� ����

    public int Magic_Open;
    public int Body_Open;

    void Start()
    {
        Upgrade_Text.DOFade(0f, 0f);
        F_Button.DOFade(0f, 0f);


    }

    void Update()
    {
        Foundation_Click();

        if (SceneManager.GetActiveScene().name == "Dimension")
            MagicCircle_Rotation();

        #region ���� ��ǥ�� ��ũ�� ��ǥ�� ������ ���ش�.
        if (SceneManager.GetActiveScene().name == "Dimension")
            Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-5.2f, -4.4f, 0));
        if (SceneManager.GetActiveScene().name == "Main")
            Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-10.8f, -7f, 0));
        #endregion
    }

    public void MagicCircle_Rotation()
    {
        if (SceneManager.GetActiveScene().name == "Main")
            Magic_Circle.DOFade(1f, 1f);

        Magic_Circle.transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
    }

    public void Foundation_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false && WindowOpen_Check == false)
        {
            FadeInout.DOFade(0.5f, 1f);
            UI_Manager.Inst.PlayerMove_control = true;
            StartCoroutine(Open_Window());
            WindowOpen_Check = true;
        }
    }

    #region â ����
    public void Close()
    {
        SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
        StartCoroutine(Close_Window());
    }

    public IEnumerator Open_Window()
    {
        UI_Manager.Inst.Cursor_Fade = true;
        Malyeog_Window.SetActive(true);
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(452, 0.5f);
        Pole_02.transform.DOLocalMoveY(-452, 0.5f);

        while (timer < 1)
        {
            MalyeogRect_Window.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(0, 931.6482f, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
    }

    public IEnumerator Close_Window()
    {
        UI_Manager.Inst.Cursor_Fade = false;
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(30, 0.5f);
        Pole_02.transform.DOLocalMoveY(-30, 0.5f);
        FadeInout.DOFade(0f, 1f);
        while (timer < 1)
        {
            MalyeogRect_Window.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(931.6482f, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        UI_Manager.Inst.PlayerMove_control = false;
        Malyeog_Window.SetActive(false);
        WindowOpen_Check = false;
    }
    #endregion

    #region �浹 üũ
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = false;
            Upgrade_Text.DOFade(1f, 0.5f);
            F_Button.DOFade(1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = true;
            Upgrade_Text.DOFade(0f, 0.5f);
            F_Button.DOFade(0f, 0.5f);
        }
    }
    #endregion
}
