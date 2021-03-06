using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cInit : MonoBehaviour{
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
        cGV.I.vCheckApplicationState = new bool[cGV.MAX_APPS_NUM];

        int index01;
        cGV.I.vCanvasName = "Canvas";

        //Text
        cGV.I.vTextDirName = "Text";
        cGV.I.cCanvasGameObject = null;
        cGV.I.cCanvasGameObject = GameObject.Find(cGV.I.vCanvasName);
        if (cGV.I.cCanvasGameObject == null) {
            cGV.I.QuitProcess("Error::Canvas Directory is null");
            return false;
        }
        cGV.I.cCanvasGameObject.SetActive(false);
        
        cGV.I.sText.cTextDir = null;
        cGV.I.sText.cTextDir = cGV.I.cCanvasGameObject.transform.Find(cGV.I.vTextDirName).gameObject;//find는 상위 오브젝트 찾을때
        if (cGV.I.sText.cTextDir == null) {
            cGV.I.QuitProcess("Error::Text Direcory is null");
            return false;
        }

        cGV.I.sText.cTextGameObject = null;
        cGV.I.sText.cTextGameObject = new GameObject[cGV.MAX_TEXT_NUM];
        if (cGV.I.sText.cTextGameObject == null)
        {
            cGV.I.QuitProcess("Error::Text is null");
            return false;
        }

        cGV.I.sText.cText = null;
        cGV.I.sText.cText = new Text[cGV.MAX_TEXT_NUM];
        if (cGV.I.sText.cText == null) {
            cGV.I.QuitProcess("Error::Text component is null");
            return false;
        }

        for (index01 = 0; index01 < cGV.MAX_TEXT_NUM; index01++) {
            cGV.I.sText.cTextGameObject[index01] = null;
            cGV.I.sText.cTextGameObject[index01] = cGV.I.sText.cTextDir.transform.GetChild(index01).gameObject; //index01번째 오브젝트
            if (cGV.I.sText.cTextGameObject[index01] == null) {
                cGV.I.QuitProcess("Error::Text Child is null");
                return false;
            }
            cGV.I.sText.cText[index01] = null;
            cGV.I.sText.cText[index01] = cGV.I.sText.cTextGameObject[index01].GetComponent<Text>();//to Text Type <> Class transform
        }
        cGV.I.sText.cTextDir.SetActive(false);
        
        //Background

        cGV.I.vBackgroundDirName = "Background";
        cGV.I.vBackgroundBottomDirName = "BackgroundBottom";

        cGV.I.sBackground.cBackgroundDir = null;
        cGV.I.sBackground.cBackgroundDir = cGV.I.cCanvasGameObject.transform.Find(cGV.I.vBackgroundDirName).gameObject;//
        if (cGV.I.sBackground.cBackgroundDir == null) {
            cGV.I.QuitProcess("Error::Background Directory is null");
            return false;
        }

        cGV.I.sBackground.cBackgroundGameObject = null;
        cGV.I.sBackground.cBackgroundGameObject = new GameObject[cGV.MAX_BACKGROUND_NUM];
        if (cGV.I.sBackground.cBackgroundGameObject == null) {
            cGV.I.QuitProcess("Error::Background is null");
            return false;
        }

        cGV.I.sBackground.cBackgroundBottomDir = null;
        cGV.I.sBackground.cBackgroundBottomDir = cGV.I.cCanvasGameObject.transform.Find(cGV.I.vBackgroundBottomDirName).gameObject;
        if (cGV.I.sBackground.cBackgroundBottomDir == null) {
            cGV.I.QuitProcess("Error::BackgroundBottom Directory is null");
            return false;
        }

        cGV.I.sBackground.cBackgroundBottomGameObject = null;
        cGV.I.sBackground.cBackgroundBottomGameObject = new GameObject[cGV.MAX_BACKGROUNDBOTTOM_NUM];
        if (cGV.I.sBackground.cBackgroundBottomGameObject == null) {
            cGV.I.QuitProcess("Error::BackgroundBottom is null");
            return false;
        }

        for (index01 = 0; index01 < cGV.MAX_BACKGROUND_NUM; index01++) {
            cGV.I.sBackground.cBackgroundGameObject[index01] = null;
            cGV.I.sBackground.cBackgroundGameObject[index01] = cGV.I.sBackground.cBackgroundDir.transform.GetChild(index01).gameObject;
            if (cGV.I.sBackground.cBackgroundGameObject[index01] == null) {
                cGV.I.QuitProcess("Error::Background" + index01 + " is null");
                return false;
            }
        }

        for (index01 = 0; index01 < cGV.MAX_BACKGROUNDBOTTOM_NUM; index01++) {
            cGV.I.sBackground.cBackgroundBottomGameObject[index01] = null;
            cGV.I.sBackground.cBackgroundBottomGameObject[index01] = cGV.I.sBackground.cBackgroundBottomDir.transform.GetChild(index01).gameObject;
            if (cGV.I.sBackground.cBackgroundBottomGameObject[index01] == null) {
                cGV.I.QuitProcess("Error::BackgroundBottom" + index01 + " is null");
                return false;
            }
        }
        cGV.I.sBackground.cBackgroundDir.SetActive(false);
        cGV.I.sBackground.cBackgroundBottomDir.SetActive(false);

        //button
        cGV.I.vButtonDirName = "Button";

        cGV.I.sButton.cButtonDir = null;//상위 디렉토리찾고
        cGV.I.sButton.cButtonDir = cGV.I.cCanvasGameObject.transform.Find(cGV.I.vButtonDirName).gameObject;
        if(cGV.I.sButton.cButtonDir == null) {
            cGV.I.QuitProcess("Error::Button Directory is null");
            return false;
        }

        cGV.I.sButton.cButtonGameObject = null;//
        cGV.I.sButton.cButtonGameObject = new GameObject[cGV.MAX_BUTTON_NUM];
        if(cGV.I.sButton.cButtonGameObject == null) {
            cGV.I.QuitProcess("Error::Button is null");
            return false;
        }

        cGV.I.sButton.cButtonComponent = null;
        cGV.I.sButton.cButtonComponent = new Button[cGV.MAX_BUTTON_NUM];
        if (cGV.I.sButton.cButtonComponent == null) {
            cGV.I.QuitProcess("Error::Button Component is null");
            return false;
        }

        for (index01 = 0; index01 < cGV.MAX_BUTTON_NUM; index01++) {
            cGV.I.sButton.cButtonGameObject[index01] = cGV.I.sButton.cButtonDir.transform.GetChild(index01).gameObject;//오브젝트 번호순으로 찾고
            cGV.I.sButton.cButtonComponent[index01] = cGV.I.sButton.cButtonGameObject[index01].transform.GetComponent<Button>();//오브젝트의 컴포넌트 찾고
            cGV.I.sButton.cButtonGameObject[index01].SetActive(false);//컨트롤 할땐 오브젝트로
        }

        //UI
        cGV.I.vUIButtonDirName = "UIButton";
        cGV.I.sUIButton.cUIButtonDir = null;
        cGV.I.sUIButton.cUIButtonDir = cGV.I.cCanvasGameObject.transform.Find(cGV.I.vUIButtonDirName).gameObject;
        if(cGV.I.sUIButton.cUIButtonDir == null) {
            cGV.I.QuitProcess("Error::UIButton Dir is null");
            return false;
        }

        cGV.I.sUIButton.cUIButtonGameObject = null;
        cGV.I.sUIButton.cUIButtonGameObject = new GameObject[cGV.MAX_UIBUTTON_NUM];
        if(cGV.I.sUIButton.cUIButtonGameObject == null) {
            cGV.I.QuitProcess("Error::UIButton GameObject is null");
            return false;
        }

        cGV.I.sUIButton.cUIButtonComponent = null;
        cGV.I.sUIButton.cUIButtonComponent = new Button[cGV.MAX_UIBUTTON_NUM];
        if(cGV.I.sUIButton.cUIButtonComponent == null) {
            cGV.I.QuitProcess("Error::UIButton Component is null");
            return false;
        }

        for (index01 = 0; index01 < cGV.MAX_UIBUTTON_NUM; index01++) {
            cGV.I.sUIButton.cUIButtonGameObject[index01] = cGV.I.sUIButton.cUIButtonDir.transform.GetChild(index01).gameObject;//오브젝트 번호순으로 찾고
            cGV.I.sUIButton.cUIButtonComponent[index01] = cGV.I.sUIButton.cUIButtonGameObject[index01].transform.GetComponent<Button>();//오브젝트의 컴포넌트 찾고
            cGV.I.sUIButton.cUIButtonGameObject[index01].SetActive(false);//컨트롤 할땐 오브젝트로
        }

        cGV.I.POINT = 0;

        cGV.I.vClippingObjectName = "ClippingObject";
        cGV.I.cClippingObject = GameObject.Find(cGV.I.vClippingObjectName);
        return true;
    }
    public bool Initialize_Character() {
        int index01, index02;
        string tString01;

        cGV.I.vClippingObjectName = null;
        cGV.I.vClippingObjectName = "ClippingObject";
        if (cGV.I.vClippingObjectName == null) {
            cGV.I.QuitProcess("Error::vClippingObjectName == null");
            return false;
        }
        cGV.I.cClippingObject = null;
        cGV.I.cClippingObject = GameObject.Find(cGV.I.vClippingObjectName);
        if (cGV.I.cClippingObject == null) {
            cGV.I.QuitProcess("Error::cClippingObject == null");
            return false;
        }

        cGV.I.vCharacterName = null;
        cGV.I.vCharacterName = new string[cGV.MAX_CHARACTER_NUM];
        cGV.I.vCharacterName[cGV.CHARACTER_MAN] = "Character";
        
        for (index01 = 0; index01 < cGV.MAX_CHARACTER_NUM; index01++) {
            if (cGV.I.vCharacterName[index01] == null) {
                cGV.I.QuitProcess("Error::CharacterName is null");
                return false;
            }
        }

        cGV.I.vAnimationName = null;
        cGV.I.vAnimationName = new string[cGV.MAX_ANIS_NUM];
        cGV.I.vAnimationName[cGV.ANIS_IDLE] = "Idle";
        cGV.I.vAnimationName[cGV.ANIS_RUN] = "Run";
        cGV.I.vAnimationName[cGV.ANIS_JUMP] = "Jump";
        cGV.I.vAnimationName[cGV.ANIS_FALL] = "Fall";
        cGV.I.vAnimationName[cGV.ANIS_HIT] = "Hit";
        cGV.I.vAnimationName[cGV.ANIS_DEATH] = "Death";
        for (index01 = 0; index01 < cGV.MAX_ANIS_NUM; index01++) {
            if (cGV.I.vAnimationName[index01] == null) {
                cGV.I.QuitProcess("Error::AnimationName is null");
                return false;
            }
        }
        cGV.I.sCharacter = null;
        cGV.I.sCharacter = new cGV.CHARACTER[cGV.MAX_CHARACTER_NUM];
        if (cGV.I.sCharacter == null) {
            cGV.I.QuitProcess("Error::Character Struct is null");
            return false;
        }
        for(index01 = 0; index01 < cGV.MAX_CHARACTER_NUM; index01++) {
            cGV.I.sCharacter[index01].cGameObject = null;
            cGV.I.sCharacter[index01].cGameObject = GameObject.Find(cGV.I.vCharacterName[index01]);
            if (cGV.I.sCharacter[index01].cGameObject == null) {
                cGV.I.QuitProcess("Error::Character GameObject is null");
                return false;
            }
            cGV.I.sCharacter[index01].cRigidBody = null;
            cGV.I.sCharacter[index01].cRigidBody = cGV.I.sCharacter[index01].cGameObject.GetComponent<Rigidbody2D>();
            cGV.I.sCharacter[index01].cRigidBody.freezeRotation = true;
            if (cGV.I.sCharacter[index01].cRigidBody == null) {
                cGV.I.QuitProcess("Error::Rigidbody is null");
                return false;
            }
            cGV.I.sCharacter[index01].cCollider = null;
            cGV.I.sCharacter[index01].cCollider = cGV.I.sCharacter[index01].cGameObject.GetComponent<BoxCollider2D>();
            if (cGV.I.sCharacter[index01].cCollider == null) {
                cGV.I.QuitProcess("Error::Collider is null"); 
                return false;
            }

            cGV.I.sCharacter[index01].cSpriteRenderer = null;
            cGV.I.sCharacter[index01].cSpriteRenderer = cGV.I.sCharacter[index01].cGameObject.GetComponent<SpriteRenderer>();
            if (cGV.I.sCharacter[index01].cSpriteRenderer == null) {
                cGV.I.QuitProcess("Error::SpriteRenderer is null");
                return false;
            }
            cGV.I.sCharacter[index01].cAnimator = null;
            cGV.I.sCharacter[index01].cAnimator = cGV.I.sCharacter[index01].cGameObject.GetComponent<Animator>();
            if (cGV.I.sCharacter[index01].cAnimator == null) {
                cGV.I.QuitProcess("Error::Animator is null");
                return false;
            }
            cGV.I.sCharacter[index01].vMessage = null;
            cGV.I.sCharacter[index01].vMessage = new int[cGV.MAX_MESSAGE_NUM, cGV.MAX_SUB_MESSAGE_SORT_NUM];
            if (cGV.I.sCharacter[index01].vMessage == null) {
                cGV.I.QuitProcess("Error::Character Message is null");
                return false;
            }
            cGV.I.sCharacter[index01].vAnimationHash = null;
            cGV.I.sCharacter[index01].vAnimationHash = new int[cGV.MAX_MESSAGE_NUM];
            if (cGV.I.sCharacter[index01].vAnimationHash == null) {
                return false;
            }
            for (index02 = 0; index02 < cGV.MAX_ANIS_NUM; index02++) {
                tString01 = string.Format("Base Layer.{0}", cGV.I.vAnimationName[index02]);
                cGV.I.sCharacter[index01].vAnimationHash[index02] = Animator.StringToHash(tString01);
            }
            cGV.I.sCharacter[index01].vDirection = 1;
            
            cGV.I.sCharacter[index01].vLifePoint = 10;
            cGV.I.sCharacter[index01].vRunSpeed = 300.0f;
            cGV.I.sCharacter[index01].vJumpSpeed = 250.0f;
            cGV.I.sCharacter[index01].vGravityScale = 40.0f;
            cGV.I.sCharacter[index01].vX = cGV.I.sCharacter[index01].cCollider.size.x / 2.0f;
            cGV.I.sCharacter[index01].vY = cGV.I.sCharacter[index01].cCollider.size.y / 2.0f;

            cGV.I.sCharacter[index01].cGameObject.SetActive(false);
        }
        return true;
    }
    public bool Initialize_Item() {
        int index01, index02;

        cGV.I.sITEM = null;
        cGV.I.sITEM = new cGV.ITEM[cGV.MAX_ITEM_NUM];
        cGV.I.vItemBomullName = "ItemBomull";
        cGV.I.vItemStoneName = "ItemStone";
        cGV.I.vItemHeartName = "ItemHeart";
        cGV.I.sITEM[cGV.ITEM_BOMULL].cItemGameObject = null;
        cGV.I.sITEM[cGV.ITEM_BOMULL].cItemGameObject = GameObject.Find(cGV.I.vItemBomullName);
        cGV.I.sITEM[cGV.ITEM_STONE].cItemGameObject = null;
        cGV.I.sITEM[cGV.ITEM_STONE].cItemGameObject = GameObject.Find(cGV.I.vItemStoneName);
        cGV.I.sITEM[cGV.ITEM_HEART].cItemGameObject = null;
        cGV.I.sITEM[cGV.ITEM_HEART].cItemGameObject = GameObject.Find(cGV.I.vItemHeartName);
        for (index01 = 0; index01 < cGV.MAX_ITEM_NUM; index01++) {
            cGV.I.sITEM[index01].cItemRigidBody = null;
            cGV.I.sITEM[index01].cItemRigidBody = cGV.I.sITEM[index01].cItemGameObject.GetComponent<Rigidbody2D>();

            cGV.I.sITEM[index01].cItemCollider = null;
            cGV.I.sITEM[index01].cItemCollider = cGV.I.sITEM[index01].cItemGameObject.GetComponent<BoxCollider2D>();
        }

        cGV.I.sItem = null;
        cGV.I.sItem = new cGV.ITEM[cGV.MAX_ITEM_NUM, cGV.MAX_ITEMS_NUM];

        for (index01 = 0; index01 < cGV.MAX_ITEM_NUM; index01++) {
            for (index02 = 0; index02 < cGV.MAX_ITEMS_NUM; index02++) {
                cGV.I.sItem[index01, index02].cItemGameObject = Instantiate(cGV.I.sITEM[index01].cItemGameObject, cGV.I.sITEM[index01].cItemGameObject.transform);
                cGV.I.sItem[index01, index02].cItemRigidBody = cGV.I.sItem[index01, index02].cItemGameObject.GetComponent<Rigidbody2D>();
                cGV.I.sItem[index01, index02].cItemCollider = cGV.I.sItem[index01, index02].cItemGameObject.GetComponent<BoxCollider2D>();
                cGV.I.sItem[index01, index02].vMessage = new int[cGV.MAX_MESSAGE_NUM, cGV.MAX_SUB_MESSAGE_SORT_NUM];
                cGV.I.sItem[index01, index02].vItemSpeed = 100.0f;
                cGV.I.sItem[index01, index02].vAttackPoint = 1;
                cGV.I.sItem[index01, index02].vPoint = 1;
                if(index01 == cGV.ITEM_STONE) {
                    cGV.I.sItem[index01, index02].vIsStone = true;
                }
                else {
                    cGV.I.sItem[index01, index02].vIsStone = false;
                }
            }
        }
            return true;
    }
    public bool Initialize_Main() {
        cGV.I.vApplicationState = cGV.APPS_MAIN;
        cGV.I.vCheckApplicationState[cGV.APPS_MAIN] = true;
        return true;
    }
    public void Destroy_Main() {
        cGV.I.vCheckApplicationState[cGV.APPS_MAIN] = false;
    }
    public bool Initialize_CharacterSelect() {
        cGV.I.vApplicationState = cGV.APPS_CHSL;
        cGV.I.vCheckApplicationState[cGV.APPS_CHSL] = true;
        return true;
    }
    public void Destroy_Character_Select() {
        cGV.I.vCheckApplicationState[cGV.APPS_CHSL] = false;
        cGV.I.POINT = 0;
    }
    public bool Initialize_Game() {
        cGV.I.vApplicationState = cGV.APPS_GAME;
        cGV.I.vCheckApplicationState[cGV.APPS_GAME] = true;
        cGV.I.sCharacter[cGV.I.vCharacterIndex].vLifePoint = 10;
        cGV.I.POINT = 0;
        
        return true;
    }
    public void Destroy_Game() {
        cGV.I.vCheckApplicationState[cGV.APPS_GAME] = false;
        
    }
    public bool Initialize_GameOver() {
        cGV.I.vApplicationState = cGV.APPS_GAOV;
        cGV.I.vCheckApplicationState[cGV.APPS_GAOV] = true;
        return true;
    }
    public void Destroy_GameOver() {
        cGV.I.vCheckApplicationState[cGV.APPS_GAOV] = false;
    }
    public bool Initialize_Pause() {
        cGV.I.vApplicationState = cGV.APPS_PAUS;
        cGV.I.vCheckApplicationState[cGV.APPS_PAUS] = true;
        return true;
    }
    public void Destroy_Pause() {
        cGV.I.vCheckApplicationState[cGV.APPS_PAUS] = false;
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
        Initialize_Item();
        Initialize_Character();
    }
}
