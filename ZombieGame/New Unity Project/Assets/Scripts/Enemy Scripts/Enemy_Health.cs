using System.Collections;
using UnityEngine;

namespace S3
{
    public class Enemy_Health : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        public int enemyHealth = 70;
        public AudioClip[] golemHealth;
        public AudioClip[] golemDie;
        private Transform myTransform;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDeductHealth += DeductHealth;
        }
                        
        void OnDisable()
        {
            enemyMaster.EventEnemyDeductHealth -= DeductHealth;
        }

        void SetInitialReferences()
        {
            enemyMaster = GetComponent<Enemy_Master>();
            myTransform = transform;
        }

        void DeductHealth(int healthChange)
        {
            int index1 = Random.Range(0, golemHealth.Length);
            AudioSource.PlayClipAtPoint(golemHealth[index1], myTransform.position);
            enemyHealth -= healthChange;
            if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                int index2 = Random.Range(0, golemDie.Length);
                AudioSource.PlayClipAtPoint(golemDie[index2], myTransform.position);
                enemyMaster.CallEventEnemyDie();
                Destroy(gameObject, Random.Range(3, 4));

            }
        }
    }

}
