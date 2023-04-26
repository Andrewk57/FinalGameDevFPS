using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    //public GameObject PauseMenu;
    //public static bool isPaused = false;
    private void Start()
    {
        //Time.timeScale = 1f;
        //PauseMenu.SetActive(false);




    }

    private void Update()
    {
       /* if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
        }*/

    }
    /*public void pauseGame()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioListener.volume = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioListener.volume = 1f;
        }

    }*/
    public void loadlevel(string scenename)
    {

        //isPaused = false;

        //Destroy(this.GetComponent<AudioSource>());
        SceneManager.LoadScene(scenename);

    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit");
        Application.Quit();
    }
}
