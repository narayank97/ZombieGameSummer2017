using UnityEngine;
using System.Collections;

public class horror_terror_intense : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Terror_Intense_onClick ();
	}
}
