using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_ShootAnimator : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private Animator myAnimator;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += PlayShootAnimation;
        }

        void OnDisable()
        {

            gunMaster.EventPlayerInput -= PlayShootAnimation;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            if(GetComponent<Animator>() != null)
            {
                myAnimator = GetComponent<Animator>();
            }
        }

        void PlayShootAnimation()
        {
            if(myAnimator != null)
            {
                myAnimator.SetTrigger("Shoot");
            }
        }
    }

}

