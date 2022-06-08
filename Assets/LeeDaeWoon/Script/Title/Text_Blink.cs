using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Text_Blink : MonoBehaviour
{
    private Text Fade_Text;



    private void Awake()
    {
        Fade_Text = GetComponent<Text>();
        StartCoroutine(FadeText_Full());
    }
    private void Update()
    {
        //Fade_Text.color = new Color(Fade_Text.color.r, Fade_Text.color.g, Fade_Text.color.b, Mathf.Cos(Time.time));
        //님 이거 한줄로 됨
        //저걸로 하면은 어색해서 닷트윈으로 변경했숨다
    }
    public IEnumerator FadeText_Full()
    {
        Fade_Text.DOFade(0f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeText_Zero());
    }

    public IEnumerator FadeText_Zero()
    {
        Fade_Text.DOFade(1f, 1.5f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeText_Full());
    }

}
