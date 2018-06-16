using System.Collections;
using UnityEngine;

namespace S3
{
public class GameManager_ToggleInventoryUI : MonoBehaviour {

        [Tooltip("Does this gamemode have an inventory? 1=yes,0=no")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameMangagerMaster;

	// Use this for initialization
	void Start ()
    {
            SetInitialReferences();	
	}
	
	// Update is called once per frame
	void Update () {
            CheckForInventoryUIToggleRequest();
	}
    
    void SetInitialReferences()
        {
            gameMangagerMaster = GetComponent<GameManager_Master>();
            if(toggleInventoryButton == "")
            {
                Debug.LogWarning("Type in the name of the button to toggle inventory");
                this.enabled = false;
            }
        }

    void CheckForInventoryUIToggleRequest()
        {
            if (Input.GetButtonUp(toggleInventoryButton) && !gameMangagerMaster.isMenuOn && !gameMangagerMaster.isGameOver && hasInventory)
            {
                ToggleInventoryUI();
            }
        }

    public void ToggleInventoryUI()
    {
            if(inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameMangagerMaster.isInventoryUIOn = !gameMangagerMaster.isInventoryUIOn;
                gameMangagerMaster.CallInventoryUIToggleEvent();
            }
        }
}

}
