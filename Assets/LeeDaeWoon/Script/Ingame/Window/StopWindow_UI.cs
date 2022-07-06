using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StopWindow_UI : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData) => SoundManager.instance.PlaySoundClip("SFX_Button_Over", SoundType.SFX);
}
