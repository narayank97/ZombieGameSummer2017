using UnityEngine;
using System.Collections;

public class code_snippet_script : MonoBehaviour {

	// Use this for initialization
	public Psycho_master psycho_script;
	private GameObject enemy_gameobject;
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;   

	void Start () {
	


	}
	
	// Update is called once per frame
	void Spawn_Enemies() {
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		//enemy_gameobject = (GameObject)Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

		//Gives a unique name to each spawned enemy 
		enemy_gameobject.name = enemy.name + psycho_script.enemy_number;
		
		//Uses an incremental int to give numbers to enemies spawned ranging from 0 to 4
		psycho_script.enemy_number = psycho_script.enemy_number + 1;
		if (psycho_script.enemy_number == 4) {
			psycho_script.enemy_number = 0;
		}
		



	}
}
