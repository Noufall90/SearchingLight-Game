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

        if (gameObject.activeInHierarchy) // Ensure the object is active
        {
            StartCoroutine(StartCooldown());
        }
        else
        {
            Debug.LogWarning("GameObject is inactive. Coroutine will not start.");
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSecondsRealtime(cooldownTime);
        isCooldown = false;
    }
}
