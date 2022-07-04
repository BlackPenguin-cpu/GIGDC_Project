using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class King_Collision : MonoBehaviour
{
    public enum Area
    {
        Area_01,
        Area_02,
        Area_03,
        Area_04,
    }
    public Area area;

    [Header("�ؽ�Ʈ ����")]
    public string scrambleChars_Tool;
    public bool richTextEnabled;
    public ScrambleMode scrambleMode;

    bool Range_Reach;
    bool Dialogue_End;

    void Start()
    {

    }

    void Update()
    {
        NextDialogue_F();
    }

    public void NextDialogue_F()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(NextDialogue());
        }
    }

    public IEnumerator NextDialogue()
    {
        #region �� �־�
        //switch (area)
        //{
        //    case Area.Area_01:
        //        // ������ Ÿ������ ���� ��� && ��簡 7�� ���� ������ ��� && ��簡 ���� �� ������ ���
        //        if (KingCollision_Check == true)
        //        {
        //            if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 7 && ConversationEnd_Check == false)
        //            {
        //                if (King.Inst.Sequence_Text < 7)
        //                {
        //                    King.Inst.Sequence_Text++;
        //                    King.Inst.Dialogue_Text.text = "";
        //                    King.Inst.Dialogue_Text.DOPause();
        //                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
        //                }

        //                else if (King.Inst.Sequence_Text == 7)
        //                {
        //                    ConversationEnd_Check = true;

        //                    King.Inst.King_Sprite.DOFade(0f, 1f);
        //                    King.Inst.Area01_Box.enabled = false;

        //                    yield return new WaitForSeconds(1.2f);

        //                    King.Inst.King_Sprite.transform.DOLocalMoveX(15f, 1f);

        //                    yield return new WaitForSeconds(1f);

        //                    King.Inst.Sequence_Text++;
        //                    King.Inst.Zoom_Shrinking();
        //                    ConversationEnd_Check = false;
        //                    King.Inst.Dialogue_Text.text = "";
        //                    King.Inst.King_Sprite.DOFade(1f, 0.1f);
        //                }
        //            }

        //            else // ������ �� ��µǱ��� FŰ�� ������ ��
        //            {
        //                // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
        //                King.Inst.Dialogue_Text.DOPause();
        //                King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
        //            }
        //        }
        //        break;

        //    case Area.Area_02:
        //        if (KingCollision_Check == true)
        //        {
        //            if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 12 && ConversationEnd_Check == false)
        //            {
        //                if (King.Inst.Sequence_Text < 12)
        //                {
        //                    King.Inst.Sequence_Text++;
        //                    King.Inst.Dialogue_Text.text = "";
        //                    King.Inst.Dialogue_Text.DOPause();
        //                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
        //                }

        //                else if (King.Inst.Sequence_Text == 12)
        //                {
        //                    ConversationEnd_Check = true;

        //                    King.Inst.King_Sprite.DOFade(0f, 1f);
        //                    King.Inst.Area02_Box.enabled = false;

        //                    yield return new WaitForSeconds(1.2f);

        //                    King.Inst.King_Sprite.transform.DOLocalMoveX(15f, 1f);

        //                    yield return new WaitForSeconds(1f);

        //                    King.Inst.Sequence_Text++;
        //                    King.Inst.Zoom_Shrinking();
        //                    ConversationEnd_Check = false;
        //                    King.Inst.Dialogue_Text.text = "";
        //                    King.Inst.King_Sprite.DOFade(1f, 0.1f);
        //                }
        //            }

        //            else // ������ �� ��µǱ��� FŰ�� ������ ��
        //            {
        //                // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
        //                King.Inst.Dialogue_Text.DOPause();
        //                King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
        //            }
        //        }
        //        break;


        //}
        #endregion
        switch (area)
        {
            case Area.Area_01:
                {
                    if (Range_Reach == true)
                    {

                        // ������ Ÿ������ ���� ��� && ��簡 7�� ���� ������ ��� && ��簡 ���� �� ������ ���
                        if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 7 && Dialogue_End == false)
                        {
                            if (King.Inst.Sequence_Text < 7)
                            {
                                King.Inst.Sequence_Text++;
                                King.Inst.Dialogue_Text.text = "";
                                King.Inst.Dialogue_Text.DOPause();
                                King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                            }

                            else if (King.Inst.Sequence_Text == 7)
                            {
                                Range_Reach = false;
                                Dialogue_End = true;
                                King.Inst.King_NPC.DOFade(0f, 1f);
                                King.Inst.Area01_Box.enabled = false;
                                yield return new WaitForSeconds(1.2f);

                                King.Inst.King_NPC.transform.DOLocalMoveX(15f, 1f);

                                yield return new WaitForSeconds(1f);
                                King.Inst.Sequence_Text++;
                                King.Inst.Zoom_Shrinking();
                                King.Inst.Dialogue_Text.text = "";
                                King.Inst.King_NPC.DOFade(1f, 0.1f);
                            }
                        }

                        else // ������ �� ��µǱ��� FŰ�� ������ ��
                        {
                            // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
                            King.Inst.Dialogue_Text.DOPause();
                            King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                        }
                    }
                }
                break;

            case Area.Area_02:
                if (Range_Reach == true)
                {

                    // ������ Ÿ������ ���� ��� && ��簡 7�� ���� ������ ��� && ��簡 ���� �� ������ ���
                    if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 12 && Dialogue_End == false)
                    {
                        if (King.Inst.Sequence_Text < 12)
                        {
                            King.Inst.Sequence_Text++;
                            King.Inst.Dialogue_Text.text = "";
                            King.Inst.Dialogue_Text.DOPause();
                            King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                        }

                        else if (King.Inst.Sequence_Text == 12)
                        {
                            Range_Reach = false;
                            Dialogue_End = true;
                            King.Inst.King_NPC.DOFade(0f, 1f);
                            King.Inst.Area02_Box.enabled = false;
                            yield return new WaitForSeconds(1.2f);

                            King.Inst.King_NPC.transform.DOLocalMoveX(23f, 1f);

                            yield return new WaitForSeconds(1f);
                            King.Inst.Sequence_Text++;
                            King.Inst.Zoom_Shrinking();
                            King.Inst.Dialogue_Text.text = "";
                            King.Inst.King_NPC.DOFade(1f, 0.1f);
                        }
                    }

                    else // ������ �� ��µǱ��� FŰ�� ������ ��
                    {
                        // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
                        King.Inst.Dialogue_Text.DOPause();
                        King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    }
                }
                break;

            case Area.Area_03:
                if (Range_Reach == true)
                {

                    // ������ Ÿ������ ���� ��� && ��簡 7�� ���� ������ ��� && ��簡 ���� �� ������ ���
                    if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 18 && Dialogue_End == false)
                    {
                        if (King.Inst.Sequence_Text < 18)
                        {
                            King.Inst.Sequence_Text++;
                            King.Inst.Dialogue_Text.text = "";
                            King.Inst.Dialogue_Text.DOPause();
                            King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                        }

                        else if (King.Inst.Sequence_Text == 18)
                        {
                            Range_Reach = false;
                            Dialogue_End = true;
                            King.Inst.King_NPC.DOFade(0f, 1f);
                            King.Inst.Area03_Box.enabled = false;
                            yield return new WaitForSeconds(1.2f);

                            King.Inst.King_NPC.transform.DOLocalMoveX(32f, 1f);

                            yield return new WaitForSeconds(1f);
                            King.Inst.Sequence_Text++;
                            King.Inst.Zoom_Shrinking();
                            King.Inst.Dialogue_Text.text = "";
                            King.Inst.King_NPC.DOFade(1f, 0.1f);
                        }
                    }

                    else // ������ �� ��µǱ��� FŰ�� ������ ��
                    {
                        // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
                        King.Inst.Dialogue_Text.DOPause();
                        King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    }
                }
                break;

            case Area.Area_04:
                if (Range_Reach == true)
                {

                    // ������ Ÿ������ ���� ��� && ��簡 7�� ���� ������ ��� && ��簡 ���� �� ������ ���
                    if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 23 && Dialogue_End == false)
                    {
                        if (King.Inst.Sequence_Text < 23)
                        {
                            King.Inst.Sequence_Text++;
                            King.Inst.Dialogue_Text.text = "";
                            King.Inst.Dialogue_Text.DOPause();
                            King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                        }

                        else if (King.Inst.Sequence_Text == 23)
                        {
                            Range_Reach = false;
                            Dialogue_End = true;
                            King.Inst.King_NPC.DOFade(0f, 1f);
                            King.Inst.Area04_Box.enabled = false;

                            yield return new WaitForSeconds(1f);

                            King.Inst.Zoom_Shrinking();
                        }
                    }

                    else // ������ �� ��µǱ��� FŰ�� ������ ��
                    {
                        // ġ�� �ִ� Ÿ������ ���߰�, �ٷ� ������ �ϼ��ǵ��� �Ѵ�.
                        King.Inst.Dialogue_Text.DOPause();
                        King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    }
                }
                break;
        }
    }


    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            King.Inst.Zoom_Expansion(); // ī�޶� Ȯ�� ��Ų��.
            switch (area)
            {
                case Area.Area_01:
                    Range_Reach = true;
                    King.Inst.Camera_obj.GetComponent<CameraManager>().enabled = false;
                    King.Inst.Camera_obj.transform.DOLocalMoveX(0, 0.5f).SetEase(Ease.Linear);

                    yield return new WaitForSeconds(0.5f);

                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    break;

                case Area.Area_02:
                    Range_Reach = true;
                    King.Inst.Camera_obj.GetComponent<CameraManager>().enabled = false;
                    King.Inst.Camera_obj.transform.DOLocalMoveX(9, 0.5f).SetEase(Ease.Linear);

                    yield return new WaitForSeconds(0.5f);

                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    break;

                case Area.Area_03:
                    Range_Reach = true;
                    King.Inst.Camera_obj.GetComponent<CameraManager>().enabled = false;
                    King.Inst.Camera_obj.transform.DOLocalMoveX(17.82f, 0.5f).SetEase(Ease.Linear);

                    yield return new WaitForSeconds(0.5f);

                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    break;

                case Area.Area_04:
                    Range_Reach = true;
                    King.Inst.Camera_obj.GetComponent<CameraManager>().enabled = false;
                    King.Inst.Camera_obj.transform.DOLocalMoveX(26.76f, 0.5f).SetEase(Ease.Linear);

                    yield return new WaitForSeconds(0.5f);

                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    break;
            }
        }
    }
}
