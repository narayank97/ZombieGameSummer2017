using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter1
{
public class WelcomeText : MonoBehaviour {
        public string myMessage = "Welcome to Zombie Game";
        public Text textWelcome;
        public GameObject canvasWelcome;

	// Use this for initialization
	void Start ()
    {
      SetInitalReferences();
      MyWelcomeMessage();
		
	}

    void SetInitalReferences()
    {
       textWelcome = GameObject.Find("Text").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void MyWelcomeMessage ()
    {
		if(textWelcome != null)
        {
            textWelcome.text = myMessage;
        }
        else
        {
            Debug.Log("Welcome text not assigned");
        }
            StartCoroutine(DisableCanvas(3.5f));
	}

    IEnumerator DisableCanvas(float waitTime)
    {
       yield return new WaitForSeconds(waitTime);
       canvasWelcome.SetActive(false);
    }
}
}

