using System.Collections;
using UnityEngine;

namespace Chapter1
{
  public class WalkThroughWalls : MonoBehaviour
  {
        private GameManager_EventMaster eventMasterScript;
        private Color myColor = new Color(1, 0, 0, 1);
        
     void OnEnable()
     {
            SetInitalReferences();
            eventMasterScript.myGeneralEvent += SetLayerToNotSolid;

     }

     void OnDisable()
     {
            eventMasterScript.myGeneralEvent -= SetLayerToNotSolid;

        }

        void SetLayerToNotSolid()
      {
            gameObject.layer = LayerMask.NameToLayer("Not Solid");
            GetComponent<Renderer>().material.color = myColor;
      }

        void SetInitalReferences()
        {
            eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
        }
  }
}

