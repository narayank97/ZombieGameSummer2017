using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_StandardInput : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private float nextAttack;
        public float attackRate = 0.2f;
        private Transform myTransform;
        public bool isAutomatic;
        public bool hasBurstFire;
        private bool isBurstFireActive;
        public string attackButtonName;
        public string reloadButtonName;
        public string burstFireButtonName;
        private Transform gunUsing;

        void Start()
        {
            SetInitialReferences();
        }

        void Update()
        {
            CheckifWeaponShouldAttack();
            CheckForReloadRequest();
            CheckForBurstFireToggle();
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            myTransform = transform;
            gunMaster.isGunLoaded = true;
        }

        void CheckifWeaponShouldAttack()
        {
            if(Time.time > nextAttack && Time.timeScale>0 &&
                myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                if((isAutomatic && !isBurstFireActive))
                {
                    if(Input.GetButton(attackButtonName))
                    {
                        AttemptAttack();
                    }
                }
            
              else if(isAutomatic && isBurstFireActive)
              {
                if(Input.GetButtonDown(attackButtonName))
                {
                        StartCoroutine(RunBurstFire());
                }
              }

              else if(!isAutomatic)
              {
                if(Input.GetButtonDown(attackButtonName))
                {
                     AttemptAttack();
                }
              }
            }
        }

        void AttemptAttack()
        {
            nextAttack = Time.time + attackRate;

            if(gunMaster.isGunLoaded)
            {
                gunMaster.CallEventPlayerInput();
            }

            else
            {
                gunMaster.CallEventGunNotUsuable();
            }
        }

        void CheckForReloadRequest()
        {
            if(Input.GetButtonDown(reloadButtonName)&&Time.timeScale>0&&
                myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                gunMaster.CallEventRequestReload();
            }
        }

        void CheckForBurstFireToggle()
        {
            if (Input.GetButtonDown(burstFireButtonName) && Time.timeScale > 0 &&
                myTransform.root.CompareTag(GameManager_References._playerTag))
            {
                isBurstFireActive = !isBurstFireActive;
                gunMaster.CallEventToggleBurstFire();
            }
        }


        IEnumerator RunBurstFire()
        {
            AttemptAttack();
            yield return new WaitForSeconds(attackRate);
            AttemptAttack();
            yield return new WaitForSeconds(attackRate);
            AttemptAttack();
        }



    }

}
