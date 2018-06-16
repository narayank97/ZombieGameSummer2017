using System.Collections;
using UnityEngine;

namespace Chapter1
{
    public class Shooter : MonoBehaviour
    {
        private float FireRate = 0.3f;
        private float NextFire;
        private RaycastHit hit;
        private float range = 300;
        private Transform myTransform;

        // Use this for initialization
        void Start()
        {
            SetInitialRefrences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        void SetInitialRefrences()
        {
            myTransform = transform;
        }

        private void CheckForInput()
        {
            if (Input.GetButton("Fire1") && Time.time > NextFire)
            {
                Debug.DrawRay(myTransform.TransformPoint(0,0,1), myTransform.forward, Color.red,3);
                if(Physics.Raycast(myTransform.TransformPoint(0, 0, 1), myTransform.forward,out hit, range))
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                       // Debug.Log("Enemy" + hit.transform.name);
                    }
                    else
                    {
                       // Debug.Log("Not an enemy");
                    }
                    
                }
                NextFire = Time.time + FireRate;
            } 
        }
    }
}

