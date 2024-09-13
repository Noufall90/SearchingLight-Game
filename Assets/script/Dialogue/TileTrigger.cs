using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrigger : MonoBehaviour
{
  public GameObject dialogToShow; 
  public float dialogDuration = 7f; 

  private bool dialogActive = false;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player") && !dialogActive)
    {
      DisableAllDialogs();
      dialogToShow.SetActive(true);
      dialogActive = true;
      Invoke("HideDialog", dialogDuration);
    }
  }

  private void DisableAllDialogs()
  {
    GameObject[] dialogs = GameObject.FindGameObjectsWithTag("Dialog");
    foreach (GameObject dialog in dialogs)
    {
      dialog.SetActive(false);
    }
  }

  private void HideDialog()
  {
    dialogToShow.SetActive(false);
  }
}

