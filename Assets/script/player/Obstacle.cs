using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour, IComparable<Obstacle>
{
    public SpriteRenderer MySpriteRenderer { get; set; }

    private Color defaultColor;
    private Color fadedColor;

    public int CompareTo(Obstacle other)
    {
        if (MySpriteRenderer.sortingOrder > other.MySpriteRenderer.sortingOrder)
        {
            return 1;
        }
        else if (MySpriteRenderer.sortingOrder < other.MySpriteRenderer.sortingOrder) // Fixed the condition here
        {
            return -1;
        }
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        MySpriteRenderer = GetComponent<SpriteRenderer>();

        defaultColor = MySpriteRenderer.color;
        fadedColor = defaultColor;
        fadedColor.a = 0.9f;
    }

    public void FadedOut()
    {
        MySpriteRenderer.color = fadedColor;
    }

    public void FadedIn()
    {
        MySpriteRenderer.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
