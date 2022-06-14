using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coin;
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
    private void Update()
    {
        InputCheat();
    }
    void InputCheat()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Player.Instance.stat._level++;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Debug.Log(Player.Instance.stat._attackDamage);
        }
    }
}
