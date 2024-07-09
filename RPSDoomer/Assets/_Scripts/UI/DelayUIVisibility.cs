using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayUIVisibility : MonoBehaviour
{
    public float initialDelay = 0.5f;
    public float fadeInTime = 3f;
    private Image myImage;

    public void Awake()
    {
        myImage = GetComponent<Image>();
    }

    public void Start()
    {
        StartFadeInCoroutine();
    }

    public void StartFadeInCoroutine()
    {
        myImage.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);

        float currentTime = 0f;

        while (myImage.color.a < 1f)
        {
            myImage.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, currentTime / fadeInTime));
            currentTime += Time.deltaTime;
            
            yield return null;
        }
    }

#if UNITY_EDITOR

    [ContextMenu("Set UI Invisible")]
    public void SetUIInvisible()
    {
        myImage = GetComponent<Image>();

        if (myImage != null)
        {
            myImage.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            Debug.LogError("Image Component not found", this);
        }
    }

    [ContextMenu("Set UI Visible")]
    public void SetUIVisible()
    {
        myImage = GetComponent<Image>();

        if (myImage != null)
        {
            myImage.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            Debug.LogError("Image Component not found", this);
        }
    }

#endif
}
