using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting the game!");
        // Just to make sure its working
    }
}
