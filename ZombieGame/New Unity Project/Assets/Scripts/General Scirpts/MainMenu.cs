using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace S3
{
public class MainMenu : MonoBehaviour {

   public GameObject zombieMenu;

    public void ActivateMainMenu()
    {
        DontDestroyOnLoad(zombieMenu);
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
            Destroy(zombieMenu);
        SceneManager.LoadScene(1);
	}

    public void ControlsGame()
    {
        DontDestroyOnLoad(zombieMenu);
        SceneManager.LoadScene(2);
    }


	public void ExitGame()
    {
        Application.Quit();
	}

  //  void PlayAudioMM()
    //{
      //      if (!gameOn)
        //    {
          //      AudioSource.PlayClipAtPoint(zombieMenu, myTransform.position, mmVolume);
            //}
            
    //}
}
}

