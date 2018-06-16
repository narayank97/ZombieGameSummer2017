using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace S3
{

public class GameManager_TogglePlayer : MonoBehaviour {

        public FirstPersonController playerController;
        private GameManager_Master gameMangerMaser;

        void OnEnable()
        {
            SetInitialReferences();
            gameMangerMaser.MenuToggleEvent += TogglePlayerController;
            gameMangerMaser.InventoryUIToggleEvent += TogglePlayerController;

        }

        void OnDisable()
        {
            gameMangerMaser.MenuToggleEvent -= TogglePlayerController;
            gameMangerMaser.InventoryUIToggleEvent -= TogglePlayerController;

        }

        void SetInitialReferences()
        {
            gameMangerMaser = GetComponent<GameManager_Master>();
        }

        void TogglePlayerController()
        {
            if(playerController != null)
            {
                playerController.enabled = !playerController.enabled;
            }
        }
    }
}

