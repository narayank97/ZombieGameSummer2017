using System.Collections;
using UnityEngine;

namespace Chapter1
{
public class Spawner : MonoBehaviour {
        public int numberOfEnemies;
        public GameObject objectToSpawn;
        private float spawnRadius = 5;
        private Vector3 spawnPosition;
        private GameManager_EventMaster eventMasterScript;

        void OnEnable()
        {
            SetInitialRefences();
            eventMasterScript.myGeneralEvent += SpawnObject;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SpawnObject;
        }

        void SetInitialRefences()
        {
            eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
        }


    void SpawnObject()
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
}

