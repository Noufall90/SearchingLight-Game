using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public movement playerMovement; 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) 
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime; // Set KBCounter to knockback duration
            if (collider.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true; 
            }
            else
            {
                playerMovement.KnockFromRight = false; 
            }
        }
    }
}
