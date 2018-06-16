using UnityEngine;
using System.Collections;

public class horror_terror_bass : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Terror_Bass_onClick ();
	}
}
