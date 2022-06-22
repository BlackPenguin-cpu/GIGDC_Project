using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Manager : MonoBehaviour
{
    public static Card_Manager Inst { get; private set; }
    void Awake() => Inst = this;

    public int RandomMix;

    [SerializeField] ItemSo itemSo;
    [SerializeField] GameObject CardPrefab;

    public List<Item> ItemBuffer = new List<Item>();
    public List<Item> DABuffer = new List<Item>();

    public List<Item> DA_LeftCheck = new List<Item>();
    public List<Item> DA_AmongCheck = new List<Item>();
    public List<Item> DA_RightCheck = new List<Item>();

    public bool DAClick_Check = true;

    private int Item_RandomTest;
    private int DA_RandomTest;

    public bool DA_Left = true;
    public bool DA_Among = true;
    public bool DA_Right = true;

    void Start()
    {
        AddList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.O))
        {
            AddCard();
        }
    }

    public void AddList()
    {
        for (int i = 0; i < itemSo.Items.Count; i++)
        {
            //Debug.Log(itemSo.Items[i].Itme_Name);
            ItemBuffer.Add(itemSo.Items[i]);
        }

        for (int i = 0; i < itemSo.DA.Count; i++)
        {
            DABuffer.Add(itemSo.DA[i]);
        }
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
        DA_LeftCheck.Clear();
        DA_AmongCheck.Clear();
        DA_RightCheck.Clear();

        DA_Left = true;
        DA_Among = true;
        DA_Right = true;

        for (int i = 0; i < 3; i++)
        {
            RandomMix = Random.Range(0, 101);

            // 마정석
            if (RandomMix <= 70 || DABuffer.Count == 0)
            {
                Item_RandomTest = Card_Percent(ItemBuffer);
                for (int j = 0; j < item.Count; j++)
                {
                    while (item[j] == ItemBuffer[Item_RandomTest])
                    {
                        Item_RandomTest = Card_Percent(ItemBuffer);
                    }
                }
                item.Add(ItemBuffer[Item_RandomTest]);
                card.ItemCard(ItemBuffer[Item_RandomTest], itemIndex++);
            }

            // 방어구 및 장신구
            else
            {
                DA_RandomTest = Card_Percent(DABuffer);
                for (int j = 0; j < item.Count; j++)
                {
                    while (item[j] == DABuffer[DA_RandomTest])
                    {
                        DA_RandomTest = Card_Percent(DABuffer);
                    }
                }
                item.Add(DABuffer[DA_RandomTest]);
                card.ItemCard(DABuffer[DA_RandomTest], itemIndex++);

                if (i == 0)
                {
                    DA_Left = false;
                    DA_LeftCheck.Add(DABuffer[DA_RandomTest]);
                }
                else if (i == 1)
                {
                    DA_Among = false;
                    DA_AmongCheck.Add(DABuffer[DA_RandomTest]);
                }
                else if (i == 2)
                {
                    DA_Right = false;
                    DA_RightCheck.Add(DABuffer[DA_RandomTest]);
                }

            }
        }
    }
}
