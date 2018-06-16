using System.Collections;
using UnityEngine;

namespace S3
{
public class GameManager_GameOver : MonoBehaviour {

        private GameManager_Master gameManagerMaster;
        public GameObject panelGameOver;
        public AudioClip audioGOover;
        public Transform myTransform;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;

        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TurnOnGameOverPanel()
        {
            if(panelGameOver != null)
            {
                AudioSource.PlayClipAtPoint(audioGOover, myTransform.position);
                panelGameOver.SetActive(true);
            }
        }
    }
}

