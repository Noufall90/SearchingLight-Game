using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lanjut()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
