using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace S3
{
    public class Player_Points : MonoBehaviour
    {
        private Player_Master playerMaster;

        public int playerPoints;
        public TextMesh pointsText;

        void OnEnable()
        {
            SetInitialReferences();
            SetUI();
            playerMaster.EventPlayerEarnsPoints += EarnPoints;
            playerMaster.EventPlayerSpendsPoints += SpendPoints;
        }

        void OnDisable()
        {
            playerMaster.EventPlayerEarnsPoints -= EarnPoints;
            playerMaster.EventPlayerSpendsPoints -= SpendPoints;
        }

        void Update()
        {

        }

        void SetInitialReferences()
        {

            playerMaster = GetComponent<Player_Master>();
        }

        void SpendPoints(int points)
        {
            if(playerPoints - points >= 0)
            {
                playerPoints -= points;
                SetUI();
            }
        }

        public void EarnPoints(int points)
        {
            playerPoints += points;
            SetUI();
        }

        void SetUI()
        {
            if (pointsText != null)
            {
                pointsText.text = playerPoints.ToString();
            }
        }
    }

}

