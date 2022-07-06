using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour, IObjectPoolingObj
{
    public void OnObjCreate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            Player.Instance._hp += 15;
            ObjectPool.Instance.DeleteObj(gameObject);
        }
    }
}
