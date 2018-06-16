using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_ApplyDamage : MonoBehaviour
    {
        private Gun_Master gunMaster;
        public int damage = 10;



        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventShotEnemy += ApplyDamage;
        }

        void OnDisable()
        {
            gunMaster.EventShotEnemy -= ApplyDamage;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
        }

        void ApplyDamage(Vector3 hitPos, Transform hitTrans)
        {
            if(hitTrans.GetComponent<Enemy_TakeDamage>() != null)
            {            
                hitTrans.GetComponent<Enemy_TakeDamage>().ProcessDamage(damage);
            }
        }
    }

}

