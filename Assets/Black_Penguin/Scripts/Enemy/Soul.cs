using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : BaseEnemy
{
    protected override void Start()
    {
        BaseStatSet(80, 30, 1, 18, 0, 0, 0, 0);
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (PlayerDetect() && curAttackDelay > attackDelay)
        {
            curAttackDelay = 0;
        }
    }
    bool PlayerDetect()
    {
        //���Ƿ� ���� �� (���߿� ��ȹ ����� ������ ���� �ʿ�)
        float distance = collider.size.x * 1;

        RaycastHit2D[] rays = Physics2D.BoxCastAll(transform.position, collider.size, 0, Vector2.right);
        foreach (var detectObj in rays)
        {
            if (detectObj.transform.TryGetComponent(out Player player)
                && player.transform.position.x - gameObject.transform.position.x < distance)
            {
                return true;
            }
        }
        return false;
    }
}
