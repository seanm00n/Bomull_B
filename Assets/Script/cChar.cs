﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Text;
using System.Net.Sockets;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class cChar : MonoBehaviour {
    static private cChar getChar;
    static public cChar I {
        get {
            if (getChar == null)
                return null;
            return getChar;
        }
    }
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

    public const int ANIMATION_STATE_IDLE = 0;
    public const int ANIMATION_STATE_RUN = 1;
    public const int ANIMATION_STATE_JUMP = 2;
    public const int ANIMATION_STATE_FALL = 3;
    public const int ANIMATION_STATE_HIT = 4;
    public const int ANIMATION_STATE_DIE = 5;
    public const int MAX_ANIMATION_STATE_NUM = 6;
    public string[] vAnimationName;

    //public float VRunSpeed { get => vRunSpeed; set => vRunSpeed = value; } //get set 학습 필요

}
