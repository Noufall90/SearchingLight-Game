using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private Transform _player;

    private void Awake()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<movement>().transform; // Atau tambahkan player secara manual di Inspector
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AwareOfPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AwareOfPlayer = false;
        }
    }

    void Update()
    {
        if (AwareOfPlayer)
        {
            Vector2 enemyToPlayerVector = _player.position - transform.position;
            DirectionToPlayer = enemyToPlayerVector.normalized;
        }
        else
        {
            DirectionToPlayer = Vector2.zero;
        }
    }
}
