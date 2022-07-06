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
        if (collision.GetComponent<ITypePlayer>() != null)
            SceneManager.LoadScene("test");
    }
}
