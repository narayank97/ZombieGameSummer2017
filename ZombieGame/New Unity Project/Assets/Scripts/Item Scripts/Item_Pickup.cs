using System.Collections;
using UnityEngine;

namespace S3
{
    public class Item_Pickup : MonoBehaviour
    {

        private Item_Master itemMaster;
        private Transform myTransform;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventPickupAction += CarryOutPickupActions;
        }

        void OnDisable()
        {

        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
        }

        void CarryOutPickupActions(Transform tParent)
        {
            transform.SetParent(tParent);
            itemMaster.CallEventObjectPickup();
            transform.gameObject.SetActive(false);
        } 
    }
}
