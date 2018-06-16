using System.Collections;
using UnityEngine;

namespace S3
{
public class Player_DetectItem : MonoBehaviour {

    [Tooltip("What layer is being used for items.")]
    public LayerMask layerToDetect;
    [Tooltip("WHat transform will the ray be fired from.")]
    public Transform rayTransformPivot;
    [Tooltip("The editor input button that will be used for pickup.")]
    public string buttonPickup;


    private Transform itemAvailableForPickup;
    private RaycastHit hit;
    private float detectRange =5;
    private float detectRadius = 0.9f;
    private bool itemInRange;

    private float labelWidth=200;
    private float labelHeight=50;
    public int capacity = 2;


	void Update()
    { 
		CastRayForDetectingItems();
        CheckForItemPickupAttempt();
	}

    void CastRayForDetectingItems()
    {
            if(Physics.SphereCast(rayTransformPivot.position,detectRadius,rayTransformPivot.forward,out hit, detectRange, layerToDetect))
            {
                itemAvailableForPickup = hit.transform;
                itemInRange = true;
            }
            else
            {
                itemInRange = false;
            }
    }

    void CheckForItemPickupAttempt()
    {// Prevents double carry item and dissapearing
            if (Input.GetButtonDown(buttonPickup) && Time.timeScale > 0 && itemInRange && itemAvailableForPickup.root.tag != GameManager_References._playerTag && CheckInventorySize())
            {
                //Debug.Log("Pickup attempt");
                itemAvailableForPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
            }
    }

    bool CheckInventorySize()
    {
        int current = GetComponent<Player_Inventory>().objectCurrent;
        //int capacity = GetComponent<Player_Inventory>().objectCount;

        if (current < capacity) { return true; }

        return false;
    }

    void OnGUI()
    {
        if(itemInRange && itemAvailableForPickup != null)
            {
                GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableForPickup.name);
            }
    }
}
}