using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSprite : MonoBehaviour
{
    [SerializeField] private Vector3 rotVec = new Vector3(0, 0, 200);
    void Update()
    {
        transform.Rotate(rotVec * Time.deltaTime);
    }
}
