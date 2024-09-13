using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public string nextSceneName;
    private Score scoreManager; 

    void Start()
    {
        scoreManager = Object.FindFirstObjectByType<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (scoreManager != null && scoreManager.ScoreNum >= scoreManager.maxScore) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!string.IsNullOrEmpty(nextSceneName)) 
                {
                    SceneManager.LoadScene(nextSceneName); 
                }
                else
                {
                    Debug.LogWarning("Nama scene tidak ditentukan.");
                }
            }
        }
    }
}
