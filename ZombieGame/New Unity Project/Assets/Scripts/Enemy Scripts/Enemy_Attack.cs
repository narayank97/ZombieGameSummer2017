using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace S3
{
    public class Enemy_Attack : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Player_Master playerMaster;
        private Transform attackTarget;
        private Transform myTransform;
        public float attackRate = 1;
        private float nextAttack;
        public float attackRange = 4f;
        public int attackDamage = 10;

        public AudioClip[] golemAttack;
        private int currentPlayerHealth = 100;
        private int newPlayerHealth = 100;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += DisableThis;
            enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= DisableThis;
            enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
        }

       
        void Update()
        {
            TryToAttack();
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            playerMaster = GetComponent<Player_Master>();
            myTransform = transform;
        }

        void SetAttackTarget(Transform targetTransform)
        {
            attackTarget = targetTransform;
        }

        void TryToAttack()
        {
            if(attackTarget != null)
            {
                if(Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    if(Vector3.Distance(myTransform.position,attackTarget.position) <= attackRange)
                    {
                        int index = Random.Range(0, golemAttack.Length);
                        AudioSource.PlayClipAtPoint(golemAttack[index], myTransform.position);
                        Vector3 lookAtVector = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                        myTransform.LookAt(lookAtVector);
                        enemyMaster.CallEventEnemyAttack();
                        enemyMaster.isOnRoute = false;
                    }
                }
            }
        }

        public void OnEnemyAttack()
        {
            if(attackTarget != null)
            {
                if(Vector3.Distance(myTransform.position,attackTarget.position) <= attackRange && attackTarget.GetComponent<Player_Master>() != null)
                {
                    Vector3 toOther = attackTarget.position - myTransform.position;

                    if(Vector3.Dot(toOther,myTransform.forward) > 0.5f)
                    {
                        
                        attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDeduction(attackDamage);
                        currentPlayerHealth = attackTarget.GetComponent<Player_Health>().playerHealth;
                        StartCoroutine(ApplyHealthIncrease());
                        
                    }
                }
            }
        }

        void DisableThis()
        {
            this.enabled = false;
        }

        public IEnumerator ApplyHealthIncrease()
        {
            if (currentPlayerHealth <= 95)
            {
                yield return new WaitForSeconds(10);
                while(currentPlayerHealth <= 95)
                {
                    attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthIncrease(1);
                    yield return new WaitForSeconds(1);
                    newPlayerHealth = attackTarget.GetComponent<Player_Health>().playerHealth;

                    if (newPlayerHealth < currentPlayerHealth || newPlayerHealth == 95)
                    {
                        break;
                    }
                }
            }

        }
    }
}
