using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    private Player player;
    private DarkPlayer darkPlayer;

    [SerializeField] SpriteRenderer bloodGautletParticle;
    private float bloodGauntletAlpahValue;

    private void Start()
    {
        player = Player.Instance;
        darkPlayer = DarkPlayer.Instance;
    }

    private void Update()
    {
        ParticleCheck();
    }
    void ParticleCheck()
    {
        if (player.stat.bloodGauntletDuration > 0)
        {
            bloodGautletParticle.color = Color.white;
            bloodGauntletAlpahValue = 1;
        }
        else
        {
            bloodGautletParticle.color = new Color(1, 1, 1, bloodGauntletAlpahValue);
            bloodGauntletAlpahValue -= Time.deltaTime;
        }
    }
}
