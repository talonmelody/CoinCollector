using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*/---------- Lore ---------- /*/
/* The aim of this script is to allow the different buttons to input which difficulty to load.*/
/*/---------- Lore ---------- /*/

public class CC_Scr_ButtonManager : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;  // Makes sure the cursor is Unlocked.
        Cursor.visible = true;                   // Shows the cursor.
    }
    public void LoadDifficulty(int Dfctly)
    {
        switch (Dfctly)
        {
            // This switch case controls the loaded world. Buttons input different values depending on difficulty.
            
            case 1:
                SceneManager.LoadScene("CC_World1");   // Load the easy level
                Debug.Log("Easy");
                break;

            case 2:
                SceneManager.LoadScene("CC_World2");   // Load the medium level
                Debug.Log("Medium");
                break;
            
            case 3:
                SceneManager.LoadScene("CC_World3");   // Load the hard level
                Debug.Log("Hard");
                break;
            
            case 4:
                SceneManager.LoadScene("CC_MainMenu"); // Load the main menu
                break;
                 
            case 5:                                    // Quit the game.
                Application.Quit();
                break;
        }
    }
}
