using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cChar : MonoBehaviour {
    GameObject cGameObject;
    int vDirection;
    int vAnimationIndex;
    int vLifePoint;
    float vRunSpeed;
    float vJumpSpeed;

    public float VRunSpeed { get => vRunSpeed; set => vRunSpeed = value; }
}
