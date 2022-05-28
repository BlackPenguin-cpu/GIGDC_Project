using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//근데 개같이날아감
[System.Serializable]
public class Item
{
    public string Itme_Name;
    public string Item_Explanation;
    public Sprite Item_Icon;
    public int Item_Percent;
}

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Object/ItemSo")]
public class ItemSo : ScriptableObject
{
    public List<Item> Items;
    public List<Item> DA;
}



