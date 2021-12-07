using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDraw : MonoBehaviour
{
    void Update()
    {
        int index01;
        void allTrue() {
            cGV.I.cCanvasGameObject.SetActive(true);

            cGV.I.sText.cTextDir.SetActive(true);
            for(index01 = 0; index01 < cGV.MAX_TEXT_NUM; index01++) {
                cGV.I.sText.cTextGameObject[index01].SetActive(true);
            }
            cGV.I.sBackground.cBackgroundDir.SetActive(true);
            for (index01 = 0; index01 < cGV.MAX_BACKGROUND_NUM; index01++) {
                cGV.I.sBackground.cBackgroundGameObject[index01].SetActive(true);
            }
            cGV.I.sBackground.cBackgroundBottomDir.SetActive(true);
            cGV.I.sButton.cButtonDir.SetActive(true);
            for(index01 = 0; index01 < cGV.MAX_BUTTON_NUM; index01++) {
                cGV.I.sButton.cButtonGameObject[index01].SetActive(true);
            }
            cGV.I.sCharacter[cGV.CHARACTER_MAN].cGameObject.SetActive(true);
        }
        
        switch (cGV.I.vApplicationState) {
            case cGV.APPS_MAIN:
                allTrue();
                cGV.I.sText.cTextGameObject[cGV.TEXT_CHSL_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_PAUS_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_GAOV_01].SetActive(false);
                cGV.I.sBackground.cBackgroundDir.SetActive(false);
                cGV.I.sBackground.cBackgroundBottomDir.SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_03].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_04].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_05].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_06].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_07].SetActive(false);
                cGV.I.sCharacter[cGV.CHARACTER_MAN].cGameObject.SetActive(false);
                break;
            case cGV.APPS_CHSL:
                allTrue();
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_02].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_PAUS_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_GAOV_01].SetActive(false);
                cGV.I.sBackground.cBackgroundDir.SetActive(false);
                cGV.I.sBackground.cBackgroundBottomDir.SetActive(false);
                cGV.I.sButton.cButtonDir.SetActive(false);
                break;
            case cGV.APPS_GAME:
                allTrue();
                cGV.I.sText.cTextDir.SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_01].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_02].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_04].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_05].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_06].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_07].SetActive(false);
                cGV.I.sUIButton.cUIButtonDir.SetActive(true);
                //
                break;
            case cGV.APPS_PAUS:
                //회색처리, 게임정지
                allTrue();
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_02].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_CHSL_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_GAOV_01].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_01].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_02].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_03].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_06].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_07].SetActive(false);
                break;
            case cGV.APPS_GAOV:
                allTrue();
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_02].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_CHSL_01].SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_PAUS_01].SetActive(false);
                cGV.I.sBackground.cBackgroundDir.SetActive(false);
                cGV.I.sBackground.cBackgroundBottomDir.SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_01].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_02].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_03].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_04].SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_05].SetActive(false);
                cGV.I.sCharacter[cGV.CHARACTER_MAN].cGameObject.SetActive(false);
                break;
        }

    }
}
