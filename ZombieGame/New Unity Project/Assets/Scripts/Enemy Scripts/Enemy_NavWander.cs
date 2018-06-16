using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace S3
{
    public class Enemy_NavWander : MonoBehaviour
    {

        private Enemy_Master enemyMaster;
        private NavMeshAgent myNavMeshAgent;
        private float checkRate;
        private float nextCheck;
        private float wanderRange = 10;
        private Transform myTransform;
        private NavMeshHit navHit;
        private Vector3 wanderTarget;

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
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;
                CheckIfIShouldWander();
            }
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            if (GetComponent<NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            }

            checkRate = Random.Range(0.1f, 0.2f);
            myTransform = transform;
        }

        void CheckIfIShouldWander()
        {
            if(enemyMaster.myTarget == null && !enemyMaster.isOnRoute && !enemyMaster.isNavPaused)
            {
                if(RandomWanderTarget(myTransform.position, wanderRange, out wanderTarget))
                {
                    myNavMeshAgent.SetDestination(wanderTarget);
                    enemyMaster.isOnRoute = true;
                    enemyMaster.CallEventEnemyWalking();
                }
            }
        }

        bool RandomWanderTarget(Vector3 centre, float range, out Vector3 result)
        {
            Vector3 randomPoint = centre + Random.insideUnitSphere * wanderRange;
            if(NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas))
            {
                result = navHit.position;
                return true;
            }

            else
            {
                result = centre;
                return false;
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }


    }
}