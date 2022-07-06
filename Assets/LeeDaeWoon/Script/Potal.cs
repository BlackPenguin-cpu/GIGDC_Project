using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Potal : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnLevelWasLoaded(int level) => DOTween.PauseAll();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySoundClip("SFX_Potal", SoundType.SFX);
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            if (SceneManager.GetActiveScene().name == "Main")
                SceneManager.LoadScene("test");

            if (SceneManager.GetActiveScene().name == "test")
                SceneManager.LoadScene("Dimension");

            if (SceneManager.GetActiveScene().name == "Dimension")
                SceneManager.LoadScene("test");
        }
    }
}
