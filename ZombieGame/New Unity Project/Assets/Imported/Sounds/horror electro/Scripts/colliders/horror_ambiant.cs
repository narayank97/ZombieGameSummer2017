using UnityEngine;
using System.Collections;

public class horror_ambiant : MonoBehaviour {

	public Psycho_master horror_script;

	void OnTriggerEnter (Collider collider){
		horror_script.Ambiant_onClick ();
	}
}
