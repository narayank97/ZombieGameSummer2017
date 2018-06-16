using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace S3
{
    public class Enemy_NavPause : MonoBehaviour
    {

        private Enemy_Master enemyMaster;
        private NavMeshAgent myNavMeshAgent;
        private float pauseTime = 1;
        

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemyDeductHealth += PauseNavMeshAgent;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemyDeductHealth -= PauseNavMeshAgent;
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            if (GetComponent<NavMeshAgent>() != null)
            {
                myNavMeshAgent = GetComponent<NavMeshAgent>();
            }
        }

        void PauseNavMeshAgent(int dummy)
        {
            if(myNavMeshAgent != null)
            {
                if(myNavMeshAgent.enabled)
                {
                    myNavMeshAgent.ResetPath();
                    enemyMaster.isNavPaused = true;
                    StartCoroutine(RestartNavMeshAgent());
                }
            }
        }

        IEnumerator RestartNavMeshAgent()
        {
            yield return new WaitForSeconds(pauseTime);
            enemyMaster.isNavPaused = false;
        }

        void DisableThis()
        {
            StopAllCoroutines();
        }
    }
}