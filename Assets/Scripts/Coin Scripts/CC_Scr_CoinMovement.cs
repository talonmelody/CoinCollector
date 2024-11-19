using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/---------- Lore ---------- /*/
/* The aim of this script is to handle 3 different behaviours for the Coin Object. They are:
 * 1: Move up and down in a sinewave pattern, using Time.DeltaTime for smooth movement.
 * 2: Rotate around the Y Axis for visual flare.
 * 3: Handle player collision, add +1 to the Coin Counter, add +25 to the score, and remove the coin from the global count.
 * This will allow for basic gameplay.*/
/*/---------- Lore ---------- /*/

public class CC_Scr_CoinMovement : MonoBehaviour
{
    /*/ ---------- Variable Declaration(s) ---------- /*/
    public float rotationSpeed = 50f;      // Used to determine the rotate speed of the coin.
    public float moveSpeed = 1.0f;         // Used to determine how quickly the coin oscilates.
    public float amplitude = 1.0f;         // Used to determine the height the coin oscilates to.
    private Vector3 startPos;              // Used to store the starting position of each coin.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    void Start()
    {
        startPos = transform.position;  // Sets the coins initial position.
    }

    void Update()
    {
        MoveCoin();       // Custom method to oscilate the coin each frame.
        RotateCoin();     // Custom method to rotate the coin each frame.
    }

    void MoveCoin()
    {
        float verticalMovement = Mathf.Sin(Time.time * moveSpeed) * amplitude; // Calculate movement by multiplying Time.Time and move speed, and the product by amplitude.
        Vector3 newPosition = startPos + Vector3.up * verticalMovement;        // Calculate the new position by adding startPos and the vector (0, 1, 0), and multiplying the product by verticalMovement.
        transform.position = newPosition;                                      // Update the position.
    }
    void RotateCoin()
    {
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime); // Rotate the object by calculating a vector3 (-1, 0, 0) * rotationSpeed * DeltaTime (Time between frames.)

    }

    void OnCollisionEnter(Collision collision) // This method handles what happens when the coin collides with a player.
    {
        if (collision.gameObject.CompareTag("Player"))   // Check for collision with objects tagged "Player".
        {
         CC_Scr_GameManager gameManager = FindObjectOfType<CC_Scr_GameManager>();
            if (gameManager != null)
            {
                gameManager.AddCoin(1);
                gameManager.Score += 25;
            }
            Destroy(gameObject);
        }
    }
}
