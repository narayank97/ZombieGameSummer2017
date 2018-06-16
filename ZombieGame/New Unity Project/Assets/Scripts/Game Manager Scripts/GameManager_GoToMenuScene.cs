using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
public class GameManager_GoToMenuScene : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

	void OnEnable ()
    {
         SetInitialreferences();
         gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
	}
	

	void OnDisable ()
    {
         gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;

    }

    void SetInitialreferences()
    {
         gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void GoToMenuScene()
        {
            SceneManager.LoadScene(0);
        }
}
}

