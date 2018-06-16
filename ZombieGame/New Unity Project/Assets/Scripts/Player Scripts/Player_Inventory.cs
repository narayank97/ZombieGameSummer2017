using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// MUST GIVE ITEM TAG TO WORK


namespace S3
{
    public class Player_Inventory : MonoBehaviour {
    public Transform inventoryPlayerParent;
    public Transform inventoryUIParent;
    public GameObject uiButton;
    


    private Player_Master playerMaster;
    private GameManager_ToggleInventoryUI inventoryUIScript;
    private float timeToPlaceInHands = 0.1f;
    private Transform currentlyHeldItem;
    private int counter;
    private string buttonText;
    private List<Transform>listInventory = new List<Transform>();

    public int objectCount = 2;
    public int objectCurrent = 0;


    void OnEnable ()
    {
            SetInitialReferences();
            DeactivateAllInventoryItems();
            UpdateInventoryListAndUI();
            CheckIfHandsEmpty();
            
            playerMaster.EventInventoryChanged += UpdateInventoryListAndUI;
            playerMaster.EventInventoryChanged += CheckIfHandsEmpty;
            playerMaster.EventHandsEmpty += ClearHands;
            
    }

    void OnDisable ()
    {
            playerMaster.EventInventoryChanged -= UpdateInventoryListAndUI;
            playerMaster.EventInventoryChanged -= CheckIfHandsEmpty;
            playerMaster.EventHandsEmpty -= ClearHands;
    }

    void SetInitialReferences()
    {
            inventoryUIScript = GameObject.Find("Game Manager").GetComponent<GameManager_ToggleInventoryUI>();
            playerMaster = GetComponent<Player_Master>();
    }
    
    void Update()
    {
            int previosSelectedWeapon = objectCurrent;
            
            if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if(objectCurrent >= (objectCount -1))
                {
                    objectCurrent = 0;
                }
                else
                {
                    objectCurrent++;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (objectCurrent <= 0)
                {
                    objectCurrent = objectCount - 1;
                }
                else
                {
                    objectCurrent--;
                }
            }
            if(previosSelectedWeapon != objectCurrent)
            {
                ActivateInventoryItem(objectCurrent);
            }

        }

    void UpdateInventoryListAndUI()
    {
            
            counter = 0;
            listInventory.Clear();
            listInventory.TrimExcess();

            ClearInventoryUI();

            foreach(Transform child in inventoryPlayerParent)
            {
                if (child.CompareTag("Item"))
                {
                    listInventory.Add(child);
                    GameObject go = Instantiate(uiButton) as GameObject;
                    buttonText = child.name;
                    go.GetComponentInChildren<Text>().text = buttonText;
                    int index = counter;
                    go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                    go.GetComponent<Button>().onClick.AddListener(inventoryUIScript.ToggleInventoryUI);
                    go.transform.SetParent(inventoryUIParent, false);
                    counter++;
                    objectCurrent = counter;

                }
            }
    }

    void CheckIfHandsEmpty()
    {
        if(currentlyHeldItem == null && listInventory.Count > 0)
            {
                StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count - 1]));
            }
    }

    void ClearHands()
    {
            currentlyHeldItem = null;
    }

    void ClearInventoryUI()
    {
        foreach(Transform child in inventoryUIParent)
            {
                Destroy(child.gameObject);
            }
    }

    public void ActivateInventoryItem(int inventoryIndex)
    {
            DeactivateAllInventoryItems();
            StartCoroutine(PlaceItemInHands(listInventory[inventoryIndex]));
    }
    
    void DeactivateAllInventoryItems()
    {
            foreach (Transform child in inventoryPlayerParent)
            {
                if (child.CompareTag("Item"))
                {
                    child.gameObject.SetActive(false);
                }
            }
    }

    IEnumerator PlaceItemInHands(Transform itemTransform)
    {
            yield return new WaitForSeconds(timeToPlaceInHands);
            currentlyHeldItem = itemTransform;
            currentlyHeldItem.gameObject.SetActive(true);
    }

    public Transform GetCurrentItem(Transform temp)
        {
            temp = currentlyHeldItem;
            return temp;
        }
}

}
