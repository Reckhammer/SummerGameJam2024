using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioClip[] musicList;
    private AudioSource musicSource;

    public bool playOnStart = false;
    public bool playRandomFirst = false;

    private Coroutine musicListCoroutine;

    public void Awake()
    {
        if (musicList == null || musicList.Length == 0)
            Debug.LogWarning("No music provided", this);

        musicSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        if (playOnStart)
            PlayMusicList();
    }

    public void PlayMusicList()
    {
        if (musicListCoroutine != null)
            StopCoroutine(musicListCoroutine);

        musicListCoroutine = StartCoroutine(PlayMusicListCoroutine());
    }

    private IEnumerator PlayMusicListCoroutine()
    {
        if (musicList == null || musicList.Length == 0)
            yield break;

        int index = 0;

        if (playRandomFirst)
            index = Random.Range(0, musicList.Length);

        while (true)
        {
            musicSource.Stop();
            musicSource.clip = musicList[index];
            musicSource.Play();

            yield return new WaitForSeconds(musicList[index].length + .5f);

            index++;

            if (index >= musicList.Length)
                index = 0;
        }
    }

    public void PlayMusicClip(AudioClip musicClip, bool loop = true)
    {
        if (musicListCoroutine != null)
        {
            StopCoroutine(musicListCoroutine);
            musicListCoroutine = null;
        }

        musicSource.Stop();
        musicSource.clip = musicClip;
        musicSource.loop = loop;
        musicSource.Play();
    }
}
