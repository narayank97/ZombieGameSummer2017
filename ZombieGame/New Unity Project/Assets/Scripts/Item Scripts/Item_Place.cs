using System.Collections;
using UnityEngine;
namespace S3
{
    public class Item_Place : MonoBehaviour
    {
        private float num;
        public GameObject gun0;
        public GameObject gun1;
        public GameObject gun2;
        public GameObject gun3;
        public GameObject gun4;
        public GameObject gun5;
        private GameObject objectToSpawn;


        private Item_Master itemMaster;
        private Player_Master playerMaster;

        public Transform playerReference;
        public Vector3 itemLocalPosition;

        void OnEnable()
        {
            SetInitialReferences();
            //itemMaster.EventPlayerInput += SpawnObject;
        }

        void OnDisable()
        {
            //itemMaster.EventPlayerInput -= SpawnObject;
        }

        void SetInitialReferences()
        {
            playerMaster = GetComponent<Player_Master>();
            itemMaster = GetComponent<Item_Master>();
            num = ((playerReference.GetComponent<Player_Points>().playerPoints) + Time.unscaledTime) % 101;

            if (num < 20 && num >= 0)
            {
                objectToSpawn = gun0;
            }

            else if (num < 40 && num >= 20)
            {
                objectToSpawn = gun1;
            }

            else if (num < 60 && num >= 40)
            {
                objectToSpawn = gun2;
            }

            else if (num < 80 && num >= 60)
            {
                objectToSpawn = gun3;
            }

            else if (num < 50 && num >= 80)
            {
                objectToSpawn = gun4;
            }

            else if (num <= 100 && num >= 95)
            {
                objectToSpawn = gun5;
            }
        }


        void SpawnObject()
        {
            SetInitialReferences();
            Instantiate(objectToSpawn, itemLocalPosition, Quaternion.Euler(-90, 0, 0));
        }
    }
}