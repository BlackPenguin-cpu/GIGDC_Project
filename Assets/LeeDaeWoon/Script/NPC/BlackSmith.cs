using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackSmith : MonoBehaviour
{
    public static BlackSmith Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("��ȣ�ۿ� ��ư")]
    public Image F_Button; // ��ȣ�ۿ� ��ư
    public GameObject Upgrade; // ��ȣ�ۿ� ������Ʈ
    public Text Upgrade_Text; // ��ȣ�ۿ� �ؽ�Ʈ
    public bool Collision_Check = true; // �浹 �ߴ��� üũ

    [Header("���� ���� �� ��ȭ â")]
    private float timer; // â ������ �ӵ�
    public GameObject Pole_01; // ��_01
    public GameObject Pole_02; // ��_02
    public GameObject Malyeog_Window; // â ������Ʈ
    public RectTransform MalyeogRect_Window; // â

    [Header("���� �� ��ȭ ��ư")]
    public GameObject Purchase_Btn;
    public GameObject Enhance_Btn;

    [Header("���� Ȯ��")]
    public GameObject Jang_cak_Btn;
    public GameObject Jang_cak;
    public GameObject No_Soyu;

    public GameObject Weapon;
    public List<GameObject> BlackSmiths = new List<GameObject>();

    [Header("���� ��ĩ��")]
    public Text AxeLevel_Text;
    public Text Axe_Skill_Text;

    public Text Axe_AttackDamage;
    public Text Axe_AttackDamage_Upgrade;
    public Text Axe_Defense;
    public Text Axe_Defense_Upgrade;

    [Space(10)]
    public GameObject Axe_Price;
    public GameObject Axe_Required_Gold;
    public Text Axe_Required_Gold_Price;

    [Header("�� ��ĩ��")]
    public Text SwordLevel_Text;
    public Text Sword_Skill_Text;

    public Text Sword_AttackDamage;
    public Text Sword_AttackDamage_Upgrade;
    public Text Sword_MaxHp;
    public Text Sword_MaxHp_Upgrade;

    [Space(10)]
    public GameObject Sword_Required_Gold;
    public Text Sword_Required_Gold_Price;


    [Header("�ܰ� ��ĩ��")]
    public Text DaggerLevel_Text;
    public Text Dagger_Skill_Text;

    public Text Dagger_AttackDamage;
    public Text Dagger_AttackDamage_Upgrade;
    public Text Dagger_Critical;
    public Text Dagger_Critical_Upgrade;

    [Space(10)]
    public GameObject Dagger_Price;
    public GameObject Dagger_Required_Gold;
    public Text Dagger_Required_Gold_Price;

    void Start()
    {
        Upgrade_Text.DOFade(0f, 0f);
        F_Button.DOFade(0f, 0f);
    }

    void Update()
    {
        BlackSmith_Click();
        Weapon_Stat();
        #region ���� ��ǥ�� ��ũ�� ��ǥ�� ������ ���ش�.
        Upgrade.transform.localPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.localPosition + new Vector3(-3f, 0.3f, 0));
        #endregion
    }


    public void Weapon_Stat()
    {
        int Sword_Level = Player.Instance.stat._level[PlayerWeaponType.Sword];
        int Dagger_Level = Player.Instance.stat._level[PlayerWeaponType.Dagger];
        int Axe_Level = Player.Instance.stat._level[PlayerWeaponType.Axe];

        if (Weapon.transform.GetChild(0).gameObject.activeSelf == true)
        {
            SwordLevel_Text.text = "" + Sword_Level;

            Sword_AttackDamage.text = "" + (10 + (10 * Sword_Level));
            Sword_AttackDamage_Upgrade.text = "" + (10 + (10 * (Sword_Level + 1)));

            Sword_MaxHp.text = "" + (10 + (10 * Sword_Level));
            Sword_MaxHp_Upgrade.text = "" + (10 + (10 * (Sword_Level + 1)));

            Sword_Required_Gold_Price.text = "" + (400 + (200 * Sword_Level));

            Purchase_Btn.SetActive(false);
            Enhance_Btn.SetActive(true);

            No_Soyu.SetActive(false);
            if (Player.Instance.stat.weaponType == PlayerWeaponType.Sword)
            {
                Jang_cak.SetActive(true);
                Jang_cak_Btn.SetActive(false);
            }
            else
            {
                Jang_cak.SetActive(false);
                Jang_cak_Btn.SetActive(true);
            }

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
        }

        if (Weapon.transform.GetChild(1).gameObject.activeSelf == true)
        {
            DaggerLevel_Text.text = "" + Dagger_Level;

            Dagger_AttackDamage.text = "" + (8 + (8 * Dagger_Level));
            Dagger_AttackDamage_Upgrade.text = "" + (8 + (8 * (Dagger_Level + 1)));

            Dagger_Critical.text = "" + (0 + (2 * Dagger_Level));
            Dagger_Critical_Upgrade.text = "" + (0 + (2 * (Dagger_Level + 1)));

            Dagger_Required_Gold_Price.text = "" + (400 + (200 * Dagger_Level));

            if (Dagger_Required_Gold.activeSelf == true)
            {
                No_Soyu.SetActive(false);
                if (Player.Instance.stat.weaponType == PlayerWeaponType.Dagger)
                {
                    Jang_cak.SetActive(true);
                    Jang_cak_Btn.SetActive(false);
                }
                else
                {
                    Jang_cak.SetActive(false);
                    Jang_cak_Btn.SetActive(true);
                }
            }
            else
            {
                No_Soyu.SetActive(true);
                Jang_cak.SetActive(false);
                Purchase_Btn.SetActive(true);
                Enhance_Btn.SetActive(false);
            }

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
        }

        if (Weapon.transform.GetChild(2).gameObject.activeSelf == true)
        {
            AxeLevel_Text.text = "" + Axe_Level;

            Axe_AttackDamage.text = "" + (20 + (15 * Axe_Level));
            Axe_AttackDamage_Upgrade.text = "" + (20 + (15 * (Axe_Level + 1)));

            Axe_Defense.text = "" + (400 + (200 * Axe_Level));
            Axe_Defense_Upgrade.text = "" + (400 + (200 * (Axe_Level + 1)));

            Axe_Required_Gold_Price.text = "" + (400 + (200 * Axe_Level));

            if (Axe_Required_Gold.activeSelf == true)
            {
                No_Soyu.SetActive(false);
                if (Player.Instance.stat.weaponType == PlayerWeaponType.Axe)
                {
                    Jang_cak.SetActive(true);
                    Jang_cak_Btn.SetActive(false);
                }
                else
                {
                    Jang_cak.SetActive(false);
                    Jang_cak_Btn.SetActive(true);
                }
            }
            else
            {
                No_Soyu.SetActive(true);
                Jang_cak.SetActive(false);
                Purchase_Btn.SetActive(true);
                Enhance_Btn.SetActive(false);
            }

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
        }

    }

    #region ��ư Ŭ��
    public void BlackSmith_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false)
            StartCoroutine(Open_Window());
    }

    public void Left_Arrow()
    {
        int Save_BlackSmiths = BlackSmiths.Count;
        BlackSmiths[0].SetActive(false);

        BlackSmiths.Insert(0, BlackSmiths[Save_BlackSmiths - 1]);
        BlackSmiths.RemoveAt(Save_BlackSmiths);
        BlackSmiths[0].SetActive(true);
    }

    public void Right_Arrow()
    {
        BlackSmiths[0].SetActive(false);

        BlackSmiths.Add(BlackSmiths[0]);
        BlackSmiths.RemoveAt(0);
        BlackSmiths[0].SetActive(true);
    }

    public void Purchase_Click()
    {
        int Gold = 300;
        //�ܰ�
        if (Weapon.transform.GetChild(1).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= Gold)
        {
            UI_Manager.Inst.Gold -= Gold; // ��� ����
            Dagger_Price.SetActive(false); // ���Ű��� false
            Dagger_Required_Gold.SetActive(true); // ��ȭ ���� true
            Player.Instance.stat.weaponType = PlayerWeaponType.Dagger; // ���� �ܰ����� �ٲ�
            Purchase_Btn.SetActive(false); // ���� ��ư false
            Enhance_Btn.SetActive(true); // ��ȭ ��ư true
        }

        if (Weapon.transform.GetChild(2).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= Gold)
        {
            UI_Manager.Inst.Gold -= Gold; // ��� ����
            Axe_Price.SetActive(false); // ���Ű��� false
            Axe_Required_Gold.SetActive(true); // ��ȭ ���� true
            Player.Instance.stat.weaponType = PlayerWeaponType.Axe; // ���� �ܰ����� �ٲ�
            Purchase_Btn.SetActive(false); // ���� ��ư false
            Enhance_Btn.SetActive(true); // ��ȭ ��ư true
        }
    }

    public void JangCak_Click()
    {
        if (Weapon.transform.GetChild(0).gameObject.activeSelf == true)
            Player.Instance.stat.weaponType = PlayerWeaponType.Sword;
        else if (Weapon.transform.GetChild(1).gameObject.activeSelf == true)
            Player.Instance.stat.weaponType = PlayerWeaponType.Dagger;
        else if (Weapon.transform.GetChild(2).gameObject.activeSelf == true)
            Player.Instance.stat.weaponType = PlayerWeaponType.Axe;
    }

    public void Enhance_Click()
    {
        switch (Player.Instance.stat.weaponType)
        {
            case PlayerWeaponType.Sword:
                if (Weapon.transform.GetChild(0).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Player.Instance.stat._level[PlayerWeaponType.Sword])))
                    Player.Instance.stat._level[PlayerWeaponType.Sword]++;
                break;

            case PlayerWeaponType.Dagger:
                if (Weapon.transform.GetChild(1).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Player.Instance.stat._level[PlayerWeaponType.Dagger])))
                    Player.Instance.stat._level[PlayerWeaponType.Dagger]++;
                break;

            case PlayerWeaponType.Axe:
                if (Weapon.transform.GetChild(2).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Player.Instance.stat._level[PlayerWeaponType.Axe])))
                    Player.Instance.stat._level[PlayerWeaponType.Axe]++;
                break;
        }
    }
    #endregion

    #region â ����
    public void Close() => StartCoroutine(Close_Window());

    public IEnumerator Open_Window()
    {
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
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(30, 0.5f);
        Pole_02.transform.DOLocalMoveY(-30, 0.5f);

        while (timer < 1)
        {
            MalyeogRect_Window.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(931.6482f, 0, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        Malyeog_Window.SetActive(false);
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
