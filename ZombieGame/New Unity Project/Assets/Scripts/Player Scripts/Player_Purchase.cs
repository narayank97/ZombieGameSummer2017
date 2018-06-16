using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S3
{
    public class Player_Purchase : MonoBehaviour
    {
        private Player_Master playerMaster;
        private Item_Master itemMaster;
        private Gun_Master gunMaster;
        private Player_AmmoBox ammoBox;

        [Tooltip("What layer is being used for items.")]
        public LayerMask layerToDetect;
        [Tooltip("What transform will the ray be fired from.")]
        public Transform rayTransformPivot;
        public Transform playerReference;
        [Tooltip("The editor input button that will be used for pickup.")]
        public string buttonSpend;

        private Transform itemAvailableForPurchase;
        private Transform temp;
        private RaycastHit hit;
        private Animator myAnimator;
        private Animation myAnimation;
        private float detectRange = 5;
        private float detectRadius = 0.9f;
        private bool itemInRange;

        private float labelWidth = 200;
        private float labelHeight = 50;
        private int itemPoints = 100;
        private int playerPoints = 0;
        private bool extendMgs = false;
        private bool packedPunch = false;


        void Start()
        {
            SetInitialReferences();    
            
        }
        void Update()
        {
            CastRayForDetectingItems();
            CheckForItemPickupAttempt();
        }


        void CastRayForDetectingItems()
        {
            if (Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
            {
                itemAvailableForPurchase = hit.transform;
                itemInRange = true;
            }
            else
            {
                itemInRange = false;
            }
        }



        void CheckForItemPickupAttempt()
        {
            if (Input.GetButtonDown(buttonSpend) && itemInRange && itemAvailableForPurchase.root.tag != GameManager_References._playerTag)
            {
                itemPoints = itemAvailableForPurchase.GetComponent<Item_Cost>().itemCost;
                playerPoints = playerReference.GetComponent<Player_Points>().playerPoints;
                if(playerPoints-itemPoints >= 0)
                {
                    playerMaster.CallEventPlayerSpendsPoints(itemPoints);    // List of different products for the player
                    if (itemPoints >= 1000 && itemPoints < 5000)
                    {
                        PurchaseGate();                                         // GATE TO BUY
                    }

                    else if(itemPoints == 10000)                                // GUN UPGRADES
                    {
                        if(itemAvailableForPurchase.name == "Packin A Punch")
                        {
                            UpgradeDamage(temp);
                        }
                        else if(itemAvailableForPurchase.name == "Xtend Mags")
                        {
                            ExtendMagazines(temp);
                        }
                        else if(itemAvailableForPurchase.name == "Donkey Kick")
                        {
                            AddInventory();
                        }
                        else if(itemAvailableForPurchase.name == "Fast Revive")
                        {
                            IncreaseHealth();
                        }

                        CheckIfUpgraded(temp);
                    }

                    else if(itemPoints == 500)
                    {
                        PurchaseAmmunition();                                   // AMMUNITION
                    }

                    else if(itemPoints == 5000)
                    {
                        OpenCabinet(itemPoints);                                // GUNS IN A CABINET
                    }
                }

            }
        }

        // GATES  & SPAWNERS//

        void PurchaseGate() //                                                              GATE PURCHASE
        {
            GetComponent<Spawn_Activate>().ReduceChildren(itemAvailableForPurchase.name);
            itemAvailableForPurchase.gameObject.SetActive(false);
            Destroy(itemAvailableForPurchase.gameObject);

            if (GetComponent<Spawn_Activate>().Zone1_5Active())
            {
                GameObject Spawner_2 = GameObject.Find("Spawner_2");
                Transform SpawnerTransform_2 = Spawner_2.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_2);

                GameObject Spawner_13 = GameObject.Find("Spawner_13");
                Transform SpawnerTransform_13 = Spawner_13.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_13);

                GameObject Spawner_14 = GameObject.Find("Spawner_14");
                Transform SpawnerTransform_14 = Spawner_14.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_14);
            }

            if (GetComponent<Spawn_Activate>().Zone1_7Active())
            {
                GameObject Spawner_10 = GameObject.Find("Spawner_10");
                Transform SpawnerTransform_10 = Spawner_10.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_10);

                GameObject Spawner_11 = GameObject.Find("Spawner_11");
                Transform SpawnerTransform_11 = Spawner_11.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_11);
            }

            if (GetComponent<Spawn_Activate>().Zone1_2Active())
            {
                GameObject Spawner_15 = GameObject.Find("Spawner_15");
                Transform SpawnerTransform_15 = Spawner_15.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_15);
            }

            if (GetComponent<Spawn_Activate>().Zone2_4Active())
            {
                GameObject Spawner_15 = GameObject.Find("Spawner_15");
                Transform SpawnerTransform_15 = Spawner_15.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_15);
            }

            if (GetComponent<Spawn_Activate>().Zone3_5Active())
            {

                GameObject Spawner_8 = GameObject.Find("Spawner_8");
                Transform SpawnerTransform_8 = Spawner_8.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_8);

                GameObject Spawner_9 = GameObject.Find("Spawner_9");
                Transform SpawnerTransform_9 = Spawner_9.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_9);
            }

            if (GetComponent<Spawn_Activate>().Zone3_7Active())
            {
                GameObject Spawner_8 = GameObject.Find("Spawner_8");
                Transform SpawnerTransform_8 = Spawner_8.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_8);

                GameObject Spawner_9 = GameObject.Find("Spawner_9");
                Transform SpawnerTransform_9 = Spawner_9.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_9);
            }

            if (GetComponent<Spawn_Activate>().Zone4_5Active())
            {
                GameObject Spawner_12 = GameObject.Find("Spawner_12");
                Transform SpawnerTransform_12 = Spawner_12.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_12);

                GameObject Spawner_4 = GameObject.Find("Spawner_4");
                Transform SpawnerTransform_4 = Spawner_4.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_4);

                GameObject Spawner_7 = GameObject.Find("Spawner_7");
                Transform SpawnerTransform_7 = Spawner_7.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_7);
            }

            if (GetComponent<Spawn_Activate>().Zone5_6Active())
            {
                GameObject Spawner_3 = GameObject.Find("Spawner_3");
                Transform SpawnerTransform_3 = Spawner_3.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_3);

                GameObject Spawner_5 = GameObject.Find("Spawner_5");
                Transform SpawnerTransform_5 = Spawner_5.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_5);

                GameObject Spawner_6 = GameObject.Find("Spawner_6");
                Transform SpawnerTransform_6 = Spawner_6.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_6);
            }

            if (GetComponent<Spawn_Activate>().Zone5_7Active())
            {
                GameObject Spawner_10 = GameObject.Find("Spawner_10");
                Transform SpawnerTransform_10 = Spawner_10.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_10);

                GameObject Spawner_11 = GameObject.Find("Spawner_11");
                Transform SpawnerTransform_11 = Spawner_11.transform;
                Spawn_ScriptV2.spawnPoints.Add(SpawnerTransform_11);
            }
        }

                    // CABINETS //

        void OpenCabinet(int points)                 //                       OPEN  CABINET
        {
            myAnimator = itemAvailableForPurchase.GetComponent<Animator>();
            myAnimator.SetTrigger("Open");
           
        }


                    // GUNS //
        void CheckIfUpgraded(Transform temp)            //                          IS GUN ALREADY UPGRADED
        {
            Transform item = GetComponent<Player_Inventory>().GetCurrentItem(temp);
            extendMgs = item.GetComponent<Gun_Ammo>().isEMUpgraded;
            packedPunch = item.GetComponent<Gun_Ammo>().isPPUpgraded;
            if(extendMgs && packedPunch)
            { 
                item.GetChild(3).GetChild(1).GetComponent<Renderer>().material.color = new Color(117, 3, 212);
            }
        }
            
        void UpgradeDamage(Transform temp)          //                          UPGRADE DAMAGE
        {
            Debug.Log("Accessed the upgrade");
            Transform item = GetComponent<Player_Inventory>().GetCurrentItem(temp);
            packedPunch = item.GetComponent<Gun_Ammo>().isPPUpgraded;
            if (!packedPunch)
            {
                item.GetComponent<Gun_ApplyDamage>().damage += 15;
                item.GetComponent<Gun_Ammo>().currentAmmo = item.GetComponent<Gun_Ammo>().clipSize;
                item.GetComponent<Gun_Ammo>().isPPUpgraded = true;
                item.GetChild(3).GetChild(1).GetComponent<Renderer>().material.color = new Color(0,299,200);
            }

            else
            {
                playerMaster.CallEventPlayerEarnsPoints(10000);
            }
            
        }

        void IncreaseHealth()       //                                  PLAYER INCREASE HEALTH
        {
            while(GetComponent<Player_Health>().playerHealth < 100)
            {
                GetComponent<Player_Master>().CallEventPlayerHealthIncrease(1);
            }
            
        }


        void AddInventory()                                         // INCREASE INVENTORY SIZE
        {
            GetComponent<Player_DetectItem>().capacity++;
        }

        void ExtendMagazines(Transform temp)                            //  MAKE MAGAZINES LARGER
        {
            Transform item = GetComponent<Player_Inventory>().GetCurrentItem(temp);
            extendMgs = item.GetComponent<Gun_Ammo>().isEMUpgraded;
            if (!extendMgs)
            {
                item.GetComponent<Gun_Ammo>().clipSize += 15;
                item.GetComponent<Gun_Ammo>().currentAmmo = item.GetComponent<Gun_Ammo>().clipSize;
                item.GetComponent<Gun_Ammo>().isEMUpgraded = true;
                item.GetChild(3).GetChild(1).GetComponent<Renderer>().material.color = new Color(93, 2, 2);
            }

            else
            {
                playerMaster.CallEventPlayerEarnsPoints(10000);
            }

        }
   

        void PurchaseAmmunition()                               //                  BUY AMMUNITION
        {
            string ammoName = itemAvailableForPurchase.GetComponent<Item_Name>().name;


            if (ammoName == "Assault Rifle Ammunition")
            {
                playerMaster.GetComponent<Player_AmmoBox>().PickedUpAmmo("AR", 300-ammoBox.typesOfAmmunition[0].ammoCurrentCarried);
                gunMaster.CallEventAmmoChanged(ammoBox.typesOfAmmunition[0].ammoCurrentCarried, ammoBox.typesOfAmmunition[0].ammoMaxQuantity);

                if (GetComponent<Player_AmmoBox>().typesOfAmmunition[0].ammoMaxQuantity >= 300)
                {
                    playerMaster.CallEventPlayerEarnsPoints(500);
                    return;
                }

            }

            else if (ammoName == "Submachine Gun Ammunition")
            {
                playerMaster.GetComponent<Player_AmmoBox>().PickedUpAmmo("SMG", 300 - ammoBox.typesOfAmmunition[1].ammoCurrentCarried);
                gunMaster.CallEventAmmoChanged(ammoBox.typesOfAmmunition[1].ammoCurrentCarried, ammoBox.typesOfAmmunition[1].ammoMaxQuantity);
                if (GetComponent<Player_AmmoBox>().typesOfAmmunition[1].ammoMaxQuantity >= 300)
                {
                    playerMaster.CallEventPlayerEarnsPoints(500);
                    return;
                }
            }

            else if (ammoName == "Sniper Rifle Ammunition")
            {
                playerMaster.GetComponent<Player_AmmoBox>().PickedUpAmmo("Sniper", 60 - ammoBox.typesOfAmmunition[2].ammoCurrentCarried);
                gunMaster.CallEventAmmoChanged(ammoBox.typesOfAmmunition[2].ammoCurrentCarried, ammoBox.typesOfAmmunition[2].ammoMaxQuantity);
                if (GetComponent<Player_AmmoBox>().typesOfAmmunition[2].ammoMaxQuantity >= 60)
                {
                    playerMaster.CallEventPlayerEarnsPoints(500);
                    return;
                }
            }
        }


              // PLAYER VIEW // 

        void OnGUI()
        {
            if (itemInRange && itemAvailableForPurchase != null)
            {
                GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableForPurchase.name + "\n" + itemAvailableForPurchase.GetComponent<Item_Cost>().itemCost + " points" );
            }
        }



                 // SETUP//

        void SetInitialReferences()
        {
            playerMaster = GetComponent<Player_Master>();
            itemMaster = GetComponent<Item_Master>();
            gunMaster = GetComponent<Gun_Master>();
            ammoBox = GameManager_References._player.GetComponent<Player_AmmoBox>();
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








