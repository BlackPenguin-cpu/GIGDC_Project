using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Potal : MonoBehaviour
{
    public static Potal Inst { get; private set; }
    void Awake() => Inst = this;

    public GameObject Potal_obj;
    public SpriteRenderer Player;
    public SpriteRenderer Dark_Player;
    bool Potal_Check;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4))
            StartCoroutine(Potal_Limit());
        if (Input.GetKeyDown(KeyCode.Keypad0))
            SceneManager.LoadScene("Dimension");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySoundClip("SFX_Potal", SoundType.SFX);
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            if (SceneManager.GetActiveScene().name == "Main")
                SceneManager.LoadScene("test");

            if (SceneManager.GetActiveScene().name == "Dimension")
                SceneManager.LoadScene("test");
        }
    }

    public IEnumerator Potal_Limit()
    {
        if (Potal_Check == false && SceneManager.GetActiveScene().name == "test")
        {
            Potal_Check = true;

            // 플레이어 이동 및 공격 과 스킬 전환을 멈추게 한다.
            UI_Manager.Inst.PlayerMove_control = true;
            Skill_Manager.Inst.Chang_Check = true;
            Potal_obj.SetActive(true);
            Potal_obj.transform.localPosition = new Vector3(Player.transform.localPosition.x, 1, 0);
            yield return new WaitForSeconds(2f);

            Dark_Player.DOFade(0f, 2.5f);
            Player.DOFade(0f, 2.5f);

            UI_Manager.Inst.FadeInOut.DOFade(1f, 4f);

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene("Dimension");
        }
    }
}
