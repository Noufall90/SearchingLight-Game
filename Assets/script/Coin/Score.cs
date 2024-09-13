using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public int ScoreNum;
    public int maxScore;

    void Start()
    {
        UpdateScoreText(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins")) 
        {
            ScoreNum += 1; 
            other.gameObject.SetActive(false);
            UpdateScoreText(); 
        }
    }

    public void UpdateScoreText()
    {
        MyscoreText.text = "Light Collect: " + ScoreNum + " / " + maxScore;
    }
}
