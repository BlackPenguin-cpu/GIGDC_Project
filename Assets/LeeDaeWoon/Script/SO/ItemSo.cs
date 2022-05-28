using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�ٵ� �����̳��ư�
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



