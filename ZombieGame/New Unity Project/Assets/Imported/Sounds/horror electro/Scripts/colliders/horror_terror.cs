using UnityEngine;
using System.Collections;

public class horror_terror : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Terror_Basic_onClick ();
	}
}

