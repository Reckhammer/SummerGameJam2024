using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitForVideo : MonoBehaviour
{
    public float videoLength = 45f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAfterVideo());
    }

    IEnumerator LoadSceneAfterVideo()
    {
        yield return new WaitForSeconds(videoLength);

        SceneManager.LoadScene("WorldMap");
    }
}
