using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu, optionsMenu, controlsScreen, creditsScreen, contactUsScreen;
    public GameObject audioSource;
    bool soundToggle = true;

	public void LoadScene (string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        soundToggle = !soundToggle;
        if(soundToggle)
        {
            audioSource.SetActive(true);
        }
        else
        {
            audioSource.SetActive(false);
        }
    }

    public void OptionsMenu(bool clicked)
    {
        if (clicked == true)
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
        else
        {
            mainMenu.gameObject.SetActive(true);
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void ControlsScreen(bool clicked)
    {
        if (clicked == true)
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(true);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
        else
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void CreditsScreen(bool clicked)
    {
        if (clicked == true)
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(true);
            contactUsScreen.gameObject.SetActive(false);
        }
        else
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }

    public void ContactUsScreen(bool clicked)
    {
        if (clicked == true)
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(true);
        }
        else
        {
            mainMenu.gameObject.SetActive(false);
            optionsMenu.gameObject.SetActive(true);
            controlsScreen.gameObject.SetActive(false);
            creditsScreen.gameObject.SetActive(false);
            contactUsScreen.gameObject.SetActive(false);
        }
    }
}
