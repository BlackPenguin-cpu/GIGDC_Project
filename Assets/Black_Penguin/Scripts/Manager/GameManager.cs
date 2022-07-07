using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Material OverMaterial;
    public Material UnderMaterial;
    public GameObject DropGoods;
    private Player player;

    private int coin;
    public int _coin
    {
        get { return coin; }
        set
        {
            coin += (int)(coin * (player.stat.magicPower.thaumcraft * 0.2f));
            coin = value;
        }
    }
    public int crystal;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        player = Player.Instance;
    }
    private void Update()
    {
        InputCheat();
    }
    void InputCheat()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Player.Instance.stat._level[Player.Instance.stat.weaponType]++;
            Player.Instance.stat.LevelStat();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log(Player.Instance.stat._attackDamage);
        }
    }
}
