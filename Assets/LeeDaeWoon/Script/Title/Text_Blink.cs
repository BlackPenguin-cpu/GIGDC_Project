using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Blink : MonoBehaviour
{
    private Text Fade_Text;

    private void Awake()
    {
        Fade_Text = GetComponent<Text>();
        StartCoroutine(FadeText_Full());
    }

    public IEnumerator FadeText_Full() // ���İ� 0���� 1�� ��ȯ
    {
        Fade_Text.color = new Color(Fade_Text.color.r, Fade_Text.color.g, Fade_Text.color.b, 0);
        while (Fade_Text.color.a < 1.0f)
        {
            Fade_Text.color = new Color(Fade_Text.color.r, Fade_Text.color.g, Fade_Text.color.b, Fade_Text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeText_Zero());
    }

    public IEnumerator FadeText_Zero()  // ���İ� 1���� 0���� ��ȯ
    {
        Fade_Text.color = new Color(Fade_Text.color.r, Fade_Text.color.g, Fade_Text.color.b, 1);
        while (Fade_Text.color.a > 0.0f)
        {
            Fade_Text.color = new Color(Fade_Text.color.r, Fade_Text.color.g, Fade_Text.color.b, Fade_Text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(FadeText_Full());
    }

}
