using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cIC : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D tCollision) {
        int index01, index02;
        if(cGV.I.vApplicationState != cGV.APPS_GAME) {
            return;
        }
        for(index01 = 0; index01 < cGV.MAX_ITEM_NUM; index01++) {
            for(index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {//몇 번째 아이템인지 확인 하고
                if(cGV.I.sItem[index01, index02].cItemGameObject == gameObject) {
                    if (tCollision.gameObject == cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject) {//캐릭터랑 부딛힌 거면
                        cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_HIT, 0, 0, cGV.I.sItem[index01, index02].vMessage);
                    }
                    if (tCollision.gameObject == cGV.I.cClippingObject) {//바닥이랑 부딛힌 거면
                        cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_CLIPPING, 0, 0, cGV.I.sItem[index01, index02].vMessage);
                    }
                    break;
                }
            }
        }

    }
/*    public void OnCollisionExit2D(Collision2D tCollision) {

    }*/
}
