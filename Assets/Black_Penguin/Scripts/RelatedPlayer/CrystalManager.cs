using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public enum CrystalsType
{
    POWER,
    SPEED,
    ATTACKSPEED,
    HEALTH,
    TIME,
    DEFFENCE,
    END
}

public class CrystalManager : MonoBehaviour
{
    private int[] crystals = new int[(int)CrystalsType.END];
    public int[] _crystals
    {
        get => crystals;
        set
        {
            Player.Instance.stat.Crystals = value;
            crystals = value;
        }
    }
    public CrystalsType CrtstalReturn()
    {
        CrystalsType index;
        do
        {
            index = (CrystalsType)Random.Range(0, (int)CrystalsType.END);
        }
        while (!CrystalCreateRule(index));
        return index;
    }
    bool CrystalCreateRule(CrystalsType type)
    {
        if (type == CrystalsType.TIME && crystals[(int)CrystalsType.TIME] >= 3)
        {
            return false;
        }
        //이쪽 수정 필요 ㅎㅎ
        if (type == CrystalsType.ATTACKSPEED && Player.Instance.stat._attackSpeed <= 0.1f)
        {
            return false;
        }
        return true;
    }

}
