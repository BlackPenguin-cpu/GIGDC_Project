using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul_Effect : MonoBehaviour, IObjectPoolingObj
{
    Animator animator;
    public void OnObjCreate()
    {
        animator = GetComponent<Animator>();
        animator.Play("E_Soul_BoomEffect");
    }
    void AnimEnd()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }

}
