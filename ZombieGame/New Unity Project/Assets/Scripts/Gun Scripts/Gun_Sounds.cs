using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_Sounds : MonoBehaviour
    {
        private Gun_Master gunMaster;
        private Transform myTransform;
        public float shootVolume = 0.4f;
        public float reloadVolume = 0.5f;
        public AudioClip[] shootSound;
        public AudioClip reloadSound;

        void OnEnable()
        {
            SetInitialReferences();
            gunMaster.EventPlayerInput += PlayShootSounds;
        }

        void OnDisable()
        {
            gunMaster.EventPlayerInput -= PlayShootSounds;
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            myTransform = transform;
        }
        
        void PlayShootSounds()
        {
            if(shootSound.Length > 0)
            {
                int index = Random.Range(0, shootSound.Length);
                AudioSource.PlayClipAtPoint(shootSound[index], myTransform.position, shootVolume);
            }
        }

        public void PlayReloadSound()
        {
            if(reloadSound != null)
            {
                AudioSource.PlayClipAtPoint(reloadSound, myTransform.position, reloadVolume);
            }
        }
    }

}

