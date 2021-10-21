using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInput : MonoBehaviour
{
    public void OnClick01() {
        Debug.Log("asdf");
        cInit.I.Destroy_Main();
        cInit.I.Initialize_Game();
        //cInit.I.Destroy_Main(); cInit.I.Initialize_CharacterSelect();
        //button 예시, 초기화 필요
    }
    void Update()
    {

        switch (cGV.I.vApplicationState) {
            case cGV.APPLICATION_STATE_MAIN:
                break;
            case cGV.APPLICATION_STATE_CHSL:
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