using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_HitEffects : MonoBehaviour
    {
        private Gun_Master gunMaster;
        public GameObject defaultHitEffect;
        public GameObject enemyHitEffect;


        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventShotDefault += SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
        }

        void OnDisable()
        {
            gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
            gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void SpawnDefaultHitEffect(Vector3 hitPos, Transform hitTrans)
        {
            if (defaultHitEffect != null)
            {
                Instantiate(defaultHitEffect, hitPos, Quaternion.identity);
            }
        }

        void SpawnEnemyHitEffect(Vector3 hitPos, Transform hitTrans)
        {
            if(enemyHitEffect != null)
            {
                Instantiate(enemyHitEffect, hitPos, Quaternion.identity);
            }
        }
    }

}

