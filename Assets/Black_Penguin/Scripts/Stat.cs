using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FF", menuName = "FF/FF", order = 0)]
[System.Serializable]
public class Stat : ScriptableObject
{
    public float hp;
    public float attackDamage;
    public float attackSpeed;
    public float speed;
    [Range(0f,100f)]
    public float coinDropValueRange;
    [Range(0f,100f)]
    public float crystalDropValueRange;
}
