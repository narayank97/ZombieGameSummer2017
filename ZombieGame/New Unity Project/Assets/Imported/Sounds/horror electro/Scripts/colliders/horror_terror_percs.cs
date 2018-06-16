using UnityEngine;
using System.Collections;

public class horror_terror_percs : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Terror_Percs_onClick ();
	}
}
