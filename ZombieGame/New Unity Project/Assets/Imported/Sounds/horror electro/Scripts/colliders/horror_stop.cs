using UnityEngine;
using System.Collections;

public class horror_stop : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Stop_Horror_onClick ();
	}
}
