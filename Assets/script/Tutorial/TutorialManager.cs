using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] public GameObject[] popUps;
    private int popUpIndex;

    void Start()
    {
        popUpIndex = 0;
        ShowCurrentPopup();
    }

    void Update()
    {
        if (popUpIndex < popUps.Length)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                popUps[popUpIndex].SetActive(false);
                popUpIndex++;

                ShowCurrentPopup();
            }
        }
    }

    void ShowCurrentPopup()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
    }
}

