using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace S3
{
    public class Scoped : MonoBehaviour
    {

        public Animator animator;
        public GameObject scopeOverlay;
        public bool isScoped = false;

        void Start()
        {
            scopeOverlay.SetActive(false);
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                isScoped = !isScoped;
                animator.SetBool("Scoped", isScoped);

                if (isScoped)
                {
                    StartCoroutine(OnScoped());
                }
                else
                {
                    OnUnscoped();
                }
            }
        }

        void OnUnscoped()
        {
            scopeOverlay.SetActive(false);
        }

        IEnumerator OnScoped()
        {
            yield return new WaitForSeconds(.1f);
            scopeOverlay.SetActive(true);
        }
    }
}