using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ItemCard_Mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public enum Direction
    {
        Left,
        Among,
        Right
    }

    public Direction direction;
    float timer = 0;

    [Header("Ȯ��")]
    int LeftClick_Check = 1;
    bool LeftCloseWindow_Check = true;

    int AmongClick_Check = 1;
    bool AmongCloseWindow_Check = true;

    int RightClick_Check = 1;
    bool RightCloseWindow_Check = true;

    [Header("��")]
    public Image Left_Light;
    public Image Among_Light;
    public Image Right_Light;

    [Header("������ â")]
    public GameObject Left_Window;
    public GameObject Among_Window;
    public GameObject Right_Window;

    [Header("������ �� / ���")]
    //����
    public GameObject Left_Pole_01;
    public GameObject Left_Pole_02;
    public RectTransform Left_Rect;

    // ���
    public GameObject Among_Pole_01;
    public GameObject Among_Pole_02;
    public RectTransform Among_Rect;

    // ������
    public GameObject Right_Pole_01;
    public GameObject Right_Pole_02;
    public RectTransform Right_Rect;

    void Start()
    {
        Card_Manager.Inst.Left_Pick = true;
        Card_Manager.Inst.Among_Pick = true;
        Card_Manager.Inst.Right_Pick = true;
    }

    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (direction)
        {
            case Direction.Left:
                if (Card_Manager.Inst.Among_Pick == true && Card_Manager.Inst.Right_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
                {
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Left_Light.DOFade(1f, 0.5f);
                }
                break;

            case Direction.Among:
                if (Card_Manager.Inst.Left_Pick == true && Card_Manager.Inst.Right_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
                {
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Among_Light.DOFade(1f, 0.5f);
                }
                break;

            case Direction.Right:
                if (Card_Manager.Inst.Left_Pick == true && Card_Manager.Inst.Among_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
                {
                    SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
                    Right_Light.DOFade(1f, 0.5f);
                }
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (direction == Direction.Left)
            Left_Light.DOFade(0f, 0.5f);

        if (direction == Direction.Among)
            Among_Light.DOFade(0f, 0.5f);

        if (direction == Direction.Right)
            Right_Light.DOFade(0f, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ���� ī�带 ���� ���� ��
        if (direction == Direction.Left)
        {
            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);

            Card_Manager.Inst.Fade.DOFade(0f, 0.5f);
            UI_Manager.Inst.Cursor_Fade = false;

            if (Card_Manager.Inst.Left_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
            {
                Card_Manager.Inst.Left_Pick = false;
                Card_Manager.Inst.Right_Pick = false;
                Card_Manager.Inst.Among_Pick = false;

                // �� �� ��ű��� �������� ��
                if (Card_Manager.Inst.DA_Left == false)
                {
                    for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                    {
                        if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.ItemDA_LeftCheck[0].Itme_Name)
                        {
                            Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.DABuffer[i]);
                            Card_Manager.Inst.DABuffer.RemoveAt(i);
                        }
                    }

                    switch (Card_Manager.Inst.ItemDA_LeftCheck[0].Itme_Name)
                    {
                        case "�ٶ��� �Ͱ���":
                            Player.Instance.stat.PlayerDATypeList.WindEarRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.WindEarRing);
                            break;

                        case "���ð߰�":
                            Player.Instance.stat.PlayerDATypeList.NeedleArmour = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.NeedleArmour);
                            break;

                        case "Į������":
                            Player.Instance.stat.PlayerDATypeList.KnifeCape = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.KnifeCape);
                            break;

                        case "���ֹ��� �ܰ�":
                            Player.Instance.stat.PlayerDATypeList.CurseKnife = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CurseKnife);
                            break;

                        case "���� �尩":
                            Player.Instance.stat.PlayerDATypeList.BloodGauntlet = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.BloodGauntlet);
                            break;

                        case "������":
                            Player.Instance.stat.PlayerDATypeList.CrystalOrb = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CrystalOrb);
                            break;

                        case "�������":
                            Player.Instance.stat.PlayerDATypeList.TheOneRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.TheOneRing);
                            break;

                    }

                }

                // �������� �������� ��
                if (Card_Manager.Inst.DA_Left == true)
                {
                    switch (Card_Manager.Inst.ItemDA_LeftCheck[0].Itme_Name)
                    {
                        case "���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.POWER]++;
                            break;

                        case "�ż��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.SPEED]++;
                            break;

                        case "������ ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.ATTACKSPEED]++;
                            break;

                        case "ü���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.HEALTH]++;
                            break;

                        case "�ð��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.TIME]++;
                            break;

                        case "����� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.DEFFENCE]++;
                            break;
                    }
                }


                if (Card_Manager.Inst.Item_Left == false)
                    Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.ItemDA_LeftCheck[0]);

                if (Card_Manager.Inst.Item_bool == true)
                    Card_Manager.Inst.Item_bool = false;

                else if (Card_Manager.Inst.Item_bool == false)
                    Card_Manager.Inst.Item_Check += LeftClick_Check;


                if (Card_Manager.Inst.TimeItem_Count <= 2)
                {
                    Card_Manager.Inst.Time_Item_Limit.Add(Card_Manager.Inst.ItemDA_LeftCheck[0]);
                    for (int i = 0; i < Card_Manager.Inst.Time_Item_Limit.Count; i++)
                    {
                        if (Card_Manager.Inst.Time_Item_Limit[i].Itme_Name.Contains(Card_Manager.Inst.ItemBuffer[4].Itme_Name))
                        {
                            Card_Manager.Inst.TimeItem_Count++;
                            Card_Manager.Inst.Time_Item_Limit.Clear();
                        }
                    }
                }

                Left_Light.DOFade(1f, 0.1f);
                Left_Window.transform.DOLocalMoveY(1100, 0.5f).SetEase(Ease.InQuad);
                StartCoroutine(Close_Dot());
            }
        }

        // ��� ī�带 ���� ���� ��
        if (direction == Direction.Among)
        {
            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);

            Card_Manager.Inst.Fade.DOFade(0f, 0.5f);
            UI_Manager.Inst.Cursor_Fade = false;

            if (Card_Manager.Inst.Among_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
            {
                Card_Manager.Inst.Among_Pick = false;
                Card_Manager.Inst.Left_Pick = false;
                Card_Manager.Inst.Right_Pick = false;

                // �� �� ��ű��� �������� ��
                if (Card_Manager.Inst.DA_Among == false)
                {
                    for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                    {
                        if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.ItemDA_AmongCheck[0].Itme_Name)
                        {
                            Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.DABuffer[i]);
                            Card_Manager.Inst.DABuffer.RemoveAt(i);
                        }
                    }

                    switch (Card_Manager.Inst.ItemDA_AmongCheck[0].Itme_Name)
                    {
                        case "�ٶ��� �Ͱ���":
                            Player.Instance.stat.PlayerDATypeList.WindEarRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.WindEarRing);
                            break;

                        case "���ð߰�":
                            Player.Instance.stat.PlayerDATypeList.NeedleArmour = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.NeedleArmour);
                            break;

                        case "Į������":
                            Player.Instance.stat.PlayerDATypeList.KnifeCape = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.KnifeCape);
                            break;

                        case "���ֹ��� �ܰ�":
                            Player.Instance.stat.PlayerDATypeList.CurseKnife = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CurseKnife);
                            break;

                        case "���� �尩":
                            Player.Instance.stat.PlayerDATypeList.BloodGauntlet = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.BloodGauntlet);
                            break;

                        case "������":
                            Player.Instance.stat.PlayerDATypeList.CrystalOrb = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CrystalOrb);
                            break;

                        case "�������":
                            Player.Instance.stat.PlayerDATypeList.TheOneRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.TheOneRing);
                            break;

                    }
                }

                // �������� �������� ��
                if (Card_Manager.Inst.DA_Among == true)
                {
                    switch (Card_Manager.Inst.ItemDA_AmongCheck[0].Itme_Name)
                    {
                        case "���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.POWER]++;
                            break;

                        case "�ż��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.SPEED]++;
                            break;

                        case "������ ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.ATTACKSPEED]++;
                            break;

                        case "ü���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.HEALTH]++;
                            break;

                        case "�ð��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.TIME]++;
                            break;

                        case "����� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.DEFFENCE]++;
                            break;
                    }
                }


                if (Card_Manager.Inst.Item_Among == false)
                    Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.ItemDA_AmongCheck[0]);

                if (Card_Manager.Inst.Item_bool == true)
                    Card_Manager.Inst.Item_bool = false;

                else if (Card_Manager.Inst.Item_bool == false)
                    Card_Manager.Inst.Item_Check += AmongClick_Check;

                if (Card_Manager.Inst.TimeItem_Count <= 2)
                {
                    Card_Manager.Inst.Time_Item_Limit.Add(Card_Manager.Inst.ItemDA_AmongCheck[0]);
                    for (int i = 0; i < Card_Manager.Inst.Time_Item_Limit.Count; i++)
                    {
                        if (Card_Manager.Inst.Time_Item_Limit[i].Itme_Name.Contains(Card_Manager.Inst.ItemBuffer[4].Itme_Name))
                        {
                            Card_Manager.Inst.TimeItem_Count++;
                            Card_Manager.Inst.Time_Item_Limit.Clear();
                        }
                    }
                }

                Among_Light.DOFade(1f, 0.1f);
                Among_Window.transform.DOLocalMoveY(1150, 0.5f).SetEase(Ease.InQuad);
                StartCoroutine(Close_Dot());
            }

        }

        // ������ ī�带 ���� ���� ��
        if (direction == Direction.Right)
        {
            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);

            Card_Manager.Inst.Fade.DOFade(0f, 0.5f);
            UI_Manager.Inst.Cursor_Fade = false;

            if (Card_Manager.Inst.Right_Pick == true && Card_Manager.Inst.ItemCard_OpenCheck == false)
            {
                Card_Manager.Inst.Right_Pick = false;
                Card_Manager.Inst.Left_Pick = false;
                Card_Manager.Inst.Among_Pick = false;

                // �� �� ��ű��� �������� ��
                if (Card_Manager.Inst.DA_Right == false)
                {
                    for (int i = 0; i < Card_Manager.Inst.DABuffer.Count; i++)
                    {
                        if (Card_Manager.Inst.DABuffer[i].Itme_Name == Card_Manager.Inst.ItemDA_RightCheck[0].Itme_Name)
                        {
                            Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.DABuffer[i]);
                            Card_Manager.Inst.DABuffer.RemoveAt(i);
                        }
                    }

                    switch (Card_Manager.Inst.ItemDA_RightCheck[0].Itme_Name)
                    {
                        case "�ٶ��� �Ͱ���":
                            Player.Instance.stat.PlayerDATypeList.WindEarRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.WindEarRing);
                            break;

                        case "���ð߰�":
                            Player.Instance.stat.PlayerDATypeList.NeedleArmour = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.NeedleArmour);
                            break;

                        case "Į������":
                            Player.Instance.stat.PlayerDATypeList.KnifeCape = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.KnifeCape);
                            break;

                        case "���ֹ��� �ܰ�":
                            Player.Instance.stat.PlayerDATypeList.CurseKnife = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CurseKnife);
                            break;

                        case "���� �尩":
                            Player.Instance.stat.PlayerDATypeList.BloodGauntlet = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.BloodGauntlet);
                            break;

                        case "������":
                            Player.Instance.stat.PlayerDATypeList.CrystalOrb = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.CrystalOrb);
                            break;

                        case "�������":
                            Player.Instance.stat.PlayerDATypeList.TheOneRing = true;
                            Debug.Log(Player.Instance.stat.PlayerDATypeList.TheOneRing);
                            break;

                    }
                }

                // �������� �������� ��
                if (Card_Manager.Inst.DA_Right == true)
                {
                    switch (Card_Manager.Inst.ItemDA_RightCheck[0].Itme_Name)
                    {
                        case "���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.POWER]++;
                            break;

                        case "�ż��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.SPEED]++;
                            break;

                        case "������ ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.ATTACKSPEED]++;
                            break;

                        case "ü���� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.HEALTH]++;
                            break;

                        case "�ð��� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.TIME]++;
                            break;

                        case "����� ������":
                            Player.Instance.stat.Crystals[(int)CrystalsType.DEFFENCE]++;
                            break;
                    }
                }

                if (Card_Manager.Inst.Item_Right == false)
                    Stop_Manager.Inst.ItemDA_Have.Add(Card_Manager.Inst.ItemDA_RightCheck[0]);

                if (Card_Manager.Inst.Item_bool == true)
                    Card_Manager.Inst.Item_bool = false;

                else if (Card_Manager.Inst.Item_bool == false)
                    Card_Manager.Inst.Item_Check += RightClick_Check;

                if (Card_Manager.Inst.TimeItem_Count <= 2)
                {
                    Card_Manager.Inst.Time_Item_Limit.Add(Card_Manager.Inst.ItemDA_RightCheck[0]);
                    for (int i = 0; i < Card_Manager.Inst.Time_Item_Limit.Count; i++)
                    {
                        if (Card_Manager.Inst.Time_Item_Limit[i].Itme_Name.Contains(Card_Manager.Inst.ItemBuffer[4].Itme_Name))
                        {
                            Card_Manager.Inst.TimeItem_Count++;
                            Card_Manager.Inst.Time_Item_Limit.Clear();
                        }
                    }
                }

                Right_Light.DOFade(1f, 0.1f);
                Right_Window.transform.DOLocalMoveY(1150, 0.5f).SetEase(Ease.InQuad);
                StartCoroutine(Close_Dot());
            }
        }
    }

    public IEnumerator Close_Dot()
    {
        timer = 0;
        if (direction == Direction.Left)
        {
            Among_Pole_01.transform.DOLocalMoveY(-53f, 0.5f);
            Among_Pole_02.transform.DOLocalMoveY(-125f, 0.5f);

            Right_Pole_01.transform.DOLocalMoveY(-32f, 0.5f);
            Right_Pole_02.transform.DOLocalMoveY(-108f, 0.5f);

            while (timer < 1)
            {
                Among_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                Right_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                timer += Time.deltaTime * 3f;
                yield return null;
            }

            LeftCloseWindow_Check = false;
            if (LeftCloseWindow_Check == false)
            {
                yield return new WaitForSeconds(0.2f);
                DOTween.PauseAll();
                Destroy(GameObject.Find("Item_Window(Clone)"));
            }
        }

        if (direction == Direction.Among)
        {
            Left_Pole_01.transform.DOLocalMoveY(50f, 0.5f);
            Left_Pole_02.transform.DOLocalMoveY(-26f, 0.5f);

            Right_Pole_01.transform.DOLocalMoveY(-32f, 0.5f);
            Right_Pole_02.transform.DOLocalMoveY(-108f, 0.5f);

            while (timer < 1)
            {
                Left_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                Right_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                timer += Time.deltaTime * 3f;
                yield return null;
            }

            AmongCloseWindow_Check = false;
            if (AmongCloseWindow_Check == false)
            {
                yield return new WaitForSeconds(0.2f);
                DOTween.PauseAll();
                Destroy(GameObject.Find("Item_Window(Clone)"));
            }
        }

        if (direction == Direction.Right)
        {
            Left_Pole_01.transform.DOLocalMoveY(50f, 0.5f);
            Left_Pole_02.transform.DOLocalMoveY(-26f, 0.5f);

            Among_Pole_01.transform.DOLocalMoveY(-53f, 0.5f);
            Among_Pole_02.transform.DOLocalMoveY(-125f, 0.5f);

            while (timer < 1)
            {
                Left_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                Among_Rect.sizeDelta = new Vector2(522.6044f, Mathf.Lerp(824.77f, -20, timer));
                timer += Time.deltaTime * 3f;
                yield return null;
            }

            RightCloseWindow_Check = false;
            if (RightCloseWindow_Check == false)
            {
                yield return new WaitForSeconds(0.2f);
                DOTween.PauseAll();
                Destroy(GameObject.Find("Item_Window(Clone)"));
            }
        }
    }
}
