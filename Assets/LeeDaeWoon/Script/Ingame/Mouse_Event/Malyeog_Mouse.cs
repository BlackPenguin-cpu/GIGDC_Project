using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Malyeog_Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum Malyeog
    {
        Magic,
        Body
    }

    [Header("���� ��ȭ")]
    [SerializeField] Malyeog malyeog;
    public int Malyeog_Num; // ���� ��ȭ ����
    public int Malyeog_Upgrade; // ���� ��ȭ ���׷��̵�
    public Text MalyeogUp_Text; // ���� ��ȭ �ؽ�Ʈ

    [Header("��ų �������")]
    public bool BodyOpen_Check = false;
    public bool MagicOpen_Check = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (malyeog == Malyeog.Magic)
        {
            Foundation.Inst.Price_obj.SetActive(true);
            Foundation.Inst.Close_Btn.SetActive(false);
            switch (Malyeog_Num)
            {
                case 0:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "������ �ʴ� ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " �����Ѵ�.";
                            break;
                    }
                    break;

                case 1:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "��վ�� ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "3% / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "5% / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "7% / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "10%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 2:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "�ð�����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10% / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "15% / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "20%" + " �����Ѵ�.";
                            break;
                    }
                    break;

                case 3:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "���ݼ�";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (3300 + Malyeog_Upgrade * 3000);
                            Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (3300 + Malyeog_Upgrade * 3000);
                            Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10%" + " �����Ѵ�.";
                            break;
                    }
                    break;
            }
        }

        if (malyeog == Malyeog.Body)
        {
            Foundation.Inst.Price_obj.SetActive(true);
            Foundation.Inst.Close_Btn.SetActive(false);
            switch (Malyeog_Num)
            {
                case 0:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "���ǵ��� ����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� 10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 1:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "������ ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� 15% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "45% / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "60%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 2:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "��ö �Ǻ�";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ 5 / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "10 / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "15 / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "20" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 3:
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Foundation.Inst.Title.text = "������ ����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + (3000 + Malyeog_Upgrade * 3000);
                            Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "50%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + (3000 + Malyeog_Upgrade * 3000);
                            Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� 20% / " + "<color=#877D78>" + "50%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� " + "<color=#877D78>" + "20%" + "</color>" + " / " + "50%" + " ����Ѵ�.";
                            break;
                    }
                    break;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Foundation.Inst.Price_obj.SetActive(false);
        Foundation.Inst.Close_Btn.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (malyeog == Malyeog.Magic)
        {
            switch (Malyeog_Num)
            {
                case 0:
                    if (UI_Manager.Inst.Dimensional >= (700 + Malyeog_Upgrade * 150) && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);

                        UI_Manager.Inst.Dimensional -= (700 + Malyeog_Upgrade * 150);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.invisibleHand++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Dimensional_Price.text = "" + (700 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " �����Ѵ�.";
                                break;
                        }

                        MagicOpen_Check = true;
                        if (MagicOpen_Check == true && Foundation.Inst.Magic_Open == Malyeog_Num)
                            Foundation.Inst.Magic_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 1:
                    if (UI_Manager.Inst.Dimensional >= (1100 + Malyeog_Upgrade * 200) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Magic_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);


                        UI_Manager.Inst.Dimensional -= (1100 + Malyeog_Upgrade * 200);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Player.Instance.stat.magicPower.sharpEye = 1;
                                Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "3% / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Player.Instance.stat.magicPower.sharpEye = 2;
                                Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "5% / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Player.Instance.stat.magicPower.sharpEye = 3;
                                Foundation.Inst.Dimensional_Price.text = "" + (1100 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "7% / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Player.Instance.stat.magicPower.sharpEye = 4;
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "10%" + " ����Ѵ�.";
                                break;
                        }

                        MagicOpen_Check = true;
                        if (MagicOpen_Check == true && Foundation.Inst.Magic_Open == Malyeog_Num)
                            Foundation.Inst.Magic_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 2:
                    if (UI_Manager.Inst.Dimensional >= (1700 + Malyeog_Upgrade * 250) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Magic_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);


                        UI_Manager.Inst.Dimensional -= (1700 + Malyeog_Upgrade * 250);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.timeQuick++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10% / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Dimensional_Price.text = "" + (1700 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "15% / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "20%" + " �����Ѵ�.";
                                break;
                        }

                        MagicOpen_Check = true;
                        if (MagicOpen_Check == true && Foundation.Inst.Magic_Open == Malyeog_Num)
                            Foundation.Inst.Magic_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 3:
                    if (UI_Manager.Inst.Dimensional >= (3300 + Malyeog_Upgrade * 3000) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Magic_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);


                        UI_Manager.Inst.Dimensional -= (3300 + Malyeog_Upgrade * 3000);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                        Player.Instance.stat.magicPower.thaumcraft++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (3300 + Malyeog_Upgrade * 3000);
                                Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10%" + " �����Ѵ�.";
                                break;
                        }
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;
            }
        }

        if (malyeog == Malyeog.Body)
        {
            switch (Malyeog_Num)
            {
                case 0:
                    if (UI_Manager.Inst.Dimensional >= (600 + Malyeog_Upgrade * 150) && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);


                        UI_Manager.Inst.Dimensional -= (600 + Malyeog_Upgrade * 150);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.silpidLeap++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� 10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Dimensional_Price.text = "" + (600 + Malyeog_Upgrade * 150);
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " ����Ѵ�.";
                                break;
                        }

                        BodyOpen_Check = true;
                        if (BodyOpen_Check == true && Foundation.Inst.Body_Open == Malyeog_Num)
                            Foundation.Inst.Body_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 1:
                    if (UI_Manager.Inst.Dimensional >= (1000 + Malyeog_Upgrade * 200) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Body_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);


                        UI_Manager.Inst.Dimensional -= (1000 + Malyeog_Upgrade * 200);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.giantPower++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� 15% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Dimensional_Price.text = "" + (1000 + Malyeog_Upgrade * 200);
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "45% / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "60%" + " ����Ѵ�.";
                                break;
                        }

                        BodyOpen_Check = true;
                        if (BodyOpen_Check == true && Foundation.Inst.Body_Open == Malyeog_Num)
                            Foundation.Inst.Body_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 2:
                    if (UI_Manager.Inst.Dimensional >= (1500 + Malyeog_Upgrade * 250) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Body_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);

                        UI_Manager.Inst.Dimensional -= (1500 + Malyeog_Upgrade * 250);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.ironSkin++;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ 5 / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "10 / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Dimensional_Price.text = "" + (1500 + Malyeog_Upgrade * 250);
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "15 / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "20" + " ����Ѵ�.";
                                break;
                        }

                        BodyOpen_Check = true;
                        if (BodyOpen_Check == true && Foundation.Inst.Body_Open == Malyeog_Num)
                            Foundation.Inst.Body_Open++;
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case 3:
                    if (UI_Manager.Inst.Dimensional >= (3000 + Malyeog_Upgrade * 3000) && Foundation.Inst.Dimensional_Price.text != "Max" && Foundation.Inst.Body_Open >= Malyeog_Num)
                    {
                        SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);

                        UI_Manager.Inst.Dimensional -= (3000 + Malyeog_Upgrade * 3000);

                        Malyeog_Upgrade++;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Player.Instance.stat.magicPower.magicHeart++;
                                Foundation.Inst.Dimensional_Price.text = "" + (3000 + Malyeog_Upgrade * 3000);
                                Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� 20% / " + "<color=#877D78>" + "50%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Player.Instance.stat.magicPower.magicHeart++;
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� " + "<color=#877D78>" + "20%" + "</color>" + " / " + "50%" + " ����Ѵ�.";
                                break;
                        }
                    }
                    else
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;
            }
        }
    }

}
