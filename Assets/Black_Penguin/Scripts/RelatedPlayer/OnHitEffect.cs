using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHitEffect : MonoBehaviour
{
    static public OnHitEffect Instance;
    Image hitImage;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        hitImage = GetComponent<Image>();
        hitImage.color = Color.clear;
    }
    public void OnHitFunc()
    {
        hitImage.color = Color.white;
        StartCoroutine(OnHitCoroutine());
    }
    IEnumerator OnHitCoroutine()
    {
        float value = 1;
        for (; value <= 0; value -= Time.deltaTime)
        {
            hitImage.color = new Color(1, 1, 1, value);
            yield return null;
        }
    }
}
