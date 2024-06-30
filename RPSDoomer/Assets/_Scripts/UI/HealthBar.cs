using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public List<HealthBarSegment> segments = new List<HealthBarSegment>();
    public HealthBarSegment segmentPrefab;
    private LayoutGroup layoutGroup;

    private void Awake()
    {
        layoutGroup = GetComponent<LayoutGroup>();
    }

    public void SetHealth(int amount)
    {
        SetAllSegments(false);

        for (int i = 0; i < amount; i++)
        {
            segments[i].SetFull(true);
        }
    }

    public void SetMaxHealth(int amount)
    {
        if (amount < segments.Count)
        {
            int amtDifference = segments.Count - amount;

            for (int i = 0; i < amtDifference; i++)
            {
                HealthBarSegment lastSegment = segments[segments.Count - 1];
                segments.Remove(lastSegment);
                Destroy(lastSegment.gameObject);
            }
        }
        else if (amount > segments.Count)
        {
            int amtDifference = amount - segments.Count;

            for (int i = 0; i < amtDifference; i++)
            {
                HealthBarSegment newSegment = Instantiate(segmentPrefab, layoutGroup.transform);
                segments.Add(newSegment);
            }
        }
    }

    public void SetAllSegments(bool isFull)
    {
        foreach(HealthBarSegment segment in segments)
        {
            segment.SetFull(isFull);
        }
    }    
}
