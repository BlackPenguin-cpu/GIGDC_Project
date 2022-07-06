using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BlackSmith_Btn : MonoBehaviour, IPointerEnterHandler
{
    float timer;

    public enum MouseOver_UI
    {
        MouseOver = 0,
        None = 1
    }
    public MouseOver_UI mouseover_UI;


    void Start()
    {

    }

    void Update()
    {


    }

    #region 버튼 클릭

    public void Left_Arrow()
    {
        if (mouseover_UI == MouseOver_UI.MouseOver)
        {
            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
            int Save_BlackSmiths = BlackSmith.Inst.BlackSmiths.Count;
            BlackSmith.Inst.BlackSmiths[0].SetActive(false);

            BlackSmith.Inst.BlackSmiths.Insert(0, BlackSmith.Inst.BlackSmiths[Save_BlackSmiths - 1]);
            BlackSmith.Inst.BlackSmiths.RemoveAt(Save_BlackSmiths);
            BlackSmith.Inst.BlackSmiths[0].SetActive(true);
        }
    }

    public void Right_Arrow()
    {
        if (mouseover_UI == MouseOver_UI.MouseOver)
        {
            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
            BlackSmith.Inst.BlackSmiths[0].SetActive(false);

            BlackSmith.Inst.BlackSmiths.Add(BlackSmith.Inst.BlackSmiths[0]);
            BlackSmith.Inst.BlackSmiths.RemoveAt(0);
            BlackSmith.Inst.BlackSmiths[0].SetActive(true);
        }
    }

    public void Purchase_Click()
    {
        int Gold = 300;
        if (mouseover_UI == MouseOver_UI.MouseOver)
        {
            //단검
            if (BlackSmith.Inst.Weapon.transform.GetChild(1).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= Gold)
            {
                SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                SoundManager.instance.PlaySoundClip("SFX_Buy", SoundType.SFX, 5f);
                UI_Manager.Inst.Gold -= Gold; // 골드 차감
                BlackSmith.Inst.Dagger_Price.SetActive(false); // 구매가격 false
                BlackSmith.Inst.Dagger_Required_Gold.SetActive(true); // 강화 가격 true
                Player.Instance.stat.weaponType = PlayerWeaponType.Dagger; // 무기 단검으로 바뀜
                BlackSmith.Inst.Purchase_Btn.SetActive(false); // 구매 버튼 false
                BlackSmith.Inst.Enhance_Btn.SetActive(true); // 강화 버튼 true
            }
            else if (UI_Manager.Inst.Gold < Gold)
                SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);


            //도끼
            if (BlackSmith.Inst.Weapon.transform.GetChild(2).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= Gold)
            {
                SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                SoundManager.instance.PlaySoundClip("SFX_Buy", SoundType.SFX, 5f);
                UI_Manager.Inst.Gold -= Gold; // 골드 차감
                BlackSmith.Inst.Axe_Price.SetActive(false); // 구매가격 false
                BlackSmith.Inst.Axe_Required_Gold.SetActive(true); // 강화 가격 true
                Player.Instance.stat.weaponType = PlayerWeaponType.Axe; // 무기 도끼으로 바뀜
                BlackSmith.Inst.Purchase_Btn.SetActive(false); // 구매 버튼 false
                BlackSmith.Inst.Enhance_Btn.SetActive(true); // 강화 버튼 true
            }
            else if(UI_Manager.Inst.Gold < Gold)
                SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
        }

    }

    public void JangCak_Click()
    {
        if (mouseover_UI == MouseOver_UI.MouseOver)
        {
            if (BlackSmith.Inst.Weapon.transform.GetChild(0).gameObject.activeSelf == true)
            {
                SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                Player.Instance.stat.weaponType = PlayerWeaponType.Sword;
            }
            else if (BlackSmith.Inst.Weapon.transform.GetChild(1).gameObject.activeSelf == true)
            {
                SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                Player.Instance.stat.weaponType = PlayerWeaponType.Dagger;
            }
            else if (BlackSmith.Inst.Weapon.transform.GetChild(2).gameObject.activeSelf == true)
            {
                SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                Player.Instance.stat.weaponType = PlayerWeaponType.Axe;
            }
        }

    }

    public void Enhance_Click()
    {
        int Sword_Level = Player.Instance.stat._level[PlayerWeaponType.Sword];
        int Dagger_Level = Player.Instance.stat._level[PlayerWeaponType.Dagger];
        int Axe_Level = Player.Instance.stat._level[PlayerWeaponType.Axe];
        if (mouseover_UI == MouseOver_UI.MouseOver)
        {
            switch (Player.Instance.stat.weaponType)
            {
                case PlayerWeaponType.Sword:
                    if (BlackSmith.Inst.Weapon.transform.GetChild(0).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Sword_Level)))
                    {
                        if (Sword_Level < 5)
                        {
                            SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);
                            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                            UI_Manager.Inst.Gold -= (400 + (200 * Sword_Level));
                            Player.Instance.stat._level[PlayerWeaponType.Sword]++;
                        }
                        else
                            SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    }
                    else if (UI_Manager.Inst.Gold < (400 + (200 * Sword_Level)))
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case PlayerWeaponType.Dagger:
                    if (BlackSmith.Inst.Weapon.transform.GetChild(1).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Dagger_Level)))
                    {
                        if (Dagger_Level < 5)
                        {
                            SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);
                            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                            UI_Manager.Inst.Gold -= (400 + (200 * Dagger_Level));
                            Player.Instance.stat._level[PlayerWeaponType.Dagger]++;
                        }
                        else
                            SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    }
                    else if (UI_Manager.Inst.Gold < (400 + (200 * Sword_Level)))
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;

                case PlayerWeaponType.Axe:
                    if (BlackSmith.Inst.Weapon.transform.GetChild(2).gameObject.activeSelf == true && UI_Manager.Inst.Gold >= (400 + (200 * Axe_Level)))
                    {
                        if (Axe_Level < 5)
                        {
                            SoundManager.instance.PlaySoundClip("SFX_Enforce", SoundType.SFX);
                            SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
                            UI_Manager.Inst.Gold -= (400 + (200 * Axe_Level));
                            Player.Instance.stat._level[PlayerWeaponType.Axe]++;
                        }
                        else
                            SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);

                    }
                    else if (UI_Manager.Inst.Gold < (400 + (200 * Sword_Level)))
                        SoundManager.instance.PlaySoundClip("SFX_Error", SoundType.SFX);
                    break;
            }
        }
    }
    #endregion

    public void Close()
    {
        SoundManager.instance.PlaySoundClip("SFX_Button_Click", SoundType.SFX);
        StartCoroutine(BlackSmith.Inst.Close_Window());
    }

    public void OnPointerEnter(PointerEventData eventDatas)
    {
        if (mouseover_UI == MouseOver_UI.MouseOver)
            SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
    }
}
