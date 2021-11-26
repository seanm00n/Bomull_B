using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCC : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D tCollision) {
        if (cGV.I.vApplicationState != cGV.APPLICATION_STATE_GAME) {
            return;
        }
        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_DEATH) {
            return;
        }
        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_FALL && tCollision.gameObject == cGV.I.cClippingObject) {
            cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_CLIPPING, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage);
        }
        int index01, index02;
        for (index01 = 0; index01 < cGV.MAX_MONSTER_DATA_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_MONSTER_NUM; index02++) {
                if (!cGV.I.sMonster[index01, index02].cGameObject.activeSelf) {//부딛힌 객체 하나씩
                    continue;
                }
                if (cGV.I.sMonster[index01, index02].cGameObject == tCollision.gameObject) {//??
                    break;
                }
            }
            if (index02 < cGV.MAX_MONSTER_NUM) {
                break;
            }

        }
        if (index01 < cGV.MAX_MONSTER_DATA_NUM) {
            cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_COLLISION, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterDataIndex].vMessage);
        }
        //검색루프 교체 가능

    }
    public void OnCollisionExit2D(Collision2D tCollision) {
        if (cGV.I.vApplicationState != cGV.APPLICATION_STATE_GAME) {
            return;
        }
        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_DEATH) {
            return;
        }
        int index01, index02;
        for (index01 = 0; index01 < cGV.MAX_MONSTER_DATA_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_MONSTER_NUM; index02++) {
                if (!cGV.I.sMonster[index01, index02].cGameObject.activeSelf) {
                    continue;
                }
                if (cGV.I.sMonster[index01, index01].cGameObject == tCollision.gameObject) {
                    break;
                }
            }
            if (index02 < cGV.MAX_MONSTER_NUM) {
                break;
            }
        }
        if (index01 < cGV.MAX_MONSTER_DATA_NUM) {
            cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_COLLISION, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterDataIndex].vMessage, null, false);
        }
    }
}
