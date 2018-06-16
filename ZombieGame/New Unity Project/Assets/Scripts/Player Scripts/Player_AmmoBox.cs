using System.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace S3
{
    public class Player_AmmoBox : MonoBehaviour {

        private Player_Master playerMaster;

        // A new class must have the serialize in order to see publics on the inspector
        [System.Serializable]
        public class AmmoTypes
        {
            public string ammoName;
            public int ammoCurrentCarried;
            public int ammoMaxQuantity;

            public AmmoTypes(string aName, int aMaxQuantity, int aCurrentCarried)
            {
                ammoName = aName;
                ammoCurrentCarried = aCurrentCarried;
                ammoMaxQuantity = aMaxQuantity;
            }
        }

        public List<AmmoTypes> typesOfAmmunition = new List<AmmoTypes>();

        void OnEnable()
        {
            SetInitialReferences();
            playerMaster.EventPickedUpAmmo += PickedUpAmmo;
        }

        void OnDisable()
        {
            playerMaster.EventPickedUpAmmo -= PickedUpAmmo;
        }

        void SetInitialReferences()
        {
            playerMaster = GetComponent<Player_Master>();
        }

        public void PickedUpAmmo(string ammoName, int quantity)
        {
            for(int i=0; i < typesOfAmmunition.Count; i++)
            {
                if(typesOfAmmunition[i].ammoName == ammoName)
                {
                    typesOfAmmunition[i].ammoCurrentCarried += quantity;

                    if(typesOfAmmunition[i].ammoCurrentCarried > typesOfAmmunition[i].ammoMaxQuantity)
                    {
                        typesOfAmmunition[i].ammoCurrentCarried = typesOfAmmunition[i].ammoMaxQuantity;
                    }

                    playerMaster.CallEventAmmoChanged();

                    break;
                }
            }
        }

        public int AmmoQuantity()
        {
            int number = GetComponent<AmmoTypes>().ammoMaxQuantity;
           return number;
        }

 }             
}

