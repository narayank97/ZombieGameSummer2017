using UnityEngine;
using System.Collections;

public class horror_hits : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Hits_onClick ();
	}
}
