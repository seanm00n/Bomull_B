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

    public void QuitProcess(string tstring) {
        #if UNITY_EDITOR
        Debug.LogError(tstring);
        EditorApplication.ExecuteMenuItem("Edit/Play");
        #else
        Application.Quit();
        #endif
    }

    public void SetAnimation(int tAnimationIndex, ref cChar tCharacter) {
        //애니메이션 상태 변경
        //애니메이션 번호와 변경할 캐릭터를 넘김
    }
    public void SetDirection(int tDirection, ref cChar tCharacter) {
        //방향 번경
        //변경할 캐릭터와 방향을 넘김
    }

}
