using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    Player player;

    [SerializeField] GameObject bloodGautletParticle;

    private void Start()
    {
        player = Player.Instance;
    }

    private void Update()
    {
        ParticleCheck();
    }
    void ParticleCheck()
    {
        bloodGautletParticle.SetActive(player.stat.bloodGauntletDuration > 0);
    }
}
