using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace S3
{
    public class Enemy_NavPursue : MonoBehaviour
    {
        Transform player;
        NavMeshAgent myNavMeshAgent;
        private Enemy_Master enemyMaster;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
        }

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            enemyMaster.CallEventEnemyWalking();
            enemyMaster.isOnRoute = true;
            myNavMeshAgent.SetDestination(player.position);
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            if (GetComponent<NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            }
        }
        void DisableThis()
        {
            if (myNavMeshAgent != null)
            {
                myNavMeshAgent.enabled = false;
            }

            this.enabled = false;
        }

        /* private Enemy_Master enemyMaster;
         private NavMeshAgent myNavMeshAgent;
         private float checkRate;
         private float nextCheck;

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
             if(Time.time > nextCheck)
             {
                 nextCheck = Time.time + checkRate;
                 TryToChaseTarget();
             }
         }

         void SetInitialReferences()
         {
             enemyMaster = GetComponent<Enemy_Master>();
             if(GetComponent<NavMeshAgent>() != null)
             {
                 myNavMeshAgent = GetComponent<NavMeshAgent>();
             }

             checkRate = Random.Range(0.1f, 0.2f);
         }

         void TryToChaseTarget()
         {
             if(enemyMaster.myTarget != null && myNavMeshAgent != null && !enemyMaster.isNavPaused)
             {
                 myNavMeshAgent.SetDestination(enemyMaster.myTarget.position);

                 if(myNavMeshAgent.remainingDistance >= myNavMeshAgent.stoppingDistance)
                 {
                     enemyMaster.CallEventEnemyWalking();
                     enemyMaster.isOnRoute = true;
                 }
             }
         }

         void DisableThis()
         {
             if(myNavMeshAgent != null)
             {
                 myNavMeshAgent.enabled = false;
             }

             this.enabled = false;
         }*/
    }
}
