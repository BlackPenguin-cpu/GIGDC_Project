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

    [Header("텍스트 연출")]
    public string scrambleChars_Tool;
    public bool richTextEnabled;
    public ScrambleMode scrambleMode;

    void Start()
    {

    }

    void Update()
    {
        NextDialogue_F();
    }

    public void NextDialogue_F()
    {
        if (Input.GetKeyDown(KeyCode.F) && King.Inst.KingCollision_Check == true)
        {
            NExtDialogue();
        }
    }

    public void NExtDialogue()
    {
        switch (area)
        {
            case Area.Area_01:

                if (King.Inst.Dialogue_Text.text == King.Inst.Dialogue[King.Inst.Sequence_Text] && King.Inst.Sequence_Text <= 8)
                {
                    if (King.Inst.Sequence_Text < 8)
                    {
                        King.Inst.Dialogue_Text.text = "";
                        King.Inst.Sequence_Text++;
                        King.Inst.Dialogue_Text.DOPause();
                        King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 3f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                    }

                    else if (King.Inst.Sequence_Text == 8)
                    {
                        
                        King.Inst.Zoom_Shrinking();
                        King.Inst.Area01_Box.enabled = false;
                    }
                }

                else
                {
                    King.Inst.Dialogue_Text.DOPause();
                    King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 0, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                }
                break;
        }
    }

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
        {
            King.Inst.KingCollision_Check = true;
            King.Inst.Zoom_Expansion(); // 줌이 확대 된다.
            King.Inst.Dialogue_Text.text = "";
            switch (area)
            {
                case Area.Area_01:
                    King.Inst.Camera_obj.transform.DOLocalMoveX(0.24f, 0.5f); // 카메라는 Area_01 위치로 옮겨둔다.

                    yield return new WaitForSeconds(0.5f);

                    switch (King.Inst.Sequence_Text)
                    {
                        case 0:
                            King.Inst.Dialogue_Text.DOText(King.Inst.Dialogue[King.Inst.Sequence_Text], 1.5f, richTextEnabled = true, scrambleMode = ScrambleMode.None, scrambleChars_Tool = null);
                            yield return new WaitForSeconds(1.5f);
                            break;
                    }
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ITypePlayer>() != null)
            King.Inst.KingCollision_Check = false;
    }

}
