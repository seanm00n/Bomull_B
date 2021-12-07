using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInput : MonoBehaviour
{
    public void CharacterSelectInputProcess() {
        int index01;
        Vector3 tPosition;
        Vector2 tDirection;
        RaycastHit2D tHit;

        if (Input.GetMouseButtonUp(0) != true) {
            return;
        }
        tPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tDirection.x = 0.0f;
        tDirection.y = 0.0f;
        tHit = Physics2D.Raycast(tPosition, tDirection);
        if (tHit.collider == null) {
            return;
        }

        for (index01 = 0; index01 < cGV.MAX_CHARACTER_NUM; index01++) {
            if (tHit.collider.name == cGV.I.vCharacterName[index01]) {
                cGV.I.vCharacterIndex = index01;//??
                cInit.I.Destroy_Character_Select();
            }
        }
        if (cInit.I.Initialize_Game() != true) {
            cGV.I.QuitProcess("Error::Initialize_Game() == false");
            return;
        }
    }

    public void GameInputProcess() {

    }
    void Update()
    {
        switch (cGV.I.vApplicationState) {
            case cGV.APPS_MAIN:
                break;
            case cGV.APPS_CHSL:
                this.CharacterSelectInputProcess();
                break;
            case cGV.APPS_GAME:
                this.GameInputProcess();
                break;
            case cGV.APPS_PAUS:
                break;
            case cGV.APPS_GAOV:
                break;
        }
    }
    public void OnClickButton01() {
        cInit.I.Destroy_Main();
        cInit.I.Initialize_CharacterSelect();
    }
    public void OnClickButton02() {
        Application.Quit();
    }
    public void OnClickButton03() {
        cInit.I.Destroy_Game();
        cInit.I.Initialize_Pause();
    }
    public void OnClickButton04() {
        cInit.I.Destroy_Pause();
        cInit.I.Initialize_Game();
    }
    public void OnClickButton05() {
        cInit.I.Destroy_Pause();
        cInit.I.Initialize_Main();
    }
    public void OnClickButton06() {
        cInit.I.Destroy_GameOver();
        cInit.I.Initialize_Game();
    }
    public void OnClickButton07() {
        cInit.I.Destroy_GameOver();
        cInit.I.Initialize_Main();
    }

}