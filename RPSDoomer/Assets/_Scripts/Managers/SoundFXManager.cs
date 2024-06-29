using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    public void PlaySoundFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("Clip to play is null");
            return;
        }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
