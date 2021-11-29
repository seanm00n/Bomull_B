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

        float tValueX;
        Vector2 tVector2;
        Vector3 tVector3;
        cGV.CHARACTER tGO = cGV.I.sCharacter[cGV.I.vCharacterIndex];
        tValueX = Input.GetAxisRaw("Horizontal");//입력값 백터값으로 저장

        //Item과 충돌 시-------------------------------------------------------------------------------//
        if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_COLLISION, 0, 0, tGO.vMessage, null, false) == true) {
            if (tGO.vAnimationIndex != cGV.ANIS_JUMP) {//Jump는 충돌을 무시한다
                if (tGO.vAnimationIndex == cGV.ANIS_FALL) {//떨어지면서 몬스터를 밟았다
                    tVector2.x = 0.0f;
                    tVector2.y = tGO.vJumpSpeed;
                    tGO.cRigidBody.AddForce(tVector2, ForceMode2D.Impulse);
                    cGV.I.SetAnimation(cGV.ANIS_JUMP, ref tGO);
                } else {
                    cGV.I.SetAnimation(cGV.ANIS_HIT, ref tGO);
                    tVector2.x = 0.0f;
                    tVector2.y = 0.0f;
                    tGO.cRigidBody.velocity = tVector2;
                }
            }
            return;
        }
        //---------------------------------------------------------------------------------------------//


        //Jump---------------------------------------------------------------------------------------//
        if (tGO.vAnimationIndex == cGV.ANIS_IDLE || tGO.vAnimationIndex == cGV.ANIS_RUN) {//IDLE or RUN이고
            if (/**/) {//점프키 누르면
                tVector2.x = 0.0f;
                tVector2.y = tGO.vJumpSpeed;
                tGO.cRigidBody.AddForce(tVector2, ForceMode2D.Impulse);//가속주고
                cGV.I.SetAnimation(cGV.ANIS_JUMP, ref tGO);//JUMP애니메이션으로 변경
                return;
            }
            if (/**/) {//입력값이 좌(-1) 또는 우(1) 일때
                cGV.I.SetAnimation(cGV.ANIS_RUN, ref tGO);
            } else {
                cGV.I.SetAnimation(cGV.ANIS_IDLE, ref tGO);
            }
        }
        //-------------------------------------------------------------------------------------------//


        //Jump to Fall---------------------------------------------------------------------------------//
        if (tGO.vAnimationIndex == cGV.ANIS_JUMP) {//점프했을때
            if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_FALL, 0, 0, tGO.vMessage, null, false) == true) {//FALL 메시지 받으면 
                cGV.I.SetAnimation(cGV.ANIS_FALL, ref tGO);//FALL애니메이션으로 변경
                return;
            }
        }

        if (tGO.vAnimationIndex == cGV.ANIS_FALL) {//FALL상태이고
            if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_CLIPPING, 0, 0, tGO.vMessage, null, false) == true) {//바닥에 닫는 메시지 받으면
                cGV.I.SetAnimation(cGV.ANIS_IDLE, ref tGO);//IDLE애니메이션으로 변경
                return;
            }
        }
        //---------------------------------------------------------------------------------------------//


        //방향선택----------------------------------------------------------------------------------//
        if (/**/) {//좌 또는 우 입력시
            cGV.I.SetDirection((int)tValueX, ref tGO);
        }
        //------------------------------------------------------------------------------------------//

        tVector3.x = tValueX * tGO.vRunSpeed;
        tVector3.y = tGO.cRigidBody.velocity.y;
        tVector3.z = 0.0f;
        tGO.cRigidBody.velocity = tVector3;
        //문제 없을 시 이동처리

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