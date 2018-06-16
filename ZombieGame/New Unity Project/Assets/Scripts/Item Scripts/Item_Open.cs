using System.Collections;
using UnityEngine;

namespace S3
{
    public class Item_Open : MonoBehaviour
    {
        private Item_Master itemMaster;
        private Animator myAnimator;

        void OnEnable()
        {
            SetInitialReferences();
            itemMaster.EventPlayerInput += PlayOpenAnimation;
        }

        void OnDisable()
        {
            //itemMaster.EventPlayerInput -= PlayOpenAnimation;
        }

        void SetInitialReferences()
        {
            itemMaster = GetComponent<Item_Master>();
            if (GetComponent<Animator>() != null)
            {
                myAnimator = GetComponent<Animator>();
            }
        }

        void PlayOpenAnimation()
        {
            if (myAnimator != null)
            {
                myAnimator.SetTrigger("Open");
            }
        }
    }

}

