using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
public class TestGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.O))
        {
                GetComponent<GameManager_Master>().CallGameOverEvent();
        }
	}
}

}
