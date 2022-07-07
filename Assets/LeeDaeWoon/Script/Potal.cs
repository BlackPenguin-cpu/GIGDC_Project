using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
        Player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4))
            Potal_M();
    }

    public void Potal_M() =>
        StartCoroutine(Potal_Move());

    public IEnumerator Potal_Move()
    {
        if (Potal_Check == false && SceneManager.GetActiveScene().name == "test")
        {
            Potal_Check = true;

            // �÷��̾� �̵� �� ���� �� ��ų ��ȯ�� ���߰� �Ѵ�.
            UI_Manager.Inst.PlayerMove_control = true;
            Skill_Manager.Inst.Chang_Check = true;

            Potal_obj.SetActive(true);
            Potal_obj.transform.localPosition = new Vector3(Player.transform.localPosition.x, 1, 0);
            UI_Manager.Inst.FadeInOut.DOFade(1f, 4f);
            yield return new WaitForSeconds(1f);

            Dark_Player.DOFade(0f, 2.5f);
            Player.DOFade(0f, 2.5f);

            yield return new WaitForSeconds(2f);
            SoundManager.instance.PlaySoundClip("SFX_Potal", SoundType.SFX);
            SceneManager.LoadScene("Dimension");
        }
    }

}
