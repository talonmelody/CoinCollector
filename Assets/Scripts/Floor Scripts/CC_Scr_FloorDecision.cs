using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

/*/---------- Lore ---------- /*/
/* The aim of this script will be to complete the following 3.5 steps:
 * Step 1: Roll a Random Number in the Range 1 - 6.
 * Step 2: Check if the Integer "Roll" is Greater than 1.
 * Step 3: If Roll IS greater than 1, DESTROY the object.
/* Step 3.5: If Roll IS NOT greater than 1, create a coin on top of the tile. */
/*/---------- Lore ---------- /*/

public class CC_Scr_FloorDecision : MonoBehaviour
{
    /*/---------- Variable Declaration(s) ---------- /*/
    public int Roll;                      // Sets up an Integer called Roll for a Random Integer to be inserted into.
    public GameObject Coin;
    public Vector3 StartPosOfTile;
    /*/ ---------- Variable Declaration(s) ---------- /*/

    public void Start()
    {
        StartPosOfTile = transform.position;      // Set the Coin-to-be's starting position to the position of the tile
        Roll = Random.Range(1, 6);                // Set Roll to a random integer between 1 and 6
        if (Roll > 3){                            // If the roll is greater than 3, execute.
        Destroy(gameObject);                      // Destroy the object.
        }
        else
        {
            CC_Scr_GameManager gameManager = FindObjectOfType<CC_Scr_GameManager>();              // Find the GameManager object.
            if (gameManager != null)                                                              // If the GameManager object exists, continue.
            {
                gameManager.CoinsInWorld++;                                                       // Increase CoinsInWorld by 1.
                Debug.Log(gameManager.CoinsInWorld);
            }
            Instantiate(Coin, (StartPosOfTile) + new Vector3 (0f,1.5f,0f), Quaternion.identity) ; // Create a coin at StartPosOfTile, but raised in Y by 1.5.
        }
    }
       
}