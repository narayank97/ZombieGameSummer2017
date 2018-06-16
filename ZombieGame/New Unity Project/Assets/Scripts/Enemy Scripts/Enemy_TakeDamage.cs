using System.Collections;
using UnityEngine;

namespace S3
{
    public class Enemy_TakeDamage : MonoBehaviour
    {
        private Enemy_Master enemyMaster;
        private Player_Master playerMaster;

        public int damageMultiplier = 1;
        public bool shouldRemoveCollider;

        void OnEnable()
        {
            SetInitialReferences();
            enemyMaster.EventEnemyDie += RemoveThis;
        }

        void OnDisable()
        {
            enemyMaster.EventEnemyDie -= RemoveThis;
        }



        void SetInitialReferences()
        {
            enemyMaster = transform.root.GetComponent<Enemy_Master>();

            if (GameManager_References._player != null)
            {
                playerMaster = GameManager_References._player.GetComponent<Player_Master>();
            }
        }

        public void ProcessDamage(int damage)
        {
            int damageToApply = damage * damageMultiplier;
            enemyMaster.CallEventEnemyDeductHealth(damageToApply);
            playerMaster.CallEventPlayerEarnsPoints(damage);
        }

        void RemoveThis()
        {
            if (shouldRemoveCollider)
            {
                if (GetComponent<Collider>() != null)
                {
                    Destroy(GetComponent<Collider>());
                }

                if (GetComponent<Rigidbody>() != null)
                {
                    Destroy(GetComponent<Rigidbody>());
                }

            }

            Destroy(this);
        }
    }



}