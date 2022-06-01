using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Manager : MonoBehaviour
{
    public static Card_Manager Inst { get; private set; }
    void Awake() => Inst = this;

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
        var cardObject = Instantiate(CardPrefab, this.transform.position, Quaternion.identity, GameObject.Find("Item_Canvas").transform);
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
                    while (item[j] == ItemBuffer[RandomTest])
                    {
                        RandomTest = Card_Percent(ItemBuffer);
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
                    while (item[j] == DABuffer[RandomTest])
                    {
                        RandomTest = Card_Percent(DABuffer);
                    }
                }
                item.Add(DABuffer[RandomTest]);
                card.Test_ItemCard(DABuffer[RandomTest], itemIndex++);
                // 아이템 클릭 시 if문 달아주기
                DABuffer.RemoveAt(RandomTest);
            }
        }
    }
}
