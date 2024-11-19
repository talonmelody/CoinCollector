using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 /$$$$$$$                                                                /$$                     /$$
| $$__  $$                                                              | $$                    | $$
| $$  \ $$  /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$$
| $$  | $$ /$$__  $$ /$$__  $$ /$$__  $$ /$$__  $$ /$$_____/ |____  $$|_  $$_/   /$$__  $$ /$$__  $$
| $$  | $$| $$$$$$$$| $$  \ $$| $$  \__/| $$$$$$$$| $$        /$$$$$$$  | $$    | $$$$$$$$| $$  | $$
| $$  | $$| $$_____/| $$  | $$| $$      | $$_____/| $$       /$$__  $$  | $$ /$$| $$_____/| $$  | $$
| $$$$$$$/|  $$$$$$$| $$$$$$$/| $$      |  $$$$$$$|  $$$$$$$|  $$$$$$$  |  $$$$/|  $$$$$$$|  $$$$$$$
|_______/  \_______/| $$____/ |__/       \_______/ \_______/ \_______/   \___/   \_______/ \_______/
                    | $$                                                                            
                    | $$                                                                            
                    |__/                                                                            

Left for archival reasons!
*/



public class CC_Scr_CreateFloor : MonoBehaviour
{
    // ------------------------------------------------------------------------------- Variable Declarations ------------------------------------------------------------------------------- //
    
    public GameObject Plane2;         // Refers to the Prefab asset called "Plane"
    public int TilesAcross = 0;      // How many Tiles (Prefab Plane Objects) should be generated along the X Axis
    public int TilesUp = 0;          // How many Tiles (Prefab Plane Objects) should be generated along the Z Axis
    public int HeightOfField = 0;    // Can be used to adjust how high this field is generated along the Y Axis.
    public float Scale = 5.0f;
    

    // ------------------------------------------------------------------------------- Variable Declarations ------------------------------------------------------------------------------- //

    public void Start()
    {
      BeginLevel();
      
    }

    public void BeginLevel()          // This will run when the custom method BeginLevel is called.


    /* How Generating Tiles Works
    * Stage 1: Start a for loop which creates an integer called "up". If up is NOT greater than TilesUp, continue the loop. Otherwise, break
    * Stage 2: Start a for loop which creates an integer called "across". If across is NOT greater than TilesAcross, add one to across and continue. Otherwise, break
    * Stage 3: Create a Plane Prefab with the position X = Across, Y = HeightOfField, Z = Up.
    * Stage 4: increase Integer "up" by 1, check the initial For loop, and continue if the conditions are met.
    * These steps will create a field of tiles the size of each axis multiplied i.e TilesAcross = 2 * TilesUp = 2 = 4 Total tiles.
    * This has been chosen instead of a single plane as it will allow for each tile to have a unique behaviour.
    */


{

    for (int up  = 0; up < TilesUp;)                 
    {
        for (int across = 0; across < TilesAcross; across++)
        {
            Instantiate(Plane2, new Vector3 (across * Scale, HeightOfField, up * Scale), Quaternion.identity); // Create an instance of the Prefab "Plane"
        }
        up++;
    }

}






}

