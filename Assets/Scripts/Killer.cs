using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script progresses to the death scene if called.

public class Killer : MonoBehaviour
{
    void OnCollisionStay()
    {
        SceneManager.LoadScene("CC_Dead");   // Load the death level
    }


}
