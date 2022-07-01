using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusFury : BaseSkill
{
    [SerializeField] private GameObject Field;
    private BoxCollider2D[] boxColliders;
    private float duration = 10;
    protected override void Action()
    {
        ObjectPool.Instance.CreateObj(Field, gameObject.transform.position, Quaternion.identity);
        ObjectPool.Instance.DeleteObj(gameObject);
    }
    private void OnLighting()
    {
        CameraManager.Instance.CameraShake(0.4f, 0.3f, 0.03f);
        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxColliders[0].offset, boxColliders[0].size, 0, Vector2.right, 0);

        for (int i = 0; i < rays.Length; i++)
        {
            if (rays[i].collider.TryGetComponent(out BaseEnemy enemy) && enemy.dimensionType == dimensionType)
            {
                player.Attack(enemy, DefaultReturnDamage());
            }
        }
    }
    public override void OnObjCreate()
    {
        base.OnObjCreate();
        CameraManager.Instance.ScreenFade(0.2f, 0.3f);
        boxColliders = transform.GetComponentsInChildren<BoxCollider2D>();
        duration = 10;
    }
    private void Update()
    {
        duration -= Time.deltaTime;

        sprite.color = new Color(1, 1, 1, duration);
        if (duration < 0)
        {
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }

}
