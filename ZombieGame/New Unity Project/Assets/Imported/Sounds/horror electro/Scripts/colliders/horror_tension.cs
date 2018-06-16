using UnityEngine;
using System.Collections;

public class horror_tension : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Tension_Basic_onClick ();
	}
}
