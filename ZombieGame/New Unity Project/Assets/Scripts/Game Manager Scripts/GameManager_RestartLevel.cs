using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {

        private GameManager_Master gameManagerMaster;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.RestartLevelEvent += RestartLevel;
        }

        void OnDisable()
        {
            gameManagerMaster.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void RestartLevel()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);            
        }
    }
}

