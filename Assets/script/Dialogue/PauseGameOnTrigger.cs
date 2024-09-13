using UnityEngine;
using UnityEngine.UI; // Untuk UI seperti Button dan Panel
using System.Collections; // Untuk coroutine cooldown

public class PauseGameOnTrigger : MonoBehaviour
{
    public GameObject pausePanel; // Panel yang akan muncul saat pause
    public Button continueButton; // Tombol untuk melanjutkan permainan
    public float cooldownTime = 5f; // Waktu cooldown setelah melanjutkan
    private bool isPaused = false;
    private bool isCooldown = false; // Menandakan jika dalam masa cooldown

    void Start()
    {
        // Pastikan panel tidak aktif di awal
        pausePanel.SetActive(false);
        
        // Assign fungsi untuk button "Lanjutkan"
        continueButton.onClick.AddListener(ContinueGame);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang masuk collider adalah pemain dan tidak dalam cooldown
        if (other.CompareTag("Player") && !isPaused && !isCooldown)
        {
            // Pause game dan tampilkan panel
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Mem-pause permainan dengan menghentikan waktu
        pausePanel.SetActive(true); // Tampilkan panel
    }

    void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Lanjutkan permainan dengan mengembalikan waktu
        pausePanel.SetActive(false); // Sembunyikan panel
        
        // Mulai cooldown setelah panel di tutup
        StartCoroutine(StartCooldown());
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true; // Mulai cooldown
        yield return new WaitForSecondsRealtime(cooldownTime); // Tunggu selama cooldown (waktu nyata)
        isCooldown = false; // Selesai cooldown
    }
}
