using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*/---------- Lore ---------- /*/
/* The aim of this script will be to always update the text of the coins UI element to how much score has been collected.*/

public class CC_Scr_Score : MonoBehaviour
{
    /*/ ---------- Variable Declaration(s) ---------- /*/
    public Text Coins;                    // Text Object, so we can change the text.
    /*/ ---------- Variable Declaration(s) ---------- /*/

    void Update()
    {
        CC_Scr_GameManager gameManager = FindObjectOfType<CC_Scr_GameManager>();
        Coins.text = "Score: "+ gameManager.Score.ToString();
    }
}
