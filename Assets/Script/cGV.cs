using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System;

public class cGV
{
    static private cGV getGV;
    static public cGV I {
        get {
            if (getGV != null)//기존에 만들었으면 전달
                return getGV;
            getGV = new cGV();//기존에 안만들었으면 생성 후 전달
            return getGV;
        }
    }   
    public const int vFPS = 60;

    public const int APPLICATION_STATE_MAIN = 0;
    public const int APPLICATION_STATE_CHSL = 1;
    public const int APPLICATION_STATE_GAME = 2;
    public const int APPLICATION_STATE_PAUS = 3;
    public const int APPLICATION_STATE_GAOV = 4;
    public const int MAX_APPLICATION_STATE_NUM = 5;
    public int vApplicationState;
    public bool[] vCheckApplicationState;

    public string vCanvasName;
    public struct TEXT{
        public GameObject cTextDir;//중간 디렉토리용
        public GameObject[] cTextGameObject;//오브젝트용
    }
    public TEXT sText;

    public string vTextDirName;
    public const int TEXT_MAIN_01 = 0;
    public const int TEXT_MAIN_02 = 1;
    public const int TEXT_CHSL_01 = 2;
    public const int TEXT_PAUS_01 = 3;
    public const int TEXT_GAOV_01 = 4;
    public const int MAX_TEXT_NUM = 5;
    
    //텍스트는 Canvas\Text\에서 순서대로 찾아 인식
    public struct BACKGROUND {
        public GameObject cBackgroundDir;//중간 디렉토리용
        public GameObject cBackgroundBottomDir;//중간 디렉토리용
        public GameObject[] cBackgroundGameObject;//오브젝트용
        public GameObject[] cBackgroundBottomGameObject;
    }

    public BACKGROUND sBackground;
    public const int BACKGROUND_01 = 0;
    public const int BACKGROUND_02 = 1;
    public const int BACKGROUND_03 = 2;
    public const int BACKGROUND_04 = 3;
    public const int MAX_BACKGROUND_NUM = 4;
    public string vBackgroundDirName;

    public const int BACKGROUNDBOTTOM_01 = 0;
    public const int MAX_BACKGROUNDBOTTOM_NUM = 1;
    public string vBackgroundBottomDirName;

    public struct BUTTON {
        public GameObject cButtonDir;
        public GameObject[] cButtonGameObject;
        public Button[] cButtonComponent;
    }
    public BUTTON sButton;
    public string vButtonDirName;
    public const int BUTTON_01 = 0;
    public const int BUTTON_02 = 1;
    public const int BUTTON_03 = 2;
    public const int BUTTON_04 = 3;
    public const int BUTTON_05 = 4;
    public const int BUTTON_06= 5;
    public const int BUTTON_07 = 6;
    public const int MAX_BUTTON_NUM = 7;

    public GameObject cCanvasGameObject;

    public struct CHARACTER {
        public GameObject cGameObject;
        public Rigidbody2D cRigidBody;
        public BoxCollider2D cCollider; //cCC, cInit.Initialize_Character() 수정
        public SpriteRenderer cSpriteRenderer;
        public Animator cAnimator;
        public int vDirection;
        public int vAnimationIndex;
        public int vLifePoint;
        public float vRunSpeed;
        public float vJumpSpeed;
        public float vGravityScale;
        public int[] vAnimationHash;
        public float vX;
        public float vY;
        public int[,] vMessage;
    }

    public CHARACTER[] sCharacter;
    public CHARACTER[] sITEM;
    public CHARACTER[,] sItem;

    public const int CHARACTER_MAN = 0;
    public const int MAX_CHARACTER_NUM = 1;
    public string[] vCharacterName;
    public int vCharacterIndex;

    public const int ANIMATION_STATE_IDLE = 0;
    public const int ANIMATION_STATE_RUN = 1;
    public const int ANIMATION_STATE_JUMP = 2;
    public const int ANIMATION_STATE_FALL = 3;
    public const int ANIMATION_STATE_HIT = 4;
    public const int ANIMATION_STATE_DEATH = 5;
    public const int MAX_ANIMATION_STATE_NUM = 6;
    public string[] vAnimationName;

    public const int MAX_MESSAGE_NUM = 64;
    public const int MAX_SUB_MESSAGE_SORT_NUM = 3;
    public const int SUB_MESSAGE_TYPE_NONE = 0;
    public const int SUB_MESSAGE_TYPE_CLIPPING = 1;
    public const int SUB_MESSAGE_TYPE_FALL = 2;
    public const int SUB_MESSAGE_TYPE_ATTACK_END = 3;
    public const int SUB_MESSAGE_TYPE_TARGET_1 = 4;
    public const int SUB_MESSAGE_TYPE_TARGET_2 = 5;
    public const int SUB_MESSAGE_TYPE_HIT_1 = 6;
    public const int SUB_MESSAGE_TYPE_HIT_2 = 7;
    public const int SUB_MESSAGE_TYPE_HIT_END = 8;
    public const int SUB_MESSAGE_TYPE_COLLISION = 9;
    public const int SUB_MESSAGE_TYPE_DEATH = 10;
    public const int SUB_MESSAGE_TYPE_DEATH_END = 11;
    public const int SUB_MESSAGE_TYPE_RESURRECTION = 12;

    public const int ERROR_VALUE = -1;

    public void QuitProcess(string tstring) {
        #if UNITY_EDITOR
        Debug.LogError(tstring);
        EditorApplication.ExecuteMenuItem("Edit/Play");
        #else
        Application.Quit();
        #endif
    }

    public void SetAnimation(int tAnimationIndex, ref CHARACTER tCharacter) {
        int index01;

        if (vAnimationName == null) {
            QuitProcess("Error::vAnimationName == null");
            return;
        }

        if (tAnimationIndex < 0 || MAX_ANIMATION_STATE_NUM <= tAnimationIndex) {
            QuitProcess("Error::tAnimationIndex out of range");
            return;
        }
        tCharacter.cAnimator.SetBool(vAnimationName[tAnimationIndex], true);
        tCharacter.vAnimationIndex = tAnimationIndex;

        for (index01 = 0; index01 < MAX_ANIMATION_STATE_NUM; index01++) {
            if (tAnimationIndex != index01)
                tCharacter.cAnimator.SetBool(vAnimationName[index01], false);
        }
    }
    public float GetAnimationNormalizeTime(Animator tAnimator) {
        if (tAnimator == null) {
            return 0;
        }
        return tAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    public int GetCurrentAnimation(CHARACTER tCharacter) {
        int index01;
        if (tCharacter.vAnimationHash == null) {
            return ERROR_VALUE;
        }
        for (index01 = 0; index01 < MAX_ANIMATION_STATE_NUM; index01++) {
            if (tCharacter.cAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash == tCharacter.vAnimationHash[index01]) {
                return index01;
            }
        }
        return ERROR_VALUE;
    }
    public void SetDirection(int tDirection, ref CHARACTER tCharacter) {
        Vector3 tVector3;

        if (tDirection != -1 && tDirection != 1) {
            return;
        }

        if (tCharacter.vDirection != tDirection) {
            tVector3.x = 0.0f;
            tVector3.y = 180.0f;
            tVector3.z = 0.0f;
            tCharacter.cGameObject.transform.Rotate(tVector3);
            tCharacter.vDirection = tDirection;
        }
    }
    public bool AddMessage(int tSubMessageType, int tSubMessageValue1, int tSubMessageValue2, int[,] tMessage) {
        int index01;
        if (tMessage == null) {
            return false;
        }
        for (index01 = 0; index01 < MAX_MESSAGE_NUM; index01++) {
            if (tMessage[index01, 0] == tSubMessageType &&
                tMessage[index01, 1] == tSubMessageValue1 &&
                tMessage[index01, 2] == tSubMessageValue2) {
                return false;
            }
        }
        for (index01 = 0; index01 < MAX_MESSAGE_NUM; index01++) {
            if (tMessage[index01, 0] == SUB_MESSAGE_TYPE_NONE) {
                break;
            }
        }
        if (index01 < MAX_MESSAGE_NUM) {
            tMessage[index01, 0] = tSubMessageType;
            tMessage[index01, 1] = tSubMessageValue1;
            tMessage[index01, 2] = tSubMessageValue2;
            return true;
        }
        return false;
    }
    public bool GetMessage(int tSubMessageType, int tSubMessageValue1, int tSubMessageValue2, int[,] tMessage, int[] tMessage_Out, bool CheckOnly) {
        int index01;
        bool RETURN_VALUE;
        if (tMessage == null) {
            return false;
        }
        RETURN_VALUE = false;

        switch (tMessage_Out) {
            case null:
                for (index01 = 0; index01 < MAX_MESSAGE_NUM; index01++) {
                    if (tMessage[index01, 0] != tSubMessageType ||
                        tMessage[index01, 1] != tSubMessageValue1 ||
                        tMessage[index01, 2] != tSubMessageValue2) {
                        continue;
                    }
                    if (CheckOnly == false) {
                        tMessage[index01, 0] = SUB_MESSAGE_TYPE_NONE;
                        tMessage[index01, 1] = 0;
                        tMessage[index01, 2] = 0;
                    }
                    RETURN_VALUE = true;
                }
                break;
            default:
                for (index01 = 0; index01 < MAX_MESSAGE_NUM; index01++) {
                    if (tMessage[index01, 0] != tSubMessageType) {
                        continue;
                    }
                    tMessage_Out[0] = tMessage[index01, 0];//attack array
                    tMessage_Out[1] = tMessage[index01, 1];//monster data array
                    tMessage_Out[2] = tMessage[index01, 2];//monster clone array
                    if (CheckOnly == false) {
                        tMessage[index01, 0] = SUB_MESSAGE_TYPE_NONE;
                        tMessage[index01, 1] = 0;
                        tMessage[index01, 2] = 0;
                    }
                    RETURN_VALUE = true;
                }
                break;
        }
        return RETURN_VALUE;
    }

}
