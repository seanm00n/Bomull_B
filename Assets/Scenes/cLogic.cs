using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLogic : MonoBehaviour
{
    static private cLogic getLogic;
    static public cLogic I
    {
        get
        {
            if (getLogic == null)
                return null;
            return getLogic;
        }
    }
    public bool GameLogic()
    {
        Debug.Log("This is Game Logic");
/*        if (asdf)
        {
            cInit.I.Destroy_Game();
        }*/
        return true;
    }
}
