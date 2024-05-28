using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThorofareModMenu
{
    public class ModMenuUI : MonoBehaviour
    {
        private int selectedTab = 0;
        private string[] tabNames = { "General", "Player", "World", "Other" };

        GameObject playerPrefab;
        GameObject[] possiblePlayerModels;
        GameObject player;

        private float walkSpeed = 5.0f;
        private float jogSpeed = 10.0f;

        void Update()
        {
            if (SceneManager.GetActiveScene().name == "TeenLoop")
            {
                playerPrefab = GameObject.Find("Player Prefab");
                if (playerPrefab != null)
                {
                    possiblePlayerModels = playerPrefab.GetComponentsInChildren<GameObject>();
                    foreach (GameObject plr in possiblePlayerModels)
                    {
                        if (plr.name == "PlayerModel")
                        {
                            // Set the found PlayerModel to the player GameObject
                            player = plr.gameObject;
                            Debug.Log("(Thorofare Mod Menu : UI) Found player! Ready for modding");
                            break; // Exit the loop once the player model is found
                        }
                    }
                }
            }
        }

        void OnGUI()
        {
            // Define the area for the tab bar
            Rect tabBarRect = new Rect(10, 10, 400, 30);
            selectedTab = GUI.Toolbar(tabBarRect, selectedTab, tabNames);

            // Define the area for the panel
            Rect panelRect = new Rect(10, 50, 400, 300);
            GUI.Box(panelRect, "Thorofare Mod Menu");

            // Define the area for the content inside the panel
            Rect contentRect = new Rect(20, 70, 380, 270);

            // Draw content based on the selected tab
            switch (selectedTab)
            {
                case 0:
                    ShowTab1Content(contentRect);
                    break;
                case 1:
                    ShowTab2Content(contentRect);
                    break;
                case 2:
                    ShowTab3Content(contentRect);
                    break;
                case 3:
                    ShowTab4Content(contentRect);
                    break;
            }
        }

        void ShowTab1Content(Rect contentRect)
        {
            GUI.Label(new Rect(contentRect.x, contentRect.y, contentRect.width, 20), "General Mods");

        
        }

        void ShowTab2Content(Rect contentRect)
        {
            GUI.Label(new Rect(contentRect.x, contentRect.y, contentRect.width, 20), "Player Mods");

            GUI.Label(new Rect(contentRect.x, contentRect.y + 30, contentRect.width, 20), "Walk Speed");
            player.GetComponent<vgPlayerNavigationController>().walkSpeed = GUI.HorizontalSlider(new Rect(contentRect.x, contentRect.y + 50, contentRect.width - 20, 20), walkSpeed, 0.0f, 20.0f);
            GUI.Label(new Rect(contentRect.x + contentRect.width - 40, contentRect.y + 30, 40, 20), walkSpeed.ToString("F2"));

            GUI.Label(new Rect(contentRect.x, contentRect.y + 80, contentRect.width, 20), "Jog Speed");
            player.GetComponent<vgPlayerNavigationController>().jogSpeed = GUI.HorizontalSlider(new Rect(contentRect.x, contentRect.y + 100, contentRect.width - 20, 20), jogSpeed, 0.0f, 20.0f);
            GUI.Label(new Rect(contentRect.x + contentRect.width - 40, contentRect.y + 80, 40, 20), jogSpeed.ToString("F2"));
        }

        void ShowTab3Content(Rect contentRect)
        {
            GUI.Label(new Rect(contentRect.x, contentRect.y, contentRect.width, 20), "World Mods");
            // Add more GUI controls here as needed
        }

        void ShowTab4Content(Rect contentRect)
        {
            GUI.Label(new Rect(contentRect.x, contentRect.y, contentRect.width, 20), "Other Mods");
            // Add more GUI controls here as needed
        }
    }
}
