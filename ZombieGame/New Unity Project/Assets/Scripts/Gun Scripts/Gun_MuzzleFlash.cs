using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_MuzzleFlash : MonoBehaviour
    {
        public ParticleSystem muzzleFlash;
        private Gun_Master gunMaster;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += ActivateMuzzleFlash;
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= ActivateMuzzleFlash;

        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void ActivateMuzzleFlash()
        {
            if(muzzleFlash != null)
            {
                muzzleFlash.Play();
            }
        }
    }

}

