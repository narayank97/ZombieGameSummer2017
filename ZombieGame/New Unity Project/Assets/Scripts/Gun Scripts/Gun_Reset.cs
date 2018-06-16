using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_Reset : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private Item_Master itemMaster;


        void OnEnable()
        {
            SetInitialReferences();

            if(itemMaster != null)
            {
                itemMaster.EventObjectThrow += ResetGun;
            }
        }

        void OnDisable()
        {
            if (itemMaster != null)
            {
                itemMaster.EventObjectThrow -= ResetGun;
            }
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();

            if(GetComponent<Item_Master>() != null)
            {
                itemMaster = GetComponent<Item_Master>();
            }
        }

        void ResetGun()
        {
            gunMaster.CallEventRequestGunReset();
        }
    }

}

