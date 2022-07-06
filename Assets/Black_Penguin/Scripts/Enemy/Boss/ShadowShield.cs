using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShield : BaseEnemy
{
    private ShadowMage ShadowMage;
    protected override void Start()
    {
        ShadowMage = transform.GetComponentInParent<ShadowMage>();
        onDie += () => ShadowMage.isShielding = false;
        sprite = GetComponent<SpriteRenderer>();
        hp = maxHp;
    }
    public override void OnDieActionAdd()
    {
        onDie += () => MaterialDrop();
        onDie += () => Player.Instance.DaggerSkill2(); // HOLY SHIT
        onDie += () => CameraManager.Instance.CameraShake(0.1f, 0.4f, 0.05f);
        onDie += () => player.BloodGauntletAction(this);
        onDie += () => _state = EnemyState.DIE;
    }
    protected override void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected override void FixedUpdate()
    {
    }
    public override void OnHit(Entity atkEntity, float Damage)
    {
        StartCoroutine(HitEffectCoroutine());
    }
}
