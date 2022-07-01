using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    #region ����
    int Magic_00 = 700 + Player.Instance.stat._level * 150;
    int Magic_01 = 1100 + Player.Instance.stat._level * 200;
    int Magic_02 = 1700 + Player.Instance.stat._level * 250;
    int Magic_03 = 3300 + Player.Instance.stat._level * 3000;

    int Body_00 = 600 + Player.Instance.stat._level * 150;
    int Body_01 = 1000 + Player.Instance.stat._level * 200;
    int Body_02 = 1500 + Player.Instance.stat._level * 250;
    int Body_03 = 3000 + Player.Instance.stat._level * 3000;
    #endregion

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
                    Foundation.Inst.Title.text = "������ �ʴ� ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_00;
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_00;
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_00;
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_00;
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " �����Ѵ�.";
                            break;
                    }
                    break;

                case 1:
                    Foundation.Inst.Title.text = "��վ�� ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_01;
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_01;
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "3% / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_01;
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "5% / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_01;
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "7% / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "10%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 2:
                    Foundation.Inst.Title.text = "�ð�����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_02;
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_02;
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_02;
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10% / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_02;
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "15% / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "20%" + " �����Ѵ�.";
                            break;
                    }
                    break;

                case 3:
                    Foundation.Inst.Title.text = "���ݼ�";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_03;
                            Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " �����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Magic_03;
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
                    Foundation.Inst.Title.text = "���ǵ��� ����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_00;
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_00;
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� 10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_00;
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_00;
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 1:
                    Foundation.Inst.Title.text = "������ ��";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_01;
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_01;
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� 15% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_01;
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_01;
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "45% / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "60%" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 2:
                    Foundation.Inst.Title.text = "��ö �Ǻ�";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_02;
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_02;
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ 5 / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 2:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_02;
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "10 / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 3:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_02;
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "15 / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                            break;

                        case 4:
                            Foundation.Inst.Dimensional_Price.text = "Max";
                            Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "20" + " ����Ѵ�.";
                            break;
                    }
                    break;

                case 3:
                    Foundation.Inst.Title.text = "������ ����";
                    MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                    switch (Malyeog_Upgrade)
                    {
                        case 0:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_03;
                            Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "50%" + "</color>" + " ����Ѵ�.";
                            break;

                        case 1:
                            Foundation.Inst.Dimensional_Price.text = "" + Body_03;
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
                    if (UI_Manager.Inst.Dimensional >= Magic_00 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Magic_00;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.invisibleHand += 10;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ �ʴ� �յ��� �Բ� ������ ���� �ӵ��� " + "\n" + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " �����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 1:
                    if (UI_Manager.Inst.Dimensional >= Magic_01 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Magic_01;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Player.Instance.stat.magicPower.sharpEye = 3;
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" +  "3% / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Player.Instance.stat.magicPower.sharpEye = 5;
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "5% / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Player.Instance.stat.magicPower.sharpEye = 7;
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "7% / " + "<color=#877D78>" + "10%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Player.Instance.stat.magicPower.sharpEye = 10;
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ����� ������ ��վ�� ġ��Ÿ Ȯ���� " + "\n" + "<color=#877D78>" + "3%" + "</color>" + " / " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "7%" + "</color>" + " / " + "10%" + " ����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 2:
                    if (UI_Manager.Inst.Dimensional >= Magic_02 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Magic_02;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.timeQuick += 5;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10% / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "15% / " + "<color=#877D78>" + "20%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "�ð��� ���� ���Ѽ� ��Ÿ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "15%" + "</color>" + " / " + "20%" + " �����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 3:
                    if (UI_Manager.Inst.Dimensional >= Magic_03 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Magic_03;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                        Player.Instance.stat.magicPower.thaumcraft += 20;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "5% / " + "<color=#877D78>" + "10%" + "</color>" + " �����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "�ݴ��� ���ݼ��� ����� ȹ���ϴ� ����� ���� " + "<color=#877D78>" + "5%" + "</color>" + " / " + "10%" + " �����Ѵ�.";
                                break;
                        }
                    }
                    break;
            }
        }

        if (malyeog == Malyeog.Body)
        {
            switch (Malyeog_Num)
            {
                case 0:
                    if (UI_Manager.Inst.Dimensional >= Body_00 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Body_00;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.silpidLeap += 10;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� 10% / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "20% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "40%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "���ǵ��� ��������� �뽬Ƚ���� 1 �����ϰ� �̵� �ӵ��� " + "<color=#877D78>" + "10%" + "</color>" + " / " + "<color=#877D78>" + "20%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "40%" + " ����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 1:
                    if (UI_Manager.Inst.Dimensional >= Body_01 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Body_01;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.giantPower += 15;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� 15% / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "30% / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "45% / " + "<color=#877D78>" + "60%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ���� �޾� ���ݷ��� " + "<color=#877D78>" + "15%" + "</color>" + " / " + "<color=#877D78>" + "30%" + "</color>" + " / " + "<color=#877D78>" + "45%" + "</color>" + " / " + "60%" + " ����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 2:
                    if (UI_Manager.Inst.Dimensional >= Body_02 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Body_02;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/4";
                        Player.Instance.stat.magicPower.ironSkin += 5;
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ 5 / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "10 / " + "<color=#877D78>" + "15" + "</color>" + " / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 3:
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "15 / " + "<color=#877D78>" + "20" + "</color>" + " ����Ѵ�.";
                                break;

                            case 4:
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "��ö���� �Ǻθ� ��� ������ " + "<color=#877D78>" + "5" + "</color>" + " / " + "<color=#877D78>" + "10" + "</color>" + " / " + "<color=#877D78>" + "15" + "</color>" + " / " + "20" + " ����Ѵ�.";
                                break;
                        }
                    }
                    break;

                case 3:
                    if (UI_Manager.Inst.Dimensional >= Body_03 && Foundation.Inst.Dimensional_Price.text != "Max")
                    {
                        Malyeog_Upgrade++;
                        UI_Manager.Inst.Dimensional -= Body_03;
                        MalyeogUp_Text.text = Malyeog_Upgrade + "/2";
                        switch (Malyeog_Upgrade)
                        {
                            case 1:
                                Player.Instance.stat.magicPower.magicHeart += 20;
                                Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� 20% / " + "<color=#877D78>" + "50%" + "</color>" + " ����Ѵ�.";
                                break;

                            case 2:
                                Player.Instance.stat.magicPower.magicHeart += 50;
                                Foundation.Inst.Dimensional_Price.text = "Max";
                                Foundation.Inst.Explanation.text = "������ ������ �ι�° ��ȸ�� �� �ִ�ü���� " + "<color=#877D78>" + "20%" + "</color>" + " / " + "50%" + " ����Ѵ�.";
                                break;
                        }
                    }
                    break;
            }
        }
    }

}
