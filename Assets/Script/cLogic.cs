﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLogic : MonoBehaviour
{
    public void GameLogicProcessCharacter() {

        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIS_JUMP) {
            
            if (cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity.y < 0.0f) {
                cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_FALL, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage);
            }
            return;
        }
    }
    public void GameLogicProcessItem() {

    }
    void Update() {
        if (cGV.I.vApplicationState < 0 || cGV.I.vApplicationState >= cGV.MAX_APPS_NUM) {
            return;
        }
        if (!cGV.I.vCheckApplicationState[cGV.I.vApplicationState]) {
            return;
        }
        switch (cGV.I.vApplicationState) {
            case cGV.APPS_MAIN:
                break;
            case cGV.APPS_CHSL:
                break;
            case cGV.APPS_GAME:
                GameLogicProcessCharacter();
                GameLogicProcessItem();
                break;
            case cGV.APPS_GAOV:
                break;
        }
    }
}
