using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToNextLevel : MonoBehaviour
{
  public int nextSceneLoad;
  // Start is called before the first frame update
  void Start()
  {
    nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
  }

  public void OnTriggerEnter2D(Collider2D other)
  {
    if (Score.ScoreNum == 12)
    {

      if (other.gameObject.tag == "Player")
      {
        SceneController.instance.NextLevel();
      }
    }
  }

}
