using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Item_UI : MonoBehaviour
    {

        private Item_Master itemMaster;
        public GameObject myUI;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectPickup += EnableMyUI;
            itemMaster.EventObjectThrow += DisableMyUI;
        }

        void OnDisable()
        {
            itemMaster.EventObjectPickup -= EnableMyUI;
            itemMaster.EventObjectThrow -= DisableMyUI;
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
        }

        void EnableMyUI()
        {
            if(myUI != null)
            {
                myUI.SetActive(true);
            }
        }

        void DisableMyUI()
        {
            if (myUI != null)
            {
                myUI.SetActive(false);
            }
        }
    }
}
