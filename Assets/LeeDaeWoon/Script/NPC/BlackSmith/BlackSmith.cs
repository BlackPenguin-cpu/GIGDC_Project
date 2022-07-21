using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackSmith : MonoBehaviour
{
    public static BlackSmith Inst { get; private set; }
    void Awake() => Inst = this;


    public bool BlackSmithWindow_Close = false;

    [Header("��ȣ�ۿ� ��ư")]
    public Image F_Button; // ��ȣ�ۿ� ��ư
    public GameObject Upgrade; // ��ȣ�ۿ� ������Ʈ
    public Text Upgrade_Text; // ��ȣ�ۿ� �ؽ�Ʈ
    public bool Collision_Check = true; // �浹 �ߴ��� üũ

    [Header("���� ���� �� ��ȭ â")]
    private float timer; // â ������ �ӵ�
    public GameObject Pole_01; // ��_01
    public GameObject Pole_02; // ��_02
    public GameObject Weapon_Purchase_Window; // â ������Ʈ
    public RectTransform WeaponPurchase_RectWindow; // â

    public Image FadeInout;

    public bool WindowOpen_Check = false;

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
    public GameObject Axe_MaxEnhance;

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
    public GameObject Sword_MaxEnhance;


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
    public GameObject Dagger_MaxEnhance;

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

        if (Weapon.transform.GetChild(0).gameObject.activeSelf == true && Sword_Level <= 5)
        {
            if (Sword_Level == 5)
            {
                SwordLevel_Text.text = "Max";
                Sword_Required_Gold.SetActive(false);
                Sword_MaxEnhance.SetActive(true);
            }
            else
                SwordLevel_Text.text = Sword_Level.ToString();

            Sword_AttackDamage.text = (10 + (10 * Sword_Level)).ToString();
            Sword_AttackDamage_Upgrade.text = (10 + (10 * (Sword_Level + 1))).ToString();

            Sword_MaxHp.text = (10 + (10 * Sword_Level)).ToString();
            Sword_MaxHp_Upgrade.text = (10 + (10 * (Sword_Level + 1))).ToString();

            Sword_Required_Gold_Price.text = (400 + (200 * Sword_Level)).ToString();

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
                case 0:
                    Sword_Skill_Text.text = "<color=#747474>��ö�� ����: ���������� �������� 5�����Ѵ�. \n\n</color>" +
                                            "<color=#747474>����: ü���� 30%���ϰ� �� �� ���ݷ�, \n</color>" +
                                            "<color=#747474>      ������ 30% ����Ѵ�. \n\n</color>" +
                                            "<color=#747474>���� ��ȣ: ü���� 0�� �Ǵ� ������ ���� �� \n</color>" +
                                            "<color=#747474>           �ѹ� ��ƾ��. (1�� ���� ����)</color>";
                    break;

                case 1:
                    Sword_Skill_Text.text = "��ö�� ����: ���������� �������� 5�����Ѵ�. \n\n" +
                                            "<color=#747474>����: ü���� 30%���ϰ� �� �� ���ݷ�, \n</color>" +
                                            "<color=#747474>      ������ 30% ����Ѵ�. \n\n</color>" +
                                            "<color=#747474>���� ��ȣ: ü���� 0�� �Ǵ� ������ ���� �� \n</color>" +
                                            "<color=#747474>           �ѹ� ��ƾ��. (1�� ���� ����)</color>";
                    Sword_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                    break;

                case 3:
                    Sword_Skill_Text.text = "��ö�� ����: ���������� �������� 5�����Ѵ�. \n\n" +
                                            "����: ü���� 30%���ϰ� �� �� ���ݷ�, \n" +
                                            "      ������ 30% ����Ѵ�. \n\n" +
                                            "<color=#747474>���� ��ȣ: ü���� 0�� �Ǵ� ������ ���� �� \n</color>" +
                                            "<color=#747474>           �ѹ� ��ƾ��. (1�� ���� ����)</color>";
                    Sword_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                    break;

                case 5:
                    Sword_Skill_Text.text = "��ö�� ����: ���������� �������� 5�����Ѵ�. \n\n" +
                                            "����: ü���� 30%���ϰ� �� �� ���ݷ�, \n" +
                                            "      ������ 30% ����Ѵ�. \n\n" +
                                            "���� ��ȣ: ü���� 0�� �Ǵ� ������ ���� �� \n" +
                                            "           �ѹ� ��ƾ��. (1�� ���� ����)";
                    Sword_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                    break;
            }
        }

        if (Weapon.transform.GetChild(1).gameObject.activeSelf == true && Dagger_Level <= 5)
        {
            if (Dagger_Level == 5)
            {
                DaggerLevel_Text.text = "Max";
                Dagger_Required_Gold.SetActive(false);
                Dagger_MaxEnhance.SetActive(true);
            }
            else
                DaggerLevel_Text.text = Dagger_Level.ToString();

            Dagger_AttackDamage.text = (8 + (8 * Dagger_Level)).ToString();
            Dagger_AttackDamage_Upgrade.text = (8 + (8 * (Dagger_Level + 1))).ToString();

            Dagger_Critical.text = (0 + (2 * Dagger_Level)).ToString();
            Dagger_Critical_Upgrade.text = (0 + (2 * (Dagger_Level + 1))).ToString();

            Dagger_Required_Gold_Price.text = (400 + (200 * Dagger_Level)).ToString();

            if (Dagger_Required_Gold.activeSelf == true || Dagger_MaxEnhance.activeSelf == true)
            {
                No_Soyu.SetActive(false);
                if (Player.Instance.stat.weaponType == PlayerWeaponType.Dagger)
                {
                    Jang_cak.SetActive(true);
                    Jang_cak_Btn.SetActive(false);
                    Purchase_Btn.SetActive(false);
                    Enhance_Btn.SetActive(true);
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
                Jang_cak_Btn.SetActive(false);
                Purchase_Btn.SetActive(true);
                Enhance_Btn.SetActive(false);
            }

            switch (Dagger_Level)
            {
                case 0:
                    Dagger_Skill_Text.text ="<color=#747474>�ż�: �̵��ӵ��� 10% �����ϰ� �뽬 \n</color>" +
                                            "<color=#747474>      Ƚ���� 1ȸ �߰��ȴ�. \n\n</color>" +
                                            "<color=#747474>���� ����: �� óġ �� 5�ʰ� �̵��ӵ�, \n</color>" +
                                            "<color=#747474>           ���ݼӵ� 5%����(�ִ� 5��ø) \n\n</color>"+
                                            "<color=#747474>������ ��: 3Ÿ�� �� ���� �������� ������.</color>";
                    break;

                case 1:
                    Dagger_Skill_Text.text ="�ż�: �̵��ӵ��� 10% �����ϰ� �뽬 \n" +
                                            "      Ƚ���� 1ȸ �߰��ȴ�. \n\n" +
                                            "<color=#747474>���� ����: �� óġ �� 5�ʰ� �̵��ӵ�, \n</color>" +
                                            "<color=#747474>           ���ݼӵ� 5%����(�ִ� 5��ø) \n\n</color>" +
                                            "<color=#747474>������ ��: 3Ÿ�� �� ���� �������� ������.</color>";

                    Dagger_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                    break;

                case 3:
                    Dagger_Skill_Text.text ="�ż�: �̵��ӵ��� 10% �����ϰ� �뽬 \n" +
                                            "      Ƚ���� 1ȸ �߰��ȴ�. \n\n" +
                                            "���� ����: �� óġ �� 5�ʰ� �̵��ӵ�, \n" +
                                            "           ���ݼӵ� 5%����(�ִ� 5��ø) \n\n" +
                                            "<color=#747474>������ ��: 3Ÿ�� �� ���� �������� ������.</color>";

                    Dagger_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                    break;

                case 5:
                    Dagger_Skill_Text.text = "�ż�: �̵��ӵ��� 10% �����ϰ� �뽬 \n" +
                                            "      Ƚ���� 1ȸ �߰��ȴ�. \n\n" +
                                            "���� ����: �� óġ �� 5�ʰ� �̵��ӵ�, \n" +
                                            "           ���ݼӵ� 5%����(�ִ� 5��ø) \n\n" +
                                            "������ ��: 3Ÿ�� �� ���� �������� ������.";
                    Dagger_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                    break;
            }
        }

        if (Weapon.transform.GetChild(2).gameObject.activeSelf == true && Axe_Level <= 5)
        {
            if (Axe_Level == 5)
            {
                AxeLevel_Text.text = "Max";
                Axe_Required_Gold.SetActive(false);
                Axe_MaxEnhance.SetActive(true);
            }
            else
                AxeLevel_Text.text = Axe_Level.ToString();

            Axe_AttackDamage.text = (20 + (15 * Axe_Level)).ToString();
            Axe_AttackDamage_Upgrade.text = (20 + (15 * (Axe_Level + 1))).ToString();

            Axe_Defense.text = (400 + (200 * Axe_Level)).ToString();
            Axe_Defense_Upgrade.text = (400 + (200 * (Axe_Level + 1))).ToString();

            Axe_Required_Gold_Price.text = (400 + (200 * Axe_Level)).ToString();

            if (Axe_Required_Gold.activeSelf == true || Axe_MaxEnhance.activeSelf == true)
            {
                No_Soyu.SetActive(false);
                if (Player.Instance.stat.weaponType == PlayerWeaponType.Axe)
                {
                    Jang_cak.SetActive(true);
                    Jang_cak_Btn.SetActive(false);
                    Purchase_Btn.SetActive(false);
                    Enhance_Btn.SetActive(true);
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
                Jang_cak_Btn.SetActive(false);
                Purchase_Btn.SetActive(true);
                Enhance_Btn.SetActive(false);
            }

            switch (Axe_Level)
            {
                case 0:
                    Axe_Skill_Text.text = "<color=#747474>�ε�����: �뽬�� ���������� �����. \n\n</color>" +
                                            "<color=#747474>����: ������ ������ 2�ʵ��� �����Ѵ�. \n\n</color>" +
                                            "<color=#747474>��ȭ : 2��°Ÿ�� ���� �� ȭ�������� \n</color>" +
                                            "<color=#747474>       ��ȯ�� ��θ� ����</color>";
                    break;

                case 1:
                    Axe_Skill_Text.text = "�ε�����: �뽬�� ���������� �����. \n\n" +
                                            "<color=#747474>����: ������ ������ 2�ʵ��� �����Ѵ�. \n\n</color>" +
                                            "<color=#747474>��ȭ : 2��°Ÿ�� ���� �� ȭ�������� \n</color>" +
                                            "<color=#747474>       ��ȯ�� ��θ� ����</color>";

                    Axe_Skill_Text.transform.GetChild(0).gameObject.SetActive(false);
                    break;

                case 3:
                    Axe_Skill_Text.text ="�ε�����: �뽬�� ���������� �����. \n\n" +
                                            "����: ������ ������ 2�ʵ��� �����Ѵ�. \n\n" +
                                            "<color=#747474>��ȭ : 2��°Ÿ�� ���� �� ȭ�������� \n</color>" +
                                            "<color=#747474>       ��ȯ�� ��θ� ����</color>";

                    Axe_Skill_Text.transform.GetChild(1).gameObject.SetActive(false);
                    break;

                case 5:
                    Axe_Skill_Text.text ="�ε�����: �뽬�� ���������� �����. \n\n" +
                                            "����: ������ ������ 2�ʵ��� �����Ѵ�. \n\n" +
                                            "��ȭ : 2��°Ÿ�� ���� �� ȭ�������� \n" +
                                            "       ��ȯ�� ��θ� ����";

                    Axe_Skill_Text.transform.GetChild(2).gameObject.SetActive(false);
                    break;
            }
        }

    }

    #region ��ư Ŭ��
    public void BlackSmith_Click()
    {
        if (Input.GetKeyDown(KeyCode.F) && Collision_Check == false && WindowOpen_Check == false)
        {
            UI_Manager.Inst.Cursor_Fade = true;
            UI_Manager.Inst.PlayerMove_control = true;
            FadeInout.DOFade(0.5f, 1f);
            StartCoroutine(Open_Window());
            WindowOpen_Check = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && BlackSmithWindow_Close == true)
        {
            Close();
        }
    }
    #endregion

    #region â ����
    public void Close()
    {
        StartCoroutine(Close_Window());
    }

    public IEnumerator Open_Window()
    {
        UI_Manager.Inst.Cursor_Fade = true;
        Weapon_Purchase_Window.SetActive(true);
        timer = 0f;
        Pole_01.transform.DOLocalMoveY(452, 0.5f);
        Pole_02.transform.DOLocalMoveY(-452, 0.5f);

        while (timer < 1)
        {
            WeaponPurchase_RectWindow.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(0, 931.6482f, timer));
            timer += Time.deltaTime * 3f;
            yield return null;
        }
        BlackSmithWindow_Close = true;
    }

    public IEnumerator Close_Window()
    {
        if (BlackSmithWindow_Close == true)
        {
            UI_Manager.Inst.Cursor_Fade = false;
            BlackSmithWindow_Close = false;
            FadeInout.DOFade(0f, 1f);

            timer = 0f;
            Pole_01.transform.DOLocalMoveY(30, 0.5f);
            Pole_02.transform.DOLocalMoveY(-30, 0.5f);

            while (timer < 1)
            {
                WeaponPurchase_RectWindow.sizeDelta = new Vector2(1696.425f, Mathf.Lerp(931.6482f, 0, timer));
                timer += Time.deltaTime * 3f;
                yield return null;
            }
            UI_Manager.Inst.PlayerMove_control = false;
            Weapon_Purchase_Window.SetActive(false);
            WindowOpen_Check = false;
        }
    }
    #endregion

    #region �浹 üũ
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = false;
            Upgrade_Text.DOFade(1f, 0.5f);
            F_Button.DOFade(1f, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            Collision_Check = true;
            Upgrade_Text.DOFade(0f, 0.5f);
            F_Button.DOFade(0f, 0.5f);
        }
    }
    #endregion
}
