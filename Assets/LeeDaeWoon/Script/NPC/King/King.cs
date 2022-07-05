using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public static King Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("���� ���")]
    public SpriteRenderer King_NPC;

    [Header("��ȭ ���� �� �ʿ���� ������Ʈ")]
    public GameObject Player_HP;
    public GameObject Player_Skill;

    [Header("��ȭ ���� �� �ʿ��� ������Ʈ")]
    public GameObject Camera_obj;
    public GameObject Credit_Bar01;
    public GameObject Credit_Bar02;

    [Header("��ȭ")]
    public List<string> Dialogue = new List<string>();
    public Text Dialogue_Text;
    public int Sequence_Text = 0;

    [Header("�浹 Ȯ��")]
    public BoxCollider2D Area01_Box;
    public BoxCollider2D Area02_Box;
    public BoxCollider2D Area03_Box;
    public BoxCollider2D Area04_Box;

    [Header("������ ����")]
    public bool Magic_Creation = false;

    public bool Dialogue_Skip = false;


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            Zoom_Expansion();
        if (Input.GetKeyDown(KeyCode.Keypad2))
            Zoom_Shrinking();
    }
    #region ī�޶� Ȯ�� / ���
    public void Zoom_Expansion() => StartCoroutine(Expansion());
    public void Zoom_Shrinking() => StartCoroutine(Shrinking());


    public IEnumerator Expansion() // �� Ȯ�� 
    {
        UI_Manager.Inst.PlayerMove_control = true; // �÷��̾��� �������� �����.
        Player.Instance.state = PlayerState.Idle; // �÷��̾��� �������� ���ִ� ���·� ���д�.
        Camera_obj.GetComponent<CameraManager>().enabled = false; // CameraManager�� ���д�.

        // �÷��̾� UI�� �������� ġ���.
        Player_HP.transform.DOLocalMoveX(-260f, 0.7f).SetEase(Ease.Linear);
        Player_Skill.transform.DOLocalMoveX(-1221f, 0.7f).SetEase(Ease.Linear);

        // ũ�����ٴ� ���� �Ʒ����� ���´�.
        Credit_Bar01.transform.DOLocalMoveY(479f, 0.6f).SetEase(Ease.Linear);
        Credit_Bar02.transform.DOLocalMoveY(-479f, 0.6f).SetEase(Ease.Linear);

        for (float i = 5; i > 4f; i -= 0.1f)
        {
            Camera.main.orthographicSize = i;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator Shrinking() // �� ���
    {
        // �÷��̾� UI�� ���ڸ��� �����ش�.
        Player_HP.transform.DOLocalMoveX(-6f, 0.6f).SetEase(Ease.Linear);
        Player_Skill.transform.DOLocalMoveX(-967f, 0.6f).SetEase(Ease.Linear);

        // ũ�����ٴ� ���� �Ʒ��� �����ش�.
        Credit_Bar01.transform.DOLocalMoveY(680f, 0.6f).SetEase(Ease.Linear);
        Credit_Bar02.transform.DOLocalMoveY(-680f, 0.6f).SetEase(Ease.Linear);

        for (float i = 4; i < 5f; i += 0.1f)
        {
            Camera.main.orthographicSize = i;
            yield return new WaitForSeconds(0.05f);
        }
        Camera_obj.GetComponent<CameraManager>().enabled = true; // CameraManager�� �ѵд�.
        yield return new WaitForSeconds(0.5f);
        UI_Manager.Inst.PlayerMove_control = false; // �÷��̾��� �������� �����۵� ��Ų��.

    }
    #endregion
}
