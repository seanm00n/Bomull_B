using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDraw : MonoBehaviour
{
    void Update()
    {
        switch (cGV.I.vApplicationState) {
            case cGV.APPLICATION_STATE_MAIN:
                cGV.I.cCanvasGameObject.SetActive(false);//다끄기
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_01].SetActive(true);
                cGV.I.sText.cTextGameObject[cGV.TEXT_MAIN_02].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_01].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_02].SetActive(true);
                break;
            case cGV.APPLICATION_STATE_CHSL:
                cGV.I.cCanvasGameObject.SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_CHSL_01].SetActive(true);
                break;
            case cGV.APPLICATION_STATE_GAME:
                cGV.I.cCanvasGameObject.SetActive(false);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_03].SetActive(true);
                break;
            case cGV.APPLICATION_STATE_PAUS:
                cGV.I.cCanvasGameObject.SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_PAUS_01].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_04].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_05].SetActive(true);
                //화면 반투명or흑백 효과 넣기
                break;
            case cGV.APPLICATION_STATE_GAOV:
                cGV.I.cCanvasGameObject.SetActive(false);
                cGV.I.sText.cTextGameObject[cGV.TEXT_GAOV_01].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_06].SetActive(true);
                cGV.I.sButton.cButtonGameObject[cGV.BUTTON_07].SetActive(true);
                break;
        }

    }
}
