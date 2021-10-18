using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cInit : MonoBehaviour
{
    static private cInit getInit;
    static public cInit I {
        get {
            if (getInit == null)
                return null;
            return getInit;
        }
    }
    public bool Initialize() {
        cGV.I.vApplicationState = 0;
        cGV.I.vCheckApplicationState = null;
        cGV.I.vCheckApplicationState = new bool[cGV.MAX_APPLICATION_STATE_NUM];
        return true;
    }
    public bool Initialize_Character() {
        int index01;
        cChar.I.vCharacterName = null;
        cChar.I.vCharacterName = new string[cChar.MAX_CHARACTER_NUM];
        cChar.I.vCharacterName[cChar.CHARACTER_MAN] = "Character";
        for (index01 = 0; index01 < cChar.MAX_CHARACTER_NUM; index01++) {
            if (cChar.I.vCharacterName[index01] == null) {
                cGV.I.QuitProcess("Error::CharacterName is null");
                return false;
            }
        }

        cChar.I.vAnimationName = null;
        cChar.I.vAnimationName = new string[cChar.MAX_ANIMATION_STATE_NUM];
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_IDLE] = "Idle";
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_RUN] = "Run";
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_JUMP] = "Jump";
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_FALL] = "Fall";
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_HIT] = "Hit";
        cChar.I.vAnimationName[cChar.ANIMATION_STATE_DIE] = "Die";
        for (index01 = 0; index01 < cChar.MAX_ANIMATION_STATE_NUM; index01++) {
            if (cChar.I.vAnimationName[index01] == null) {
                cGV.I.QuitProcess("Error::AnimationName is null");
                return false;
            }
        }
        cChar.I.sCharacter = null;
        cChar.I.sCharacter = new cChar.CHARACTER[cChar.MAX_CHARACTER_NUM];
        if (cChar.I.sCharacter == null) {
            cGV.I.QuitProcess("Error::Character Struct is null");
            return false;
        }
        for(index01 = 0; index01 < cChar.MAX_CHARACTER_NUM; index01++) {
            cChar.I.sCharacter[index01].cGameObject = null;
            cChar.I.sCharacter[index01].cGameObject = GameObject.Find(cChar.I.vCharacterName[index01]);
            if (cChar.I.sCharacter[index01].cGameObject == null) {
                cGV.I.QuitProcess("Error::Character GameObject is null");
                return false;
            }
            cChar.I.sCharacter[index01].cRigidbody = null;
            cChar.I.sCharacter[index01].cRigidbody = cChar.I.sCharacter[index01].cGameObject.GetComponent<Rigidbody2D>();
            if (cChar.I.sCharacter[index01].cRigidbody == null) {
                cGV.I.QuitProcess("Error::Rigidbody is null");
                return false;
            }
            cChar.I.sCharacter[index01].cCollider = null;
            cChar.I.sCharacter[index01].cCollider = cChar.I.sCharacter[index01].cGameObject.GetComponent<BoxCollider2D>();
            if (cChar.I.sCharacter[index01].cCollider == null) {
                cGV.I.QuitProcess("Error::Collider is null"); 
                return false;
            }

            cChar.I.sCharacter[index01].cSpriteRenderer = null;
            cChar.I.sCharacter[index01].cSpriteRenderer = cChar.I.sCharacter[index01].cGameObject.GetComponent<SpriteRenderer>();
            if (cChar.I.sCharacter[index01].cSpriteRenderer == null) {
                cGV.I.QuitProcess("Error::SpriteRenderer is null");
                return false;
            }
            cChar.I.sCharacter[index01].cAnimator = null;
            cChar.I.sCharacter[index01].cAnimator = cChar.I.sCharacter[index01].cGameObject.GetComponent<Animator>();
            if (cChar.I.sCharacter[index01].cAnimator == null) {
                cGV.I.QuitProcess("Error::Animator is null");
                return false;
            }
            cChar.I.sCharacter[index01].vDirection = 0;
            cChar.I.sCharacter[index01].vAnimationIndex = 0;
            cChar.I.sCharacter[index01].vLifePoint = 0;
            cChar.I.sCharacter[index01].vRunSpeed = 0.0f;
            cChar.I.sCharacter[index01].vJumpSpeed = 0.0f;
            cChar.I.sCharacter[index01].vX = 0.0f;
            cChar.I.sCharacter[index01].vY = 0.0f;
        }
        return true;
    }
    public bool Initialize_Item() {
        return true;
    }
    public bool Initialize_Main() {
        cGV.I.vApplicationState = cGV.APPLICATION_STATE_MAIN;
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_MAIN] = true;
        return true;
    }
    public void Destroy_Main() {
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_MAIN] = false;
    }
    public bool Initialize_CharacterSelect() {
        cGV.I.vApplicationState = cGV.APPLICATION_STATE_CHSL;
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_CHSL] = true;
        return true;
    }
    public void Destroy_Character_Select() {
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_CHSL] = false;
    }
    public bool Initialize_Game() {
        cGV.I.vApplicationState = cGV.APPLICATION_STATE_GAME;
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_GAME] = true;
        return true;
    }
    public void Destroy_Game() {
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_GAME] = false;
    }
    public bool Initialize_GameOver() {
        cGV.I.vApplicationState = cGV.APPLICATION_STATE_GAOV;
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_GAOV] = true;
        return true;
    }
    public void Destroy_GameOver() {
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_GAOV] = false;
    }
    public bool Initialize_Pause() {
        cGV.I.vApplicationState = cGV.APPLICATION_STATE_PAUS;
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_PAUS] = true;
        return true;
    }
    public void Destroy_Pause() {
        cGV.I.vCheckApplicationState[cGV.APPLICATION_STATE_PAUS] = false;
    }
    void Awake() {
        getInit = null;
        getInit = this;
        if (getInit == null) {
            cGV.I.QuitProcess("[Error:: getInit == null]");
            return;
        }
        Application.targetFrameRate = cGV.vFPS;
        Initialize();
    }
}
