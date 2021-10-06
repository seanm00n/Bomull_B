using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItem : MonoBehaviour
{
    static private cItem getItem;
    static public cItem I {
        get {
            if (getItem == null)
                return null;
            return getItem;
        }
    }
    public struct ITEM {
        public GameObject cGameObject;
        public Rigidbody2D cRigidbody;
        public BoxCollider2D cCollider;
        public SpriteRenderer cSpriteRenderer;
        public int vPoint;
        public float vFallSpeed;
        public bool vIsTreasure;
        public float vX;
        public float vY;
    }
    public ITEM[] sItem;

    public const int ITEM_01 = 0;
    public const int ITEM_02 = 1;
    public const int ITEM_03 = 2;
    public const int ITEM_04 = 3;
    public const int MAX_ITEM_NUM = 4;
    public string[] vItemName;
}
