using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
public static SceneController instance;
void Awake() {
    // Check if the object has a parent
    if (transform.parent == null) {
        DontDestroyOnLoad(gameObject);
    } else {
        // Detach the object from its parent
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}

  public void NextLevel()
  {
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
  }
  public void LoadScene(string sceneName)
  {
    SceneManager.LoadSceneAsync(sceneName);
  }
}
