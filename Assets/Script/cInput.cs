using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cInput : MonoBehaviour
{
    void Update()
    {
        switch (cGV.I.vApplicationState) {
            case cGV.APPLICATION_STATE_MAIN:
                //if(CHSL버튼 입력) cInit.I.Destroy_Main(); cInit.I.Initialize_CharacterSelect();
                //if(EXIT버튼 입력) cGV.I.QuitProcess("asdf");
                break;
            case cGV.APPLICATION_STATE_CHSL:
                //if (캐릭터선택) cInit.I.Destroy_Character_Select(); cInit.I.Initialize_Game();
                break;
            case cGV.APPLICATION_STATE_GAME:
                cLogic.I.GameLogic();
                break;
            case cGV.APPLICATION_STATE_PAUS:
                break;
            case cGV.APPLICATION_STATE_GAOV:
                break;
        }
    }
}
