using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpView : MonoBehaviour
{
    private TextMesh textMesh;
    private Player player;
    public float value;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        player = Player.Instance;
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
    }
    private void Update()
    {
        textMesh.text = $"{player.stat._hp} / {player.stat._maxHp}";

        if (value > 0)
        {
            value -= Time.deltaTime;
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, value);
        }
    }
    public void onHit()
    {
        textMesh.color = Color.white;
    }
}
