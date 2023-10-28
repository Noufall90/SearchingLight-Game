using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{
    private SpriteRenderer parentRenderer;
    private List<Obstacle> obstacles = new List<Obstacle>();

    void Start()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            parentRenderer = parentTransform.GetComponent<SpriteRenderer>();
            if (parentRenderer == null)
            {
                Debug.LogWarning("Parent does not have a SpriteRenderer component.");
            }
        }
        else
        {
            Debug.LogWarning("This object has no parent transform.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle o = collision.GetComponent<Obstacle>();
            o.FadedOut();
            if (o != null)
            {
                if (obstacles.Count == 0 || o.MySpriteRenderer.sortingOrder - 1 < parentRenderer.sortingOrder)
                {
                    parentRenderer.sortingOrder = o.MySpriteRenderer.sortingOrder - 1;
                }
                obstacles.Add(o);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle o = collision.GetComponent<Obstacle>();
            o.FadedIn();
            if (o != null)
            {
                obstacles.Remove(o);
                if (obstacles.Count == 0)
                {
                    parentRenderer.sortingOrder = 200;
                }
                else
                {
                    obstacles.Sort();
                    parentRenderer.sortingOrder = obstacles[0].MySpriteRenderer.sortingOrder - 1;
                }
            }
        }
    }
}
