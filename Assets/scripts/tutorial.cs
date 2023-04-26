using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] popups;
    private int popUpIndex;
    private void Update()
    {
        for (int i = 0; i < popups.Length; i++)
        {
            if (i == popUpIndex)
            {
                popups[i].SetActive(true);
            }
            else
            {
                popups[i].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            // movement
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Step one: move done");
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            // shooting enemy
            if (GameObject.Find("1") == null)
            {
                Debug.Log("Step 2: Kill enemy done");
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            // shooting barrel
            if (GameObject.Find("model") == null)
            {
                Debug.Log("Step 3: TNT expload completed");
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (GameObject.Find("key")== null)
            {
                Debug.Log("Step 4: Got Key Transition to next level");
                popUpIndex++;
            }
        }

    }
}
