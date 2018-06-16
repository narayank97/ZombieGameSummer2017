using UnityEngine;
using System.Collections;

public class horror_tension_synth : MonoBehaviour {

	public Psycho_master horror_script;
	
	void OnTriggerEnter (Collider collider){
		horror_script.Tension_Synth_onClick ();
	}
}
