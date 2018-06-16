using System.Collections;
using UnityEngine;

namespace Chapter1
{
public class GameManager_EventMaster : MonoBehaviour {
    public delegate void GeneralEvent();
    public event GeneralEvent myGeneralEvent;
    
    public void CallMyGeneralEvent()
    {
     if(myGeneralEvent != null)
     {
        myGeneralEvent();
     }
    }
}
}

