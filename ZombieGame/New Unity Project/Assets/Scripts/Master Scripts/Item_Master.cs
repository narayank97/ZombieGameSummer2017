using System.Collections;
using UnityEngine;

namespace S3
{
    public class Item_Master : MonoBehaviour
    {
        private Player_Master playerMaster;
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventObjectThrow;
        public event GeneralEventHandler EventObjectPickup;
        public event GeneralEventHandler EventPlayerInput;

        public delegate void PickupActionEventHandler(Transform item);
        public event PickupActionEventHandler EventPickupAction;


        void Start()
        {
            SetIntialReferences();
        }

        public void CallEventPlayerInput()
        {
            if (EventPlayerInput != null)
            {
                EventPlayerInput();
            }
        }

        public void CallEventObjectThrow()
        {
            if (EventObjectThrow != null)
            {
                EventObjectThrow();   
            }

            playerMaster.CallEventHandsEmpty();
            playerMaster.CallEventInventoryChanged();
        }

        public void CallEventObjectPickup()
        {
            if(EventObjectPickup != null)
            {
                EventObjectPickup();
                
            }
            playerMaster.CallEventInventoryChanged();
        }

        public void CallEventPickupAction(Transform item)
        {
            if(EventPickupAction != null)
            {
                EventPickupAction(item);
            }
        }

        void SetIntialReferences()
        {
            if(GameManager_References._player != null)
            {
                playerMaster = GameManager_References._player.GetComponent<Player_Master>();
            }
        }
    }
}
