using System.Collections;
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
    GameObject cGameObject;
    int vDirection;
    int vAnimationIndex;
    int vLifePoint;
    float vRunSpeed;
    float vJumpSpeed;
    //public float VRunSpeed { get => vRunSpeed; set => vRunSpeed = value; } //get set 학습 필요
    
}
