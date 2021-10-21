using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net.Sockets;
using System.Text;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

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
        public Rigidbody2D cRigidbody;
        public BoxCollider2D cCollider; //cCC, cInit.Initialize_Character() 수정
        public SpriteRenderer cSpriteRenderer;
        public Animator cAnimator;
        public int vDirection;
        public int vAnimationIndex;
        public int vLifePoint;
        public float vRunSpeed;
        public float vJumpSpeed;
        public float vX;
        public float vY;
    }
    public CHARACTER[] sCharacter;

    public const int CHARACTER_MAN = 0;
    public const int MAX_CHARACTER_NUM = 1;
    public string[] vCharacterName;
    public int vCharacterIndex;

    public const int ANIMATION_STATE_IDLE = 0;
    public const int ANIMATION_STATE_RUN = 1;
    public const int ANIMATION_STATE_JUMP = 2;
    public const int ANIMATION_STATE_FALL = 3;
    public const int ANIMATION_STATE_HIT = 4;
    public const int ANIMATION_STATE_DIE = 5;
    public const int MAX_ANIMATION_STATE_NUM = 6;
    public string[] vAnimationName;

    public void QuitProcess(string tstring) {
        #if UNITY_EDITOR
        Debug.LogError(tstring);
        EditorApplication.ExecuteMenuItem("Edit/Play");
        #else
        Application.Quit();
        #endif
    }

    public void SetAnimation(int tAnimationIndex, ref cGV tCharacter) {
        //애니메이션 상태 변경
        //애니메이션 번호와 변경할 캐릭터를 넘김
    }
    public void SetDirection(int tDirection, ref cGV tCharacter) {
        //방향 번경
        //변경할 캐릭터와 방향을 넘김
    }

}
