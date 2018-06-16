using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Item_SetPosition : MonoBehaviour
    {
        private Item_Master itemMaster;
        public Vector3 itemLocalPosition;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectPickup += SetPositionOnPlayer;
        }

        void Start()
        {
            SetPositionOnPlayer();
        }

        void OnDisable()
        {
            itemMaster.EventObjectPickup -= SetPositionOnPlayer;
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
        }

        void SetPositionOnPlayer()
        {
            if(transform.root.CompareTag(GameManager_References._playerTag))
            {
                transform.localPosition = itemLocalPosition;
            }
        }
    }
}
