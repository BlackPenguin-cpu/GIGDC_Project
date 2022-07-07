using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObj : MonoBehaviour , IObjectPoolingObj
{
    public ParticleSystem Gold_Particle;
    public ParticleSystem Dimension_Particle;

    public void OnObjCreate()
    {
    }

    void DeleteThis()
    {
        ObjectPool.Instance.DeleteObj(gameObject);
    }

    //public void Particle_Gravity()
    //{
    //    if (this.gameObject.transform.localPosition.y >= -1)
    //    {
    //        Gold_Particle.gravityModifier = -1;
    //    }
    //}
}
