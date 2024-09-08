using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

    public void SaveGame()
    {
        Debug.Log("Game is saving...");
        PlayerPrefs.Save();
    }
}
