using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    private int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins")) // Compare tag of the collided object
        {
            ScoreNum += 1;
            Destroy(other.gameObject); // Destroy the collided coin
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        MyscoreText.text = "Light Collect: " + ScoreNum;
    }
}
