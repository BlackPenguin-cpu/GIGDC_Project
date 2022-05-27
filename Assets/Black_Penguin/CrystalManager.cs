using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crystals
{
    int powerCount = 0;
    int speedCount = 0;
    int attackSpeedCount = 0;
    int healthCount = 0;
    int timeCount = 0;
    int deffenceCount = 0;
}

[System.Serializable]
public enum CrystalsType
{
    POWER,
    SPEED,
    ATTACKSPEED,
    HEALTH,
    TIME,
    DEFFENCE
}

public class CrystalManager : MonoBehaviour
{
    public Crystals Crystals;
    public Dictionary<CrystalsType, GameObject> crystalObjs;
    void CreateCrystals(Vector3 pos)
    {

        Instantiate(crystalObjs[CrystalsType.POWER], pos, Quaternion.identity);
    }
}
