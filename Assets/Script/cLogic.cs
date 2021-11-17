using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLogic : MonoBehaviour
{
    public void GameLogicProcessCharacter() {

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
                break;
            case cGV.APPLICATION_STATE_GAOV:
                break;
        }
    }
}
