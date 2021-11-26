using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cIC : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D tCollision) {
        int index01 = 0, index02 = 0, tDirection = 0;
        Vector3 tVector3;
        Vector2 tVector2;
        if (cGV.I.vApplicationState != cGV.APPLICATION_STATE_GAME) {
            return;
        }
        if (tCollision.gameObject != cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject) {//충돌 대상이 캐릭터가 아니면
            return;
        }
        for (index01 = 0; index01 < cGV.MAX_ITEM_DATA_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_ITEM_NUM; index02++) {
                if (!cGV.I.sItem[index01, index02].cGameObject.activeSelf) {
                    continue;
                }
                if (cGV.I.sItem[index01, index02].vAnimationIndex == cGV.ANIMATION_STATE_DEATH) {
                    continue;
                }
                if (cGV.I.sItem[index01, index02].cGameObject == gameObject) {
                    break;
                }
            }
            if (index02 < cGV.MAX_ITEM_NUM) {
                break;
            }
        }
        if (index01 < cGV.MAX_ITEM_DATA_NUM) {
            tVector3.x = 0.0f;
            tVector3.y = cGV.I.sItem[index01, index02].cRigidBody.velocity.y;
            tVector3.z = 0.0f;
            cGV.I.sItem[index01, index02].cRigidBody.velocity = tVector3;
            cGV.I.SetAnimation(cGV.ANIMATION_STATE_HIT, ref cGV.I.sItem[index01, index02]);
            tDirection = (cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.transform.position.x < cGV.I.sItem[index01, index02].cGameObject.transform.position.x) ? -1 : 1;
            cGV.I.SetDirection(tDirection, ref cGV.I.sItem[index01, index02]);
            tVector2.x = (cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.transform.position.x < cGV.I.sItem[index01, index02].cGameObject.transform.position.x) ?
               cGV.I.sItem[index01, index02].vRunSpeed : cGV.I.sItem[index01, index02].vRunSpeed * -1;
            tVector2.y = 0.0f;
            cGV.I.sItem[index01, index02].cRigidBody.AddForce(tVector2, ForceMode2D.Impulse);
            cGV.I.AddMessage(cGV.SUB_MESSAGE_TYPE_COLLISION, 0, 0, cGV.I.sItem[index01, index02].vMessage);
        }
    }
    public void OnCollisionExit2D(Collision2D tCollision) {
        int index01 = 0, index02 = 0;
        if (cGV.I.vApplicationState != cGV.APPLICATION_STATE_GAME) {
            return;
        }
        if (tCollision.gameObject != cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject) {
            return;
        }
        for (index01 = 0; index01 < cGV.MAX_ITEM_DATA_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_ITEM_NUM; index02++) {
                if (!cGV.I.sItem[index01, index02].cGameObject.activeSelf) {
                    continue;
                }
                if (cGV.I.sItem[index01, index02].vAnimationIndex == cGV.ANIMATION_STATE_DEATH) {
                    continue;
                }
                if (cGV.I.sItem[index01, index02].cGameObject == gameObject) {
                    break;
                }
            }
            if (index02 < cGV.MAX_ITEM_NUM) {
                break;
            }
        }
        if (index01 < cGV.MAX_ITEM_DATA_NUM) {
            cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_COLLISION, 0, 0, cGV.I.sItem[index01, index02].vMessage, null, false);
        }
    }
}
