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
    public void QuitProcess(string tstring) {
        #if UNITY_EDITOR
        Debug.LogError(tstring);
        EditorApplication.ExecuteMenuItem("Edit/Play");
        #else
        Application.Quit();
        #endif
    }

    public void SetAnimation(int tAnimationIndex, ref cChar tCharacter) {

    }

}
