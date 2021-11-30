using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData tEventData) {
        if(cGV.I.sUIButton.cUIButtonGameObject[cGV.UI_MOVE_LEFT] == gameObject) {
            cGV.I.vCheckMoveLeft = true;
        }else if(cGV.I.sUIButton.cUIButtonGameObject[cGV.UI_MOVE_RIGHT] == gameObject) {
            cGV.I.vCheckMoveRight = true;
        }
    }
    public void OnPointerUp(PointerEventData tEventData) {
        if (cGV.I.sUIButton.cUIButtonGameObject[cGV.UI_MOVE_LEFT] == gameObject) {
            cGV.I.vCheckMoveLeft = false;
        } else if (cGV.I.sUIButton.cUIButtonGameObject[cGV.UI_MOVE_RIGHT] == gameObject) {
            cGV.I.vCheckMoveRight = false;
        }
    }
}
