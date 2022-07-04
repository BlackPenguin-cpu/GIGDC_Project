using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMage : BaseEnemy
{
    bool isShielding = false;
    [SerializeField] GameObject ShieldObj;
    [SerializeField] GameObject meteorObj;
    [SerializeField] GameObject SpaceBoomObj;
    [SerializeField] AttackProjectile HommingProjectile;
    public override float _hp
    {
        get => base._hp;
        set
        {
            if (isShielding) value = 0;
            base._hp = value;
        }
    }
    protected override void Start()
    {
        base.Start();
        BaseStatSet(2000, 0, 0, 10, 0, 0, 0, 0);
    }
    public override void OnObjCreate()
    {
        player = Player.Instance;
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        attackCollisions = GetComponentsInChildren<AttackCollision>();

        hp = _maxHp;
        sprite.color = Color.white;

        StartCoroutine(BossPatternFunc());
    }
    IEnumerator BossPatternFunc()
    {
        WaitForSeconds waitSeconds = new WaitForSeconds(1);
        yield return waitSeconds;

        while (state != EnemyState.DIE)
        {
            if (Random.Range(0, 2) == 0 && !isShielding)
            {
                yield return StartCoroutine(DimensionLeapCoroutine());
            }
            state = EnemyState.MOVE;
            yield return waitSeconds;

            int PatternValue = Random.Range(0, 100);
            if (PatternValue > 70)
            {
                yield return StartCoroutine(Shield());
            }
            else if (PatternValue > 40)
            {
                yield return StartCoroutine(HommingMissile());
            }
            else if (PatternValue > 20)
            {
                yield return StartCoroutine(Meteor());
            }
            else
            {
                yield return StartCoroutine(SpaceBoom());
            }
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator SpaceBoom()
    {
        Instantiate(SpaceBoomObj, dimensionType == DimensionType.OVER ? Player.Instance.transform.position : DarkPlayer.Instance.transform.position, Quaternion.identity); ;
        yield return null;
    }
    IEnumerator Meteor()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(meteorObj, dimensionType == DimensionType.OVER ? Player.Instance.transform.position : DarkPlayer.Instance.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator HommingMissile()
    {
        AttackProjectile attackProjectile = ObjectPool.Instance.CreateObj(HommingProjectile.gameObject, transform.position, Quaternion.identity).GetComponent<AttackProjectile>();
        attackProjectile.Init(this, 10, 20, 1, ProjectileType.Homing, dimensionType == DimensionType.OVER ? Player.Instance.gameObject : DarkPlayer.Instance.gameObject);
        yield return new WaitForSeconds(1);
    }
    IEnumerator Shield()
    {
        Instantiate(ShieldObj, transform);
        isShielding = true;
        yield return new WaitForSeconds(2);
    }
    IEnumerator DimensionLeapCoroutine()
    {
        float value = 1;
        while (value > 0)
        {
            value -= Time.deltaTime;
            transform.localScale = new Vector3(1, value, 1);
            yield return null;
        }
        dimensionType = (dimensionType == DimensionType.OVER ? DimensionType.UNDER : DimensionType.OVER);
        sprite.flipY = !sprite.flipY;
        while (value < 1)
        {
            value += Time.deltaTime;
            transform.localScale = new Vector3(1, value, 1);
            yield return null;
        }
    }
}
