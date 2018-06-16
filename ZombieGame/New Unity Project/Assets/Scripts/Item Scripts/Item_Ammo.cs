using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Item_Ammo : MonoBehaviour
    {
        private Item_Master itemMaster;
        private GameObject playerGo;
        public string ammoName;
        public int quantity;
        public bool isTriggerPickup;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventObjectPickup += TakeAmmo;

        }

        void OnDisable()
        {
            itemMaster.EventObjectPickup -= TakeAmmo;
        }

        void Start()
        {
            SetInitialReferences();
        }

        void OnTriggerEnter(Collider Other)
        {
            if(Other.CompareTag(GameManager_References._playerTag) && isTriggerPickup)
            {
                TakeAmmo();
            }
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
            playerGo = GameManager_References._player;

            if(isTriggerPickup)
            {
                if(GetComponent<Collider>() != null)
                {
                    GetComponent<Collider>().isTrigger = true;
                }

                if (GetComponent<Rigidbody>() != null)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        void TakeAmmo()
        {
            playerGo.GetComponent<Player_Master>().CallEventPickedUpAmmo(ammoName,quantity);
            Destroy(gameObject);        }

        void Update()
        {

        }
    }
}
