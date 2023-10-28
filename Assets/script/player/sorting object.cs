using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingObject : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 1;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;
    
    private float timer;
    private float timerMax = 0.1f;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myRenderer.sortingOrder = sortingOrderBase - (int)(transform.position.y - offset);
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }
}
