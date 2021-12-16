using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCC : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D tCollision) {
        int index01, index02;
        for(index01 = 0; index01 < cGV.MAX_ITEM_NUM; index01++) {
            for(index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {
                if(tCollision.gameObject == cGV.I.sItem[index01, index02].cItemGameObject) {
                    if(cGV.I.sItem[index01, index02].vIsStone) {
                        cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_HIT,0,0,cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage);
                    }
                    else {
                        cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_OBTAIN, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage);
                    }
                }
            }
        }
    }
/*    public void OnCollisionExit2D(Collision2D tCollision) {

    }*/
}
