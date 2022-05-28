using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Manager : MonoBehaviour
{
    //public static Card_Manager Inst { get; private set; }
    //void Awake() => Inst = this;

    private int RandomMix;

    [SerializeField] ItemSo itemSo;
    [SerializeField] GameObject CardPrefab;

    List<Item> ItemBuffer = new List<Item>();
    List<Item> DABuffer = new List<Item>();

    void Start()
    {
        AddList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            AddCard();
        }
    }

    public void AddList()
    {
        for (int i = 0; i < itemSo.Items.Count; i++)
        {
            Debug.Log(itemSo.Items[i].Itme_Name);
            ItemBuffer.Add(itemSo.Items[i]);
        }

        for (int i = 0; i < itemSo.DA.Count; i++)
        {
            DABuffer.Add(itemSo.DA[i]);
        }

        //foreach (Item item in itemSo.Items)
        //{
        //    Debug.Log(item.Itme_Name);
        //    ItemBuffer.Add(item);

        //}

        //foreach (Item DA in itemSo.DA)
        //{
        //    DABuffer.Add(DA);
        //}
    }

    public int Card_Percent(List<Item> Percent_Item)
    {
        int percent = Random.Range(0, 101);
        for (int i = 0; i < Percent_Item.Count; i++)
        {
            if (percent < Percent_Item[i].Item_Percent)
            {
                return i;
            }
            percent -= Percent_Item[i].Item_Percent;
        }
        return 0;
    }

    public void AddCard()
    {
        int itemIndex = 0;
        List<Item> item = new List<Item>();
        // 아이템 카드 소환
        var cardObject = Instantiate(CardPrefab, this.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        var card = cardObject.GetComponent<Item_CardList>();
        for (int i = 0; i < 3; i++)
        {
            RandomMix = Random.Range(0, 101);

            // 마정석
            if (RandomMix <= 70 || DABuffer.Count == 0)
            {
                int RandomTest = Card_Percent(ItemBuffer);
                for (int j = 0; j < item.Count; j++)
                {
                    while (true)
                    {

                        if (item[j] == ItemBuffer[RandomTest])
                        {
                            RandomTest = Card_Percent(ItemBuffer);
                        }
                        else
                            break;
                    }
                }
                item.Add(ItemBuffer[RandomTest]);
                card.Test_ItemCard(ItemBuffer[RandomTest], itemIndex++);
            }

            // 방어구 및 장신구
            else
            {
                int RandomTest = Card_Percent(DABuffer);
                for (int j = 0; j < item.Count; j++)
                {
                    while (true)
                    {
                        if (item[j] == DABuffer[RandomTest])
                        {
                            RandomTest = Card_Percent(DABuffer);
                        }
                        else
                            break;

                    }
                }
                item.Add(DABuffer[RandomTest]);
                card.Test_ItemCard(DABuffer[RandomTest], itemIndex++);
                DABuffer.RemoveAt(RandomTest);
            }
        }
    }
    #region PopItem
    //// ㅠ
    //public Item PopItem()
    //{

    //    for (int i = 0; i < 3; i++)
    //    {
    //        if (ItemBuffer.Count == 0)
    //        {

    //        }

    //        Item item = ItemBuffer[i];
    //        ItemBuffer.RemoveAt(i);
    //        return item;
    //    }
    //    return null;
    //}

    //public Item Left_PopItem()
    //{

    //    // ItemBuffer의 지정한 인덱스를 가져온다.
    //    if (ItemBuffer.Count == 0)
    //    {
    //    }

    //    Item item = ItemBuffer[2];
    //    ItemBuffer.RemoveAt(2);
    //    return item;
    //}

    //public Item Among_PopItem()
    //{
    //    // ItemBuffer의 지정한 인덱스를 가져온다.
    //    if (ItemBuffer.Count == 0)
    //    {
    //    }

    //    Item item = ItemBuffer[1];
    //    ItemBuffer.RemoveAt(1);
    //    return item;
    //}

    //public Item Right_PopItem()
    //{
    //    // ItemBuffer의 지정한 인덱스를 가져온다.
    //    if (ItemBuffer.Count == 0)
    //    {
    //    }

    //    Item item = ItemBuffer[0];
    //    ItemBuffer.RemoveAt(0);
    //    return item;
    //}
    #endregion
}
