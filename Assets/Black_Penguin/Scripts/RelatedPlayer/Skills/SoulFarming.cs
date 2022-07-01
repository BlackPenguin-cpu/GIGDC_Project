using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoulFarming : BaseSkill
{
    [SerializeField] private Image image;
    [SerializeField] private Material material;
    [SerializeField] private GameObject AttackParticle;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    protected override void Action()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && enemy.dimensionType == dimensionType)
            {
                ObjectPool.Instance.CreateObj(AttackParticle, enemy.transform.position, Quaternion.identity);
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        StartCoroutine(OnActive());
    }
    IEnumerator ImageFade()
    {
        float value = 0;
        while (value < 0.5f)
        {
            value += Time.deltaTime;
            image.color = new Color(1, 1, 1, value);
            yield return null;
        }
    }
    IEnumerator OnActive()
    {
        StartCoroutine(ImageFade());
        float value = 1;
        while (value > 0)
        {
            material.SetFloat("_FadeAmout", value);
            value -= Time.deltaTime;
            yield return null;
        }

        image.color = Color.clear;
        animator.Play("Attack");
        yield return new WaitForSeconds(0.1f);
        Action();
    }
}
