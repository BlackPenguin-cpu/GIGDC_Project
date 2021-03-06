using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class SoulFarming : BaseSkill
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject AttackParticle;
    [SerializeField] private Material material;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    protected override void Action()
    {
        ActionCoroutine();
    }
    async void ActionCoroutine()
    {
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider2D.offset, boxCollider2D.size, 0, Vector2.right, 0);
        SoundManager.instance.PlaySoundClip("SFX_Skill_Reaper_Attack", SoundType.SFX);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider != null && rays[i].collider.TryGetComponent(out BaseEnemy enemy) && enemy.dimensionType == dimensionType)
            {
                CameraManager.Instance.ScreenFade(0.05f, 0.5f);
                ObjectPool.Instance.CreateObj(AttackParticle, enemy.transform.position, Quaternion.identity);
                player.Attack(enemy, DefaultReturnDamage());
                await Task.Delay(100);
            }
        }

    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite.material = material;

        StartCoroutine(OnActive());
    }
    IEnumerator ImageFade()
    {
        float value = 0;
        while (value < 0.5f)
        {
            value += Time.deltaTime;
            image.color = new Color(0, 0, 0, value);
            yield return null;
        }
    }
    IEnumerator OnActive()
    {
        Time.timeScale = 0.4f;
        CameraManager.Instance.CameraShake(2, 0.1f, 0.1f);

        StartCoroutine(ImageFade());
        float value = 0.8f;
        while (value > 0)
        {
            material.SetFloat("_FadeAmount", value);
            value -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);

        image.color = Color.clear;
        animator.Play("Attack");
        CameraManager.Instance.ScreenFade(0.1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        Action();
        Time.timeScale = 1f;

        value = 0;
        while (value < 1)
        {
            material.SetFloat("_FadeAmount", value);
            value += Time.deltaTime;
            yield return null;
        }
        ObjectPool.Instance.DeleteObj(gameObject);
    }
}
