using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Just a bit of fun :3c*/
public class fun : MonoBehaviour
{
    public Text Fun;
    public int FunRoll = 0;
    void Start()
    {
        FunRoll = Random.Range(1, 6);
        switch (FunRoll)
        {
            case 1: Fun.text = "Object Reference Error!!";
                break;

            case 2: Fun.text = "Now without GIFs!";
                break;

            case 3: Fun.text = "Print(NEVER!!)";
                break;

            case 4: Fun.text = "aerie-productions.itch.io!!";
                break;
        }
    }

   
}
