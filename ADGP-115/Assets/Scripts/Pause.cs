using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public Transform pauseMenu, playerUI;
    public GameObject audioSource;
    bool soundToggle = true;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void Mute()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            audioSource.SetActive(true);
        }
        else
        {
            audioSource.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.gameObject.SetActive(true);
                playerUI.gameObject.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.gameObject.SetActive(false);
                playerUI.gameObject.SetActive(true);
              
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
