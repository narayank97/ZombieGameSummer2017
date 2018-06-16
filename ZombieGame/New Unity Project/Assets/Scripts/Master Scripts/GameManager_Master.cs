using System.Collections;
using UnityEngine;

namespace S3
{
public class GameManager_Master : MonoBehaviour {

    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler MenuToggleEvent;
    public event GameManagerEventHandler InventoryUIToggleEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GoToMenuSceneEvent;
    public event GameManagerEventHandler GameOverEvent;

    public bool isGameOver;
    public bool isInventoryUIOn;
    public bool isMenuOn;

    public void CallEventMenuToggle()
    {
        if (MenuToggleEvent != null)
        {
                MenuToggleEvent();
        }

    }
     public void CallInventoryUIToggleEvent()
     {
         if (InventoryUIToggleEvent != null)
         {
               InventoryUIToggleEvent();
         }

    }
     public void CallRestartLevelEvent()
     {
          if (RestartLevelEvent != null)
          {
                RestartLevelEvent();
          }

     }

     public void CallGoToMenuSceneEvent()
     {
        if (GoToMenuSceneEvent != null)
        {
             GoToMenuSceneEvent();
        }

     }
    public void CallGameOverEvent()
    {
       if (GameOverEvent != null)
       {
            isGameOver = true;
            GameOverEvent();
       }

    }
}
}

