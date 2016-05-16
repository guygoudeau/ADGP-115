using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public Transform pauseMenu;
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
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.gameObject.SetActive(false);
            }
        }
    }
}
