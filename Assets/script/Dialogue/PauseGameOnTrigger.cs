using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseGameOnTrigger : MonoBehaviour
{
    public GameObject pausePanel;
    public Button continueButton;
    public float cooldownTime = 5f;
    private bool isPaused = false;
    private bool isCooldown = false;

    void Start()
    {
        pausePanel.SetActive(false);
        continueButton.onClick.AddListener(ContinueGame);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPaused && !isCooldown)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

        if (isCooldown)
        {
            Debug.LogWarning("Cooldown is already active. Coroutine will not start.");
            return;
        }

        // Start the cooldown process
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSecondsRealtime(cooldownTime);
        isCooldown = false;
    }
}
