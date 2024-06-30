using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSegment : MonoBehaviour
{
    private Image image;
    public Sprite fullImage;
    public Sprite emptyImage;
    public bool isFull;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetFull(bool full)
    {
        isFull = full;

        if (isFull)
        {
            image.sprite = fullImage;
        }
        else
        {
            image.sprite = emptyImage;
        }
    }
}
