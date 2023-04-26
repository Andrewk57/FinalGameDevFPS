using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused = false;
    public bool isLocked = true;
    private void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
        }

    }
    public void pauseGame()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isLocked = false;
            AudioListener.volume = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isLocked = true;
            AudioListener.volume = 1f;
        }

    }
    public void loadlevel(string scenename)
    {

        isPaused = false;
        /*Cursor.lockState = CursorLockMode.Locked;
        Curso*/
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
