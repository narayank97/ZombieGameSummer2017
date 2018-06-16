using System.Collections;
using UnityEngine.UI;
using UnityEngine;


namespace S3
{
    public class Player_Health : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        private Player_Master playerMaster;
        public int playerHealth;
        public TextMesh healthText;
        
    void OnEnable()
    {
            SetInitialReferences();
            SetUI();
            playerMaster.EventPlayerHealthDeduction += DeductHealth;
            playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    void OnDisable()
    {
           playerMaster.EventPlayerHealthDeduction -= DeductHealth;
           playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void Update() 
    {
           
    }

    void SetInitialReferences()
    {
           gameManagerMaster = GameObject.Find("Game Manager").GetComponent<GameManager_Master>();
           playerMaster = GetComponent<Player_Master>();
    }

 /* public IEnumerator ApplyHealthIncrease()
    {
        if(playerHealth <= 95)
        {
            Debug.Log("OH NOo");
            yield return new WaitForSeconds(1);
            IncreaseHealth(5);
            //playerMaster.CallEventPlayerHealthIncrease(5);
        }

    }
*/
    void DeductHealth(int healthChange)
    {
         playerHealth -= healthChange;
         
         if(playerHealth <= 0)
         {
                playerHealth = 0;
                gameManagerMaster.CallGameOverEvent();
         }

            SetUI();
    }

    void IncreaseHealth(int healthChange)
        {
            playerHealth += healthChange;

            if(playerHealth > 100)
            {
                playerHealth = 100;
            }
            SetUI();
        }

    void SetUI()
    {
            if(healthText != null)
            {
                healthText.text = playerHealth.ToString();
            }
    }
}
}
