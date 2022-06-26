using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stop_Manager : MonoBehaviour
{
    public static Stop_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    public float timer = 0f;
    public Image Fade_Background;
    private bool InPause = false;
    public bool Pause_Check = true;

    public List<Item> ItemDA_Have = new List<Item>();

    [Header("�Ͻ����� â")]
    public GameObject Pause_Window_Canvas; // �Ͻ����� â
    public GameObject Pause_Pole01; // �Ͻ����� â�� �� ��
    public GameObject Pause_Pole02; // �Ͻ����� â�� �Ʒ� �� 
    public RectTransform Pause_Window; // �Ͻ����� â�� �߰�

    [Header("���� â")]
    public GameObject Setting_Window_Canvas; // ���� â
    public GameObject Setting_Pole01; // ���� â�� �� ��
    public GameObject Setting_Pole02; // ���� â�� �Ʒ� �� 
    public RectTransform Setting_Window; // ���� â�� �߰� 

    [Header("�÷��̾� â")]
    public GameObject Player_Window_Canvas; // �÷��̾� â
    public GameObject Player_Pole01; // �÷��̾� â�� �� ��
    public GameObject Player_Pole02; // �÷��̾� â�� �Ʒ� �� 
    public RectTransform Player_Window; // �÷��̾� â�� �߰� 

    public GameObject Player_Weapon_Window; // ���� â
    public GameObject Player_Item_Window; // ������ â

    private bool Icon_Check = true;
    public Image Player_Item_Icon; // ������ ������
    public Text Player_Item_Name; // ������ �̸�
    public Text Player_Item_Explanation; // ������ ����

    public Image Player_Item_Log; // ������ �α�
    public float ItemClick_Check; // ������ Ŭ�� üũ

    public bool WI_Check = true; // ���� ����â�� ������ �ִ��� ������ â�� ������ �ִ��� Ȯ���Ѵ�.

    [Header("����ȭ�� â")]
    public GameObject Main_Window_Canvas; // ���� â
    public GameObject Main_Pole01; // ���� â�� �� ��
    public GameObject Main_Pole02; // ���� â�� �Ʒ� �� 
    public RectTransform Main_Window; // ���� â�� �߰� 

    [Header("�������� â")]
    public GameObject Exit_Window_Canvas; // �������� â
    public GameObject Exit_Pole01; // �������� â�� �� ��
    public GameObject Exit_Pole02; // �������� â�� �Ʒ� �� 
    public RectTransform Exit_Window; // �������� â�� �߰� 

    void Start()
    {
        Pause_Check = true;
        WI_Check = true;
        InPause = false;
    }

    void Update()
    {
        Item_Log();

        // ESC Ű�� ������ �Ͻ����� â�� ������.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause_Check == true)
            {
                Pause_Check = false;
                Pause_Window_Canvas.SetActive(true);
                Fade_Background.DOFade(0.5f, 0.5f);
                StartCoroutine(Pause_Window_Open());
            }
            else if (Pause_Check == false)
            {
                Pause_Check = true;
                Back_Btn();
            }
        }
    }

    #region �Ͻ����� â
    public IEnumerator Pause_Window_Open()
    {
        timer = 0;
        // �Ͻ����� â ��
        Pause_Pole01.transform.DOLocalMoveY(374f, 0.5f);
        Pause_Pole02.transform.DOLocalMoveY(-385.76f, 0.5f);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(610f, Mathf.Lerp(0, 772.4f, timer));

            timer += Time.deltaTime * 3.3f;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0f;
    }
    #endregion

    #region ���ư��� ��ư
    public void Back_Btn() => StartCoroutine(Back_Window_Coroutine());

    public IEnumerator Back_Window_Coroutine() // ���ư��� ��ư
    {
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Pause_Pole01.transform.DOLocalMoveY(48f, 0.5f).SetUpdate(true);
        Pause_Pole02.transform.DOLocalMoveY(-36, 0.5f).SetUpdate(true);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(610f, Mathf.Lerp(772.4f, 5f, timer));

            timer += Time.unscaledDeltaTime * 2.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Pause_Window_Canvas.SetActive(false);
        Pause_Check = true;

        Time.timeScale = 1f;
    }
    #endregion

    #region ���� ��ư
    public void Setting_Btn() => StartCoroutine(Setting_Window_Coroutine01());

    public void Setting_Close_Btn() => StartCoroutine(Setting_Window_Close());

    public IEnumerator Setting_Window_Coroutine01() // ������ư�� Ŭ������ ��
    {
        timer = 0;
        Pause_Pole01.transform.DOLocalMoveY(48f, 0.5f).SetUpdate(true);
        Pause_Pole02.transform.DOLocalMoveY(-36, 0.5f).SetUpdate(true);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(557.1f, Mathf.Lerp(772.4f, 5f, timer));

            timer += Time.unscaledDeltaTime * 2.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Pause_Window_Canvas.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Setting_Window_Canvas.SetActive(true);
        StartCoroutine(Setting_Window_Coroutine02());
    }

    public IEnumerator Setting_Window_Coroutine02() // ���� â ����
    {
        timer = 0;
        Setting_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Setting_Pole02.transform.DOLocalMoveY(-428f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Setting_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
    }

    public IEnumerator Setting_Window_Close()
    {
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Setting_Pole01.transform.DOLocalMoveY(30, 0.48f).SetUpdate(true);
        Setting_Pole02.transform.DOLocalMoveY(-30, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Setting_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(916.9f, 0f, timer));

            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Setting_Window_Canvas.SetActive(false);
        Pause_Check = true;
        Time.timeScale = 1f;
    }
    #endregion

    #region �÷��̾� ��ư
    public void Player_Btn() => StartCoroutine(Player_Window_Coroutine01());
    public void Player_Close_Btn() => StartCoroutine(Player_Window_Close());

    public void Item_Log()
    {
        if (Card_Manager.Inst.Item_bool == false)
        {
            Player_Item_Log.transform.GetChild(Card_Manager.Inst.Item_Check).GetComponent<Image>().sprite = ItemDA_Have[Card_Manager.Inst.Item_Check].Item_Icon;
            Player_Item_Log.transform.GetChild(Card_Manager.Inst.Item_Check).gameObject.SetActive(true);

            if (Icon_Check == true)
            {
                Icon_Check = false;
                Player_Item_Icon.sprite = ItemDA_Have[0].Item_Icon;
                Player_Item_Name.text = ItemDA_Have[0].Itme_Name;
                Player_Item_Explanation.text = ItemDA_Have[0].Item_Explanation;
            }
        }
    }

    public IEnumerator Player_Window_Coroutine01() // �÷��̾��ư�� Ŭ������ ��
    {
        timer = 0;
        Pause_Pole01.transform.DOLocalMoveY(48f, 0.5f).SetUpdate(true);
        Pause_Pole02.transform.DOLocalMoveY(-36, 0.5f).SetUpdate(true);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(557.1f, Mathf.Lerp(772.4f, 5f, timer));

            timer += Time.unscaledDeltaTime * 2.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Pause_Window_Canvas.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Player_Window_Canvas.SetActive(true);
        StartCoroutine(Player_Window_Coroutine02());
    }

    public IEnumerator Player_Window_Coroutine02() // �÷��̾� â ����
    {
        timer = 0;
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
    }


    public IEnumerator Player_Window_Close() // �÷��̾� â ����
    {
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Player_Pole01.transform.DOLocalMoveY(30, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-30, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(916.9f, 0f, timer));

            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Player_Window_Canvas.SetActive(false);
        Pause_Check = true;
        Time.timeScale = 1f;
    }

    #region �÷��̾� -> ���� â & ������ â

    public void Player_WeaPon_Btn() // ���� ��ư�� ������ ��
    {
        if (WI_Check == false)
            StartCoroutine(Player_Weapon_Open01());
    }

    public void Player_Item_Btn() // ������ ��ư�� ������ ��
    {
        if (WI_Check == true)
            StartCoroutine(Player_Item_Open01());
    }

    public IEnumerator Player_Weapon_Open01()
    {
        WI_Check = true;
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Player_Pole01.transform.DOLocalMoveY(30, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-30, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(916.9f, 0f, timer));

            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Player_Weapon_Window.SetActive(true);
        Player_Item_Window.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(Player_Weapon_Open02());
    }

    public IEnumerator Player_Weapon_Open02()
    {
        timer = 0;
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
    }

    public IEnumerator Player_Item_Open01()
    {
        WI_Check = false;
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Player_Pole01.transform.DOLocalMoveY(30, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-30, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(916.9f, 0f, timer));

            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Player_Weapon_Window.SetActive(false);
        Player_Item_Window.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        StartCoroutine(Player_Item_Open02());
    }

    public IEnumerator Player_Item_Open02()
    {
        timer = 0;
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
    }
    #endregion

    #endregion

    #region ����ȭ�� ��ư
    public void Main_Btn() => StartCoroutine(Main_Window_Coroutine01());

    public void Main_Yes_Btn() => StartCoroutine(Main_Window_Close());

    public void Main_No_Btn() => StartCoroutine(Main_Window_Close());

    public IEnumerator Main_Window_Coroutine01() // ���ι�ư�� Ŭ������ ��
    {
        timer = 0;
        Pause_Pole01.transform.DOLocalMoveY(48f, 0.5f).SetUpdate(true);
        Pause_Pole02.transform.DOLocalMoveY(-36, 0.5f).SetUpdate(true);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(557.1f, Mathf.Lerp(772.4f, 5f, timer));

            timer += Time.unscaledDeltaTime * 2.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Pause_Window_Canvas.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Main_Window_Canvas.SetActive(true);
        StartCoroutine(Main_Window_Coroutine02());
    }

    public IEnumerator Main_Window_Coroutine02() // ���� â ����
    {
        timer = 0;
        Main_Pole01.transform.DOLocalMoveY(222f, 0.42f).SetUpdate(true);
        Main_Pole02.transform.DOLocalMoveY(-194f, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Main_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(0f, 520f, timer));
            timer += Time.unscaledDeltaTime * 4f;
            yield return null;
        }
    }

    public IEnumerator Main_Window_Close()
    {
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Main_Pole01.transform.DOLocalMoveY(30f, 0.42f).SetUpdate(true);
        Main_Pole02.transform.DOLocalMoveY(-30f, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Main_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(520f, 0f, timer));

            timer += Time.unscaledDeltaTime * 4.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Main_Window_Canvas.SetActive(false);
        Pause_Check = true;
        Time.timeScale = 1f;
    }
    #endregion

    #region �������� ��ư
    public void Exit_Btn() => StartCoroutine(Exit_Window_Coroutine01());

    public void Exit_Yes_Btn() => StartCoroutine(Exit_Window_Close());

    public void Exit_No_Btn() => StartCoroutine(Exit_Window_Close());

    public IEnumerator Exit_Window_Coroutine01() //�������� ��ư�� Ŭ������ ��
    {
        timer = 0;
        Pause_Pole01.transform.DOLocalMoveY(48f, 0.5f).SetUpdate(true);
        Pause_Pole02.transform.DOLocalMoveY(-36, 0.5f).SetUpdate(true);

        while (timer < 1)
        {
            Pause_Window.sizeDelta = new Vector2(557.1f, Mathf.Lerp(772.4f, 5f, timer));

            timer += Time.unscaledDeltaTime * 2.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Pause_Window_Canvas.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        Exit_Window_Canvas.SetActive(true);
        StartCoroutine(Exit_Window_Coroutine02());
    }

    public IEnumerator Exit_Window_Coroutine02() //�������� â ����
    {
        timer = 0;
        Exit_Pole01.transform.DOLocalMoveY(222f, 0.3f).SetUpdate(true);
        Exit_Pole02.transform.DOLocalMoveY(-211, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Exit_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(0f, 520f, timer));
            timer += Time.unscaledDeltaTime * 4f;
            yield return null;
        }
    }

    public IEnumerator Exit_Window_Close()
    {
        timer = 0;
        Fade_Background.DOFade(0, 0.5f).SetUpdate(true);
        Exit_Pole01.transform.DOLocalMoveY(30f, 0.42f).SetUpdate(true);
        Exit_Pole02.transform.DOLocalMoveY(-30f, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Exit_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(520f, 0f, timer));

            timer += Time.unscaledDeltaTime * 4.5f;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.1f);
        Exit_Window_Canvas.SetActive(false);
        Pause_Check = true;
        Time.timeScale = 1f;
    }
    #endregion
}
