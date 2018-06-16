using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Enemy_Animation : MonoBehaviour
    {

        private Enemy_Master enemyMaster;
        private Animator myAnimator;


        void OnEnable()
        {
            SetIntialReferences();
            enemyMaster.EventEnemyDie += DisableAnimator;
            enemyMaster.EventEnemyWalking += SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
            enemyMaster.EventEnemyAttack += SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth += SetAnimationToStruck;

        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableAnimator;
            enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
            enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
            enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
            enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruck;
        }

        void SetIntialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();

            if (GetComponent<Animator>() != null)
            {
                myAnimator = GetComponent<Animator>();
            }


        }

        void SetAnimationToWalk()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetBool("isPursuing", true); // the triggers from animation tab in unity
                }
            }
        }

        void SetAnimationToIdle()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetBool("isPursuing", false);
                }
            }
        }

        void SetAnimationToAttack()
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetTrigger("Attack");
                }
            }
        }

        void SetAnimationToStruck(int dummy)
        {
            if (myAnimator != null)
            {
                if (myAnimator.enabled)
                {
                    myAnimator.SetTrigger("Struck");
                }
            }
        }

        void DisableAnimator()
        {
            if (myAnimator != null)
            {
                myAnimator.enabled = false;
            }
        }
    }
}
