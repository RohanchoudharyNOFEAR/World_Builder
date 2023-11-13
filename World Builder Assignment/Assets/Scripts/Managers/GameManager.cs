using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }

        public GameObject player;
        public GameObject playerMovementJoystick;
        public GameObject playerCameraJoystick;
        public GameObject BuilderButton;
        public GameObject InventoryPanel;
        public GameObject InventoryItemsPanel;
        public GameObject PlacementPanel;
        public GameObject SelectionPanel;
        public GameObject CameraPanJoystick;

        private void Awake()
        {
            if(instance!=null && instance!=this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }//awake

      
        public void Explore()
        {
            CameraPanJoystick.SetActive(false);
            BuilderButton.SetActive(false);
            InventoryPanel.SetActive(false);
            PlacementPanel.SetActive(false);
            SelectionPanel.SetActive(false);
            player.SetActive(true);
            playerMovementJoystick.SetActive(true); 
            playerCameraJoystick.SetActive(true);
        }//Explore

        public void QuitGame()
        {
            Application.Quit();
        }//quit

    }
}
