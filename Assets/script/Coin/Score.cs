using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public static int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins")) // Bandingkan tag objek yang bertabrakan
        {
            ScoreNum += 1;
            // Anda tidak perlu menghancurkan objek, cukup nonaktifkan saja
            other.gameObject.SetActive(false);
            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        MyscoreText.text = "Light Collect: " + ScoreNum +" /15";
    }
}