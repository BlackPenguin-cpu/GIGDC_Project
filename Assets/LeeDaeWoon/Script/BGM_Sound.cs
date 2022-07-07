using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Sound : MonoBehaviour
{
    public static BGM_Sound Inst { get; private set; }
    private void Awake()
    {
        if (Inst == null)
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Title")
            SoundManager.instance.PlaySoundClip("BGM_Title (1)", SoundType.BGM, 5f);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Main")
            SoundManager.instance.PlaySoundClip("BGM_Main", SoundType.BGM, 5f);

        if (SceneManager.GetActiveScene().name == "test")
            SoundManager.instance.PlaySoundClip("BGM_Ingame_01", SoundType.BGM, 5f);

        if (SceneManager.GetActiveScene().name == "������������")
            SoundManager.instance.PlaySoundClip("BGM_Boss_01", SoundType.BGM, 5f);
    }

    void Update()
    {

    }
}
