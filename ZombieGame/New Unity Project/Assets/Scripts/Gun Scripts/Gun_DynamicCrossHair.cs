using System.Collections;
using UnityEngine;

namespace S3
{
    public class Gun_DynamicCrossHair : MonoBehaviour
    {

        private Gun_Master gunMaster;

        public Transform canvasDynamicCrosshair;
        private Transform playerTransform;
        private Transform weaponCamera;

        private float playerSpeed;
        private float nextCaptureTime;
        private float captureInverval = 1.5f;

        private Vector3 lastPosition;
        public Animator crosshairAnimator;
        public string weaponCameraName;

        void Start()
        {
            SetInitialReferences();
        }

        void Update()
        {
            //CapturePlayerSpeed();
            ApplySpeedToAnimation();
        }

        void SetInitialReferences()
        {
            gunMaster = GetComponent<Gun_Master>();
            playerTransform = GameManager_References._player.transform;
            FindWeaponCamera(playerTransform);
            SetCameraOnDynamicCrosshairCanvas();
            SetPlaneDistanceOnDynamicCrosshairCanvas();
        }

        void CapturePlayerSpeed()
        {
            if(Time.time > nextCaptureTime)
            {
                nextCaptureTime = Time.time + captureInverval;
                playerSpeed = (playerTransform.position - lastPosition).magnitude / captureInverval;
                lastPosition = playerTransform.position;
                gunMaster.CallEventSpeedCapture(playerSpeed);
            }
        }

        void ApplySpeedToAnimation()
        {
            if(crosshairAnimator != null)
            {
                crosshairAnimator.SetFloat("Speed", playerSpeed);
            }
        }

        void FindWeaponCamera(Transform transformToSearchThrough)
        {
            if(transformToSearchThrough != null)
            {
                if(transformToSearchThrough.name == weaponCameraName)
                {
                    weaponCamera = transformToSearchThrough;
                    return;
                }

                foreach(Transform child in transformToSearchThrough)
                {
                    FindWeaponCamera(child);
                }
            }
        }

        void SetCameraOnDynamicCrosshairCanvas()
        {
            if(canvasDynamicCrosshair != null && weaponCamera != null)
            {
                canvasDynamicCrosshair.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
                canvasDynamicCrosshair.GetComponent<Canvas>().worldCamera = weaponCamera.GetComponent<Camera>();
            }
        }

        void SetPlaneDistanceOnDynamicCrosshairCanvas()
        {
            if(canvasDynamicCrosshair != null)
            {
                canvasDynamicCrosshair.GetComponent<Canvas>().planeDistance = 1;

            }
        }
    }

}

