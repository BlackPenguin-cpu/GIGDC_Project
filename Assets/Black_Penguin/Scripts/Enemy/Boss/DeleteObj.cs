using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObj : MonoBehaviour , IObjectPoolingObj
{
    public void OnObjCreate()
    {
    }

    void DeleteThis()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }
}
