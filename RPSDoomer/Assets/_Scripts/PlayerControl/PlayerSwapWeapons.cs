using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwapWeapons : MonoBehaviour
{
    public GameObject[] hudElements;
    public PlayerAttack[] playerWeapons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableAll();
            hudElements[0].gameObject.SetActive(true);
            playerWeapons[0].gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableAll();
            hudElements[1].gameObject.SetActive(true);
            playerWeapons[1].gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisableAll();
            hudElements[2].gameObject.SetActive(true);
            playerWeapons[2].gameObject.SetActive(true);
        }
    }

    public void DisableAll()
    {
        for (int ind = 0; ind < hudElements.Length; ind++)
        {
            hudElements[ind].SetActive(false);
            playerWeapons[ind].gameObject.SetActive(false);
        }
    }
}
