using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Stop_Manager : MonoBehaviour
{
    public static Stop_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    public float timer = 0f;
    public Image Fade_Background;
    public bool InPause = false;

    bool PauseWindow_Open = false;
    bool PauseWindow_Close = false;

    bool BackBtn_Check = false;

    bool SettingWindow_Open = false;
    bool SettingWindow_Close = false;

    bool PlayerWindow_Open = false;
    bool PlayerWindow_Close = false;
    bool PlayerWindow_Check = false;

    bool MainWindow_Open = false;
    bool MainWindow_Close = false;

    bool GameExitWindow_Open = false;
    bool GameExitWindow_Close = false;


    public List<Item> ItemDA_Have = new List<Item>();

    [Header("�Ͻ����� â")]
    public GameObject Pause_Pole01; // �Ͻ����� â�� �� ��
    public GameObject Pause_Pole02; // �Ͻ����� â�� �Ʒ� �� 
    public RectTransform Pause_Window; // �Ͻ����� â�� �߰�
    public GameObject Pause_Window_Canvas; // �Ͻ����� â

    [Header("���� â")]
    public GameObject Setting_Pole01; // ���� â�� �� ��
    public GameObject Setting_Pole02; // ���� â�� �Ʒ� �� 
    public RectTransform Setting_Window; // ���� â�� �߰� 
    public GameObject Setting_Window_Canvas; // ���� â
    public Slider Effect_Slider;
    public Slider BGM_Slider;

    public Text Resolution;
    public int Resolution_Num;

    [Header("�÷��̾� â")]
    public GameObject Player_Pole01; // �÷��̾� â�� �� ��
    public GameObject Player_Pole02; // �÷��̾� â�� �Ʒ� �� 
    public RectTransform Player_Window; // �÷��̾� â�� �߰� 

    [Space(10f)]
    public GameObject Player_Item_Window; // ������ â
    public GameObject Player_Weapon_Window; // ���� â
    public GameObject Player_Window_Canvas; // �÷��̾� â
    public bool WI_Check = true; // ���� ����â�� ������ �ִ��� ������ â�� ������ �ִ��� Ȯ���Ѵ�.

    [Header("�÷��̾�_���� â")]
    public GameObject Axe_Window; // ����
    public Text AxeLevel_Text;
    public Text Axe_Skill_Text;

    public Text Axe_AttackDamage;
    public Text Axe_AttackDamage_Upgrade;
    public Text Axe_Defense;
    public Text Axe_Defense_Upgrade;

    [Space(10f)]
    public GameObject Sword_Window; // ��
    public Text SwordLevel_Text;
    public Text Sword_Skill_Text;

    public Text Sword_AttackDamage;
    public Text Sword_AttackDamage_Upgrade;
    public Text Sword_MaxHp;
    public Text Sword_MaxHp_Upgrade;

    [Space(10f)]
    public GameObject Dagger_Window; // �ܰ�
    public Text DaggerLevel_Text;
    public Text Dagger_Skill_Text;

    public Text Dagger_AttackDamage;
    public Text Dagger_AttackDamage_Upgrade;
    public Text Dagger_Critical;
    public Text Dagger_Critical_Upgrade;

    [Header("�÷��̾�_������ â")]
    public Image Player_Item_Log; // ������ �α�
    public Text Player_Item_Name; // ������ �̸�
    public Image Player_Item_Icon; // ������ ������
    public Text Player_Item_Explanation; // ������ ����

    private bool Icon_Check = true;

    [Header("����ȭ�� â")]
    public GameObject Main_Pole01; // ���� â�� �� ��
    public GameObject Main_Pole02; // ���� â�� �Ʒ� �� 
    public RectTransform Main_Window; // ���� â�� �߰� 
    public GameObject Main_Window_Canvas; // ���� â

    [Header("�������� â")]
    public GameObject Exit_Pole01; // �������� â�� �� ��
    public GameObject Exit_Pole02; // �������� â�� �Ʒ� �� 
    public RectTransform Exit_Window; // �������� â�� �߰� 
    public GameObject Exit_Window_Canvas; // �������� â

    void Start()
    {
        WI_Check = true;
        InPause = false;
        Start_Sound();
    }

    void Update()
    {
        Item_Log();
        WeaponType();
        Resolution_Size();
        Sound_Control();


        // ESC Ű�� ������ �Ͻ����� â�� ������.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseWindow_Open == false && SettingWindow_Open == false && MainWindow_Open == false && GameExitWindow_Open == false && PlayerWindow_Open == false)
            {
                PauseWindow_Open = true;
                Pause_Window_Canvas.SetActive(true);
                Fade_Background.DOFade(0.5f, 0.5f);
                UI_Manager.Inst.Cursor_Fade = true;
                StartCoroutine(Pause_Window_Open());
            }

            if (PauseWindow_Close == true && SettingWindow_Open == false && MainWindow_Open == false && GameExitWindow_Open == false && PlayerWindow_Open == false)
                StartCoroutine(Back_Window_Coroutine());

            if (SettingWindow_Open == true)
                Setting_Close_Btn();

            if (MainWindow_Open == true)
                Main_No_Btn();

            if (GameExitWindow_Open == true)
                Exit_No_Btn();

            if (PlayerWindow_Open == true && PlayerWindow_Check == true)
                Player_Close_Btn();

        }
    }

    #region �Ͻ����� â
    public IEnumerator Pause_Window_Open()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
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

        PauseWindow_Close = true;
        BackBtn_Check = true;
    }
    #endregion

    #region ���ư��� ��ư
    public void Back_Btn()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        StartCoroutine(Back_Window_Coroutine());
    }

    public IEnumerator Back_Window_Coroutine() // ���ư��� ��ư
    {
        if (BackBtn_Check == true)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
            BackBtn_Check = false;
            PauseWindow_Close = false;
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
            UI_Manager.Inst.Cursor_Fade = false;
            yield return new WaitForSecondsRealtime(0.1f);
            Pause_Window_Canvas.SetActive(false);
            PauseWindow_Open = false;
            Time.timeScale = 1f;
        }
    }
    #endregion

    #region ���� ��ư
    public void Setting_Btn() => StartCoroutine(Setting_Window_Coroutine01());

    public void Setting_Close_Btn()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        StartCoroutine(Setting_Window_Close());
    }

    public IEnumerator Setting_Window_Coroutine01() // ������ư�� Ŭ������ ��
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);

        if (SettingWindow_Open == false)
        {
            SettingWindow_Open = true;
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
    }

    public IEnumerator Setting_Window_Coroutine02() // ���� â ����
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);

        timer = 0;
        Setting_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Setting_Pole02.transform.DOLocalMoveY(-428f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Setting_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        SettingWindow_Close = true;
    }

    public IEnumerator Setting_Window_Close() // ���� â ����
    {
        if (SettingWindow_Close == true)
        {
            SettingWindow_Close = false;
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
            Time.timeScale = 1f;
            SettingWindow_Open = false;
            UI_Manager.Inst.Cursor_Fade = false;
        }
    }

    public void Resolution_Size()
    {
        switch (Resolution_Num)
        {
            case 0:
                Resolution.text = "1920 * 1080";
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Resolution.text = "1680 * 1050";
                Screen.SetResolution(1680, 1050, true);
                break;
            case 2:
                Resolution.text = "1400 * 1050";
                Screen.SetResolution(1400, 1050, true);
                break;
            case 3:
                Resolution.text = "1280 * 600";
                Screen.SetResolution(1280, 600, true);
                break;

        }
    }

    public void ResolutionSize_Left()
    {
        if (Resolution_Num > 0)
            Resolution_Num--;
    }

    public void ResolutionSize_Right()
    {
        if (Resolution_Num < 3)
            Resolution_Num++;
    }

    public void Start_Sound() =>
        BGM_Slider.value = SoundManager.instance.audioSourceClasses[SoundType.BGM].audioVolume;

    public void Sound_Control()
    {
        SoundManager.instance.audioSourceClasses[SoundType.BGM].audioVolume = BGM_Slider.value;
    }
    #endregion

    #region �÷��̾� ��ư
    public void Player_Btn() => StartCoroutine(Player_Window_Coroutine01());

    public void Player_Close_Btn()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        StartCoroutine(Player_Window_Close());
    }

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
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        if (PlayerWindow_Open == false)
        {
            PlayerWindow_Open = true;
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
    }

    public IEnumerator Player_Window_Coroutine02() // �÷��̾� â ����
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        timer = 0;
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        PlayerWindow_Close = true;
    }

    public IEnumerator Player_Window_Close() // �÷��̾� â ����
    {
        if (PlayerWindow_Close == true)
        {
            PlayerWindow_Close = false;
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
            PauseWindow_Open = true;
            Time.timeScale = 1f;
            PlayerWindow_Open = false;
            UI_Manager.Inst.Cursor_Fade = false;
        }
    }

    #region �÷��̾� -> ���� â & ������ â

    public void Player_WeaPon_Btn() // ���� ��ư�� ������ ��
    {
        if (WI_Check == false)
        {
            PlayerWindow_Check = false;
            StartCoroutine(Player_Weapon_Open01());
        }
    }

    public void Player_Item_Btn() // ������ ��ư�� ������ ��
    {
        if (WI_Check == true)
        {
            PlayerWindow_Check = false;
            StartCoroutine(Player_Item_Open01());
        }
    }

    public IEnumerator Player_Weapon_Open01()
    {
        if (PlayerWindow_Check == false)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
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
    }

    public IEnumerator Player_Weapon_Open02()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        timer = 0;
        Fade_Background.DOFade(0.5f, 0.5f).SetUpdate(true);
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        PlayerWindow_Check = true;
    }

    public IEnumerator Player_Item_Open01()
    {
        if (PlayerWindow_Check == false)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
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
    }

    public IEnumerator Player_Item_Open02()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        timer = 0;
        Fade_Background.DOFade(0.5f, 0.5f).SetUpdate(true);
        Player_Pole01.transform.DOLocalMoveY(447.5388f, 0.48f).SetUpdate(true);
        Player_Pole02.transform.DOLocalMoveY(-445.16f, 0.48f).SetUpdate(true);

        while (timer < 1)
        {
            Player_Window.sizeDelta = new Vector2(1732.5f, Mathf.Lerp(0f, 916.9f, timer));
            timer += Time.unscaledDeltaTime * 3f;
            yield return null;
        }
        PlayerWindow_Check = true;
    }
    #endregion

    #region ���� â
    public void WeaponType()
    {
        int Sword_Level = Player.Instance.stat._level[PlayerWeaponType.Sword];
        int Dagger_Level = Player.Instance.stat._level[PlayerWeaponType.Dagger];
        int Axe_Level = Player.Instance.stat._level[PlayerWeaponType.Axe];

        switch (Player.Instance.stat.weaponType)
        {
            case PlayerWeaponType.Sword:
                SwordLevel_Text.text = "" + Sword_Level;

                Sword_AttackDamage.text = "" + (10 + (10 * Sword_Level));
                Sword_AttackDamage_Upgrade.text = "" + (10 + (10 * (Sword_Level + 1)));

                Sword_MaxHp.text = "" + (10 + (10 * Sword_Level));
                Sword_MaxHp_Upgrade.text = "" + (10 + (10 * (Sword_Level + 1)));

                switch (Sword_Level)
                {
                    case 1:
                        Sword_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                        break;

                    case 3:
                        Sword_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                        break;

                    case 5:
                        Sword_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                        break;
                }

                Sword_Window.SetActive(true);
                Dagger_Window.SetActive(false);
                Axe_Window.SetActive(false);
                break;

            case PlayerWeaponType.Dagger:
                DaggerLevel_Text.text = "" + Dagger_Level;

                Dagger_AttackDamage.text = "" + (8 + (8 * Dagger_Level));
                Dagger_AttackDamage_Upgrade.text = "" + (8 + (8 * (Dagger_Level + 1)));

                Dagger_Critical.text = "" + (0 + (2 * Dagger_Level));
                Dagger_Critical_Upgrade.text = "" + (0 + (2 * (Dagger_Level + 1)));

                switch (Dagger_Level)
                {
                    case 1:
                        Dagger_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                        break;

                    case 3:
                        Dagger_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                        break;

                    case 5:
                        Dagger_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                        break;
                }

                Sword_Window.SetActive(false);
                Dagger_Window.SetActive(true);
                Axe_Window.SetActive(false);
                break;

            case PlayerWeaponType.Axe:
                AxeLevel_Text.text = "" + Axe_Level;

                Axe_AttackDamage.text = "" + (20 + (15 * Axe_Level));
                Axe_AttackDamage_Upgrade.text = "" + (20 + (15 * (Axe_Level + 1)));

                Axe_Defense.text = "" + (400 + (200 * Axe_Level));
                Axe_Defense_Upgrade.text = "" + (400 + (200 * (Axe_Level + 1)));

                switch (Axe_Level)
                {
                    case 1:
                        Axe_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                        break;

                    case 3:
                        Axe_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                        break;

                    case 5:
                        Axe_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                        break;
                }

                Sword_Window.SetActive(false);
                Dagger_Window.SetActive(false);
                Axe_Window.SetActive(true);
                break;
        }
    }
    #endregion

    #endregion

    #region ����ȭ�� ��ư
    public void Main_Btn() => StartCoroutine(Main_Window_Coroutine01());

    public void Main_Yes_Btn() => SceneManager.LoadScene("Main");

    public void Main_No_Btn()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        StartCoroutine(Main_Window_Close());
    }

    public IEnumerator Main_Window_Coroutine01() // ���ι�ư�� Ŭ������ ��
    {
        if (MainWindow_Open == false)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
            MainWindow_Open = true;
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
    }

    public IEnumerator Main_Window_Coroutine02() // ���� â ����
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        timer = 0;
        Main_Pole01.transform.DOLocalMoveY(222f, 0.42f).SetUpdate(true);
        Main_Pole02.transform.DOLocalMoveY(-194f, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Main_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(0f, 520f, timer));
            timer += Time.unscaledDeltaTime * 4f;
            yield return null;
        }
        MainWindow_Close = true;
    }

    public IEnumerator Main_Window_Close()
    {
        if (MainWindow_Close == true)
        {
            MainWindow_Close = false;
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
            PauseWindow_Open = true;
            Time.timeScale = 1f;
            MainWindow_Open = false;
            UI_Manager.Inst.Cursor_Fade = false;
        }
    }
    #endregion

    #region �������� ��ư
    public void Exit_Btn() => StartCoroutine(Exit_Window_Coroutine01());

    public void Exit_Yes_Btn() => Application.Quit();

    public void Exit_No_Btn()
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        StartCoroutine(Exit_Window_Close());
    }

    public IEnumerator Exit_Window_Coroutine01() //�������� ��ư�� Ŭ������ ��
    {
        if (GameExitWindow_Open == false)
        {
            SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
            GameExitWindow_Open = true;
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
    }

    public IEnumerator Exit_Window_Coroutine02() //�������� â ����
    {
        SoundManager.instance.PlaySoundClip("SFX_Window", SoundType.SFX, 1f);
        timer = 0;
        Exit_Pole01.transform.DOLocalMoveY(222f, 0.3f).SetUpdate(true);
        Exit_Pole02.transform.DOLocalMoveY(-211, 0.3f).SetUpdate(true);

        while (timer < 1)
        {
            Exit_Window.sizeDelta = new Vector2(1730f, Mathf.Lerp(0f, 520f, timer));
            timer += Time.unscaledDeltaTime * 4f;
            yield return null;
        }
        GameExitWindow_Close = true;
    }

    public IEnumerator Exit_Window_Close()
    {
        if (GameExitWindow_Close == true)
        {
            GameExitWindow_Close = false;
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
            PauseWindow_Open = true;
            Time.timeScale = 1f;
            GameExitWindow_Open = false;
            UI_Manager.Inst.Cursor_Fade = false;
        }
    }
    #endregion
}
