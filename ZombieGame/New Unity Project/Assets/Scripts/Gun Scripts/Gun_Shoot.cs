using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_Shoot : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private Transform myTransform;
        private Transform camTransform;
        private Transform temp;
        private RaycastHit hit;
        public float range = 400;
        private float offsetFactor = 7;
        private Vector3 startPos;


        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += OpenFire;
            gunMaster.EventSpeedCapture += SetStartOfShootingPosition;
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= OpenFire;
            gunMaster.EventSpeedCapture -= SetStartOfShootingPosition;

        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            myTransform = transform;
            camTransform = myTransform.parent;
        }

        void OpenFire() 
        {
            Physics.Raycast(camTransform.TransformPoint(startPos) + (camTransform.forward * 4), camTransform.forward, out hit, range);
            gunMaster.CallEventShotDefault(hit.point, hit.transform);

                if (hit.transform.CompareTag(GameManager_References._enemyTag))
                {
                   gunMaster.CallEventShotEnemy(hit.point, hit.transform);
                }
            
        }

        void SetStartOfShootingPosition(float playerSpeed)
        {
            float offset = (playerSpeed / offsetFactor);
            startPos = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 1);
        }
    }

}

