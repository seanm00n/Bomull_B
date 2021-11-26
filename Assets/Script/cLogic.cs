using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLogic : MonoBehaviour
{
    public void GameLogicProcessCharacter() {

        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_JUMP) {
            Debug.Log(cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity.y);
            if (cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity.y < 0.0f) {
                cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_FALL, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage);
            }
            return;
        }
    }
    public void GameLogicProcessItem() {
        cGV.I.sITEM[0].cGameObject.SetActive(true);
        //아이템 액티브 온
        //충돌 시 삭제
        //아이템 이동 경로 및 생성
    }
    void Update() {
        if (cGV.I.vApplicationState < 0 || cGV.I.vApplicationState >= cGV.MAX_APPLICATION_STATE_NUM) {
            return;
        }
        if (!cGV.I.vCheckApplicationState[cGV.I.vApplicationState]) {
            return;
        }
        switch (cGV.I.vApplicationState) {
            case cGV.APPLICATION_STATE_MAIN:
                break;
            case cGV.APPLICATION_STATE_CHSL:
                break;
            case cGV.APPLICATION_STATE_GAME:
                GameLogicProcessCharacter();
                GameLogicProcessItem();
                break;
            case cGV.APPLICATION_STATE_GAOV:
                break;
        }
    }
}
