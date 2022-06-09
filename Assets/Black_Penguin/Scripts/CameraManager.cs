using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    NONE,
    ONPLAYER
}
public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public CameraState state;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        CameraMove();
    }
    void CameraMove()
    {
        switch (state)
        {
            case CameraState.NONE:
                break;
            case CameraState.ONPLAYER:
                transform.position = Vector2.Lerp(transform.position, Player.Instance.transform.position, Time.deltaTime);
                break;
            default:
                break;
        }
    }
    public void CameraShake(float duration, float Scale, float delay)
    {
        StartCoroutine(CameraShakeCoroutine(duration, Scale, delay));
    }
    IEnumerator CameraShakeCoroutine(float duration, float Scale, float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
