﻿using System.Collections;
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
        //float tValueY;
        Vector3 tVector3;
        Vector2 tVector2;
        if (!cGV.I.sCharacter[cGV.I.vCharacterIndex].cGameObject.activeSelf) {//true상태인지 확인
            return;
        }

        tValueX = 0.0f;
        tValueX = Input.GetAxisRaw("Horizontal");//입력값 백터값으로 저장


        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_IDLE || cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_RUN) {//IDLE or RUN이고
            if (Input.GetKey(KeyCode.Space)) {//점프키 누르면
                tVector2.x = 0.0f;
                tVector2.y = cGV.I.sCharacter[cGV.I.vCharacterIndex].vJumpSpeed;
                cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.AddForce(tVector2, ForceMode2D.Impulse);//가속주고
                cGV.I.SetAnimation(cGV.ANIMATION_STATE_JUMP, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);//JUMP애니메이션으로 변경
                return;
            }
            if (tValueX == 1.0f || tValueX == -1.0f) {//입력값이 좌(-1) 또는 우(1) 일때
                cGV.I.SetAnimation(cGV.ANIMATION_STATE_RUN, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);
            } else {
                cGV.I.SetAnimation(cGV.ANIMATION_STATE_IDLE, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);
            }
        }

        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_JUMP) {//점프했을때
            if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_FALL, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage, null, false) == true) {//FALL 메시지 받으면 
                cGV.I.SetAnimation(cGV.ANIMATION_STATE_FALL, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);//FALL애니메이션으로 변경
                return;
            }
        }

        if (cGV.I.sCharacter[cGV.I.vCharacterIndex].vAnimationIndex == cGV.ANIMATION_STATE_FALL) {//FALL상태이고
            if (cGV.I.GetMessage(cGV.SUB_MESSAGE_TYPE_CLIPPING, 0, 0, cGV.I.sCharacter[cGV.I.vCharacterIndex].vMessage, null, false) == true) {//바닥에 닫는 메시지 받으면
                cGV.I.SetAnimation(cGV.ANIMATION_STATE_IDLE, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);//IDLE애니메이션으로 변경
                return;
            }
        }

        if (tValueX == 1.0f || tValueX == -1.0f) {
            cGV.I.SetDirection((int)tValueX, ref cGV.I.sCharacter[cGV.I.vCharacterIndex]);//방향선택
        }

        tVector3.x = tValueX * cGV.I.sCharacter[cGV.I.vCharacterIndex].vRunSpeed;
        tVector3.y = cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity.y;
        tVector3.z = 0.0f;
        cGV.I.sCharacter[cGV.I.vCharacterIndex].cRigidBody.velocity = tVector3;
        //문제 없을 시 이동처리

    }
    void Update()
    {
        switch (cGV.I.vApplicationState) {
            case cGV.APPLICATION_STATE_MAIN:
                break;
            case cGV.APPLICATION_STATE_CHSL:
                CharacterSelectInputProcess();
                break;
            case cGV.APPLICATION_STATE_GAME:
                this.GameInputProcess();
                break;
            case cGV.APPLICATION_STATE_PAUS:
                break;
            case cGV.APPLICATION_STATE_GAOV:
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