using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public int ScoreNum;
    public int maxScore;
    public GameObject[] coins; // Array untuk menyimpan semua coins
    private Vector3[] originalCoinPositions; // Array untuk menyimpan posisi asli coins
    private GameObject lastCollectedCoin; // Menyimpan coin terakhir yang diambil

    void Start()
    {
        UpdateScoreText();
        StoreOriginalCoinPositions(); // Simpan posisi awal coins
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins") && !other.gameObject.activeInHierarchy) 
        {
            return;
        }

        // Pastikan hanya coin yang diambil
        if (System.Array.Exists(coins, coin => coin == other.gameObject))
        {
            lastCollectedCoin = other.gameObject; // Simpan coin yang diambil
            ScoreNum += 1; 
            other.gameObject.SetActive(false);
            UpdateScoreText(); 
        }
    }

    public void UpdateScoreText()
    {
        MyscoreText.text = "Light Collect: " + ScoreNum + " / " + maxScore;
    }

    public void RespawnLastCollectedCoin()
    {
        if (lastCollectedCoin != null)
        {
            lastCollectedCoin.SetActive(true);
            lastCollectedCoin.transform.position = originalCoinPositions[System.Array.IndexOf(coins, lastCollectedCoin)];
        }
    }

    private void StoreOriginalCoinPositions()
    {
        originalCoinPositions = new Vector3[coins.Length];
        for (int i = 0; i < coins.Length; i++)
        {
            originalCoinPositions[i] = coins[i].transform.position;
        }
    }
}
