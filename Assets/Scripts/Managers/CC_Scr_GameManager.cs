using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

/*/---------- Lore ---------- /*/
/* The aim of this script is to function as the Game Manager for the game. It will do the following things:
 * 1: Keep track of coins in world and coins collected.
 * 2: If the player has collected all of the coins in the world, win the game.
 * 3: Contain the scripts for the PAUSING functionality.
 * It's a good practise to keep important logic like this within an object that won't be part of gameplay.
*/
/*/---------- Lore ---------- /*/

public class CC_Scr_GameManager : MonoBehaviour
{
    /*/ ---------- Variable Declaration(s) ---------- /*/
    public int CoinsInWorld = 0;           // Used to store how many coins have been created.
    public int CollectedCoins = 0;         // Used to store how many coins have been collected.
    public int Score = 0;                  // Used to store how much score has been collected.
    public int ScoreAmount = 0;            // Used to determine how much each coin should be worth.
    public bool isPaused = false;          // Used to pause the game.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    public void Start()
    {
        Application.targetFrameRate = 60;       // Asks the system very nicely for 60fps. Just a preference.
    }

    public void Update()
    {
        Pause();
    }


    public void AddCoin(int amount)
    {                                           // The check if all the coins are gone is called here so it isn't called on the first frame, before coins r processed.
        CollectedCoins += amount;
        CoinsInWorld--;
        Debug.Log(CollectedCoins);
        if (CoinsInWorld == 0)                  // If no coins are left, continue.
        {
            SceneManager.LoadScene("CC_Win");   // Load the victory screen.
        }
    }


    public void Pause()    // Used to pause the game.
    {
        if (Input.GetKeyDown(KeyCode.P))            // Check for P being pressed.

        {
            if (isPaused)
            {
                Time.timeScale = 1.0f;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
            isPaused = !isPaused;
        }


    }
}
