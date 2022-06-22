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

    private Vector3 startPos;
    public CameraState state;
    private void Awake()
    {
        instance = this;
        startPos = transform.position;
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
                float posY = transform.position.y;
                transform.position = Vector3.Lerp(transform.position, Player.Instance.transform.position + new Vector3(0, 0, -10), Time.deltaTime * Player.Instance.stat._speed / 5);
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);
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
        Vector3 pos = transform.position;

        float nowTime = Time.time;
        duration += nowTime;
        while (nowTime < duration)
        {
            transform.position += (Vector3)(Vector2.one * (Random.insideUnitCircle * Random.Range(-Scale, Scale)));

            nowTime = Time.time;
            yield return new WaitForSeconds(delay);
            transform.position = pos;
        }
    }
}
