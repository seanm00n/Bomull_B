using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLogic : MonoBehaviour
{
    public void GameLogicProcessUI() {
        if(cGV.I.vApplicationState != cGV.APPS_GAME) {
            return;
        }
        cGV.I.sText.cText[cGV.TEXT_SCORE].text = string.Format("SCORE : "+cGV.I.POINT.ToString());
        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vLifePoint <= 0) {
            cInit.I.Initialize_GameOver();
        }
        
    }
    public void GameLogicProcessCharacter() {
        float tNormalizeTime;
        int tAnimationIndex;
        tAnimationIndex = cGV.I.GetCurrentAnimation(cGV.I.sCharacter[cGV.I.vCharacterIndex]);
        tNormalizeTime = cGV.I.GetAnimationNormalizeTime(cGV.I.sCharacter[cGV.I.vCharacterIndex].cAnimator);
        if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_HIT, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage, null, false)) {//돌이면
            cGV.I.SetAnimation(cGV.ANIS_HIT, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);
            cGV.I.sCharacter[cGV.I.vCharacterIndex].vLifePoint -= cGV.I.sItem[0, 0].vAttackPoint;
            cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity = new Vector2(0, 0);
        }
        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIS_HIT && tAnimationIndex == cGV.ANIS_HIT) {
            if (1.0f <= tNormalizeTime) {
                cGV.I.SetAnimation(cGV.ANIS_IDLE, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);
                return;
            }
        }
        if ((cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.transform.position.x < cGV.I.sCharacter[cGV.I.vCharacterIndex].vX && cGV.I.sCharacter[cGV.I.vCharacterIndex].vDirection == -1)||
            (cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.transform.position.x > cGV.vWorldWidth && cGV.I.sCharacter[cGV.I.vCharacterIndex].vDirection == 1)) {
            cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity = new Vector2(0, 0);
        }



        if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_OBTAIN, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage, null, false)) {//포인트면
            cGV.I.POINT += cGV.I.sItem[0, 0].vPoint;
        }
/*        if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_HIT_END, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage, null, false)) {//HIT끝나면 IDLE
            cGV.I.SetAnimation(cGV.ANIS_IDLE,ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);
        }*/


    }
    public void GameLogicProcessItem() {
        float tx = cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.transform.position.x;
        int index01, index02;
        int count = 0;
        
        
        if (cGV.I.vApplicationState != cGV.APPS_GAME) {
            return;
        }

        for (index01 = 0; index01 < cGV.MAX_ITEM_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {
                if (cGV.I.sItem[index01, index02].cItemGameObject.activeSelf) {
                    count += 1;
                }
            }
            if (count <= cGV.MAX_ITEMS_NUM) {//마릿수 검사
                continue;
            }
            
            for (index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {//캐릭터와 충돌 시 삭제
                if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_HIT, 0, 0, cGV.I.sItem[index01, index02].vMessage, null, true)|| 
                    cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_CLIPPING, 0, 0, cGV.I.sItem[index01, index02].vMessage, null, true)) {
                    cGV.I.sItem[index01, index02].cItemGameObject.SetActive(false);
                    cGV.I.DeletMessage(cGV.I.sItem[index01, index02].vMessage);
                    
                }
            }

            //랜덤 아이템 랜덤 위치에 생성 후 이동
            for (index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {
                
                int ran1 = UnityEngine.Random.Range(0, 3);
                int tSize = (int)cGV.I.sITEM[ran1].cItemCollider.size.x;
                int ran2 = UnityEngine.Random.Range(tSize,640-tSize);//랜텀한 위치에 생성
                
                if (cGV.I.sItem[index01, index02].cItemGameObject.activeSelf == false) {
                    cGV.I.sItem[ran1, index02].cItemGameObject.SetActive(true);
                    cGV.I.sItem[ran1, index02].cItemGameObject.transform.position = new Vector3(ran2, 300, 0);
                    cGV.I.sItem[ran1, index02].cItemRigidBody.velocity = new Vector2(0, -1 * cGV.I.sItem[ran1, index02].vItemSpeed);
                }
            }
        }
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
                GameLogicProcessUI();
                break;
            case cGV.APPS_GAOV:
                break;
        }
    }
}
