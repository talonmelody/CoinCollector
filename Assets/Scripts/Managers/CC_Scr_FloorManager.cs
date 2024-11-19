using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/---------- Lore ---------- /*/
/* The aim of this script will be to complete the following 3 steps:
 * Step 1: Create the specific amount of tiles,
 * Step 2: Create the specific number of holes,
 * Step 3: Create the specific number of coins,
 * This will set up a basic gameplay level.
 * Tiles are sets of 3x3 tiles. Based on the difficulty they will be destroyed, have a coin, or do nothing.*/
/*/---------- Lore ---------- /*/

public class CC_Scr_FloorManager : MonoBehaviour
{

    /*/ ---------- Variable Declaration(s) ---------- /*/
    public GameObject Tile;                // Defines a GameObject called "Tile".
    public GameObject SpawnTile;           // Defines a GameObject called "SpawnTile".
    public float OriginX = 0;              // Used to set the starting X position used to create tiles.
    public float OriginY = 0;              // Used to set the starting Y position used to create tiles.
    public int TilesAcross = 1;            // Used to determine how far along the X Axis tiles should be created.
    public int TilesUp = 1;                // Used to determine how far along the Y Axis tiles should be created.
    public int FirstTile = 1;              // Used to determine if a tile is the first one.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    public void Start() 
   
    {
       
        for (int up = 0; up < TilesUp;)                          // Start a For Loop. If the integer Up isn't greater than how many tiles there should be on the Z axis, loop. Otherwise, break.
        {
            for (int across = 0; across < TilesAcross; across++) // Nested For Loop. If the integer Across isn't greater than how many tiles there should be on the X axis, loop. Otherwise, break.
            {
                if (FirstTile == 1)  // If THIS IS the first tile being created, continue
                {
                    Instantiate(SpawnTile, new UnityEngine.Vector3(OriginX + 15 * across, OriginY + 1, 15 * up), Quaternion.identity); // Instantiate the Tile Prefab, offset the across position by 15, the Y Origin and up by 15.
                    FirstTile = 0;
                }
                else                // If THIS IS NOT the first tile being created, continue
                {
                    Instantiate(Tile, new UnityEngine.Vector3(OriginX + 15 * across, OriginY + 1, 15 * up), Quaternion.identity); // Instantiate the Tile Prefab, offset the across position by 15, the Y Origin and up by 15.
                }

            }
            up++; // Progress +1 up TilesUp to generate tiles further along the Z axis if required.
        }

    }

}
