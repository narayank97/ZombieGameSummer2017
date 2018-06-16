using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Enemy_Detection : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Transform myTransform;
        public Transform head;
        public LayerMask playerLayer;
        public LayerMask sightLayer;
        private float checkRate;
        private float nextCheck;
        private float DetectRadius = 800;
        private RaycastHit hit;
        private int index1;
        public AudioClip[] golemRoar;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
        }

        void Update()
        {
            CarryOutDetection();
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            myTransform = transform;

            if (head == null)
            {
                head = myTransform;
            }

            checkRate = Random.Range(0.8f, 1.2f);
        }

        void CarryOutDetection()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;

                Collider[] colliders = Physics.OverlapSphere(myTransform.position, DetectRadius, playerLayer);

                if (colliders.Length > 0)
                {
                    foreach (Collider potentialTargetCollider in colliders)
                    {
                        if (potentialTargetCollider.CompareTag(GameManager_References._playerTag))
                        {
                            if (CanPotentialTargetBeSeen(potentialTargetCollider.transform))
                            {
                                break;
                            }
                        }
                    }
                }

                else
                {
                    enemyMaster.CallEventEnemyLostTarget();
                }
            }
        }

        bool CanPotentialTargetBeSeen(Transform potentialTarget)
        {
            if (Physics.Linecast(head.position, potentialTarget.position, out hit, sightLayer))
            {
                if (hit.transform == potentialTarget)
                {
                    enemyMaster.CallEventEnemySetNavTarget(potentialTarget);
                    return true;
                }
                else
                {
                    enemyMaster.CallEventEnemyLostTarget();
                    return false;
                }
            }
            else
            {
                enemyMaster.CallEventEnemyLostTarget();
                return false;
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }

    }
}
