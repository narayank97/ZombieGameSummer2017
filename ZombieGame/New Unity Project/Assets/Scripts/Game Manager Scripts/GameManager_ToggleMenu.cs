using System.Collections;
using UnityEngine;

namespace S3
{
public class GameManager_ToggleMenu : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    public GameObject menuP;
    public GameObject menuL;

	void Update () {
            CheckForMenuToggleRequest();
	}

    void OnEnable()
    {
            SetInitialReferences();
            gameManagerMaster.GameOverEvent += ToggleLostMenu;
    }

    void OnDisable()
    {
            gameManagerMaster.GameOverEvent -= ToggleLostMenu;
    }

    void SetInitialReferences()
    {
            gameManagerMaster = GetComponent<GameManager_Master> ();
    }

    void CheckForMenuToggleRequest()
    {
        if(Input.GetKeyUp(KeyCode.Escape)&& !gameManagerMaster.isGameOver && !gameManagerMaster.isInventoryUIOn)
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if(menuP != null)
        {
            menuP.SetActive(!menuP.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallEventMenuToggle();
        }
        else
        {
            Debug.LogWarning("You need to assign a UI GameObject to the Toggle Menu script in the inspector");
        }
    }
        void ToggleLostMenu()
        {
            if (menuL != null)
            {
                menuL.SetActive(!menuL.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallEventMenuToggle();
            }
            else
            {
                Debug.LogWarning("You need to assign a UI GameObject to the Toggle Menu script in the inspector");
            }
        }
    }
 }


