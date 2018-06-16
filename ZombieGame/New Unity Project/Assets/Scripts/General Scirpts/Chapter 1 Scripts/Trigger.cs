using System.Collections;
using UnityEngine;


// Use only for small rigid bodies

namespace Chapter1
{
 public class Trigger : MonoBehaviour
 {
        private GameManager_EventMaster eventMasterScript;

        void Start()
        {
            SetInitialRefrences();
        }

        void OnTriggerEnter(Collider other)
        {
            eventMasterScript.CallMyGeneralEvent();
            Destroy(gameObject);
        }


        void SetInitialRefrences()
        {
            if (GameObject.Find("Wall") != null)
            {
                eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
            }
        }
    }
}

