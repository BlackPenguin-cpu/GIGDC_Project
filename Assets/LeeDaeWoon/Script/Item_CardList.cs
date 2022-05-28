using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_CardList : MonoBehaviour
{
    [Header("왼쪽 카드")]
    public Image Left_Card_Icon;
    public Text Left_Name;
    public Text Left_Explanation;

    [Header("가운데 카드")]
    public Image Among_Card_Icon;
    public Text Among_Name;
    public Text Among_Explanation;

    [Header("오른쪽 카드")]
    public Image Right_Card_Icon;
    public Text Right_Name;
    public Text Right_Explanation;

    public Item Left_Item;
    public Item Among_Item;
    public Item Right_Item;
    public Item PopItem;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Test_ItemCard(Item item, int itemIndex)
    {
        switch (itemIndex)
        {
            case 0:
                this.Left_Item = item;

                Left_Name.text = this.Left_Item.Itme_Name;
                Left_Explanation.text = this.Left_Item.Item_Explanation;
                //Left_Card_Icon.sprite = this.Left_Item.Item_Icon;
                break;
            case 1:
                this.Among_Item = item;

                Among_Name.text = this.Among_Item.Itme_Name;
                Among_Explanation.text = this.Among_Item.Item_Explanation;
                //Among_Card_Icon.sprite = this.Among_Item.Item_Icon;
                break;
            case 2:
                this.Right_Item = item;

                Right_Name.text = this.Right_Item.Itme_Name;
                Right_Explanation.text = this.Right_Item.Item_Explanation;
                //Right_Card_Icon.sprite = this.Right_Item.Item_Icon;
                break;

        }
    }

    public void Left_ItemCard(Item Left_item)
    {
        
        this.Left_Item = Left_item;

        Left_Name.text = this.Left_Item.Itme_Name;
        Left_Explanation.text = this.Left_Item.Item_Explanation;
        //Left_Card_Icon.sprite = this.Left_Item.Item_Icon;
    }
    
    public void Among_ItemCard(Item Among_item)
    {
        this.Among_Item = Among_item;

        Among_Name.text = this.Among_Item.Itme_Name;
        Among_Explanation.text = this.Among_Item.Item_Explanation;
        //Among_Card_Icon.sprite = this.Among_Item.Item_Icon;
    }

    public void Right_ItemCard(Item Right_item)
    {
        this.Right_Item = Right_item;

        Right_Name.text = this.Right_Item.Itme_Name;
        Right_Explanation.text = this.Right_Item.Item_Explanation;
        //Right_Card_Icon.sprite = this.Right_Item.Item_Icon;
    }
}
