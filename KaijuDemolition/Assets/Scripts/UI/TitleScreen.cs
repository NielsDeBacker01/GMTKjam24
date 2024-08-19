using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject optionsScreen;

    public void Start()
    {
        optionsScreen.SetActive(false);
    }

    public void Load()
    {
        SceneManager.LoadScene("Stage1City");
    }

    public void Options()
    {
        optionsScreen.SetActive(true);
    }

    public void ExitOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Title()
    {
        SceneManager.LoadScene("Stage0TitleScreen");
    }
}
