using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject tutorialScreen;
    [SerializeField] private TutorialCheck check;

    public void Start()
    {
        optionsScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        if(SceneManager.GetActiveScene().name == "Stage1City" && !check.tutorialSeen)
        {
            OpenTuto();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
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

    public void OpenTuto()
    {
        tutorialScreen.SetActive(true);
    }

    public void ExitTuto()
    {
        if(!check.tutorialSeen)
        {
            Time.timeScale = 1;
            check.tutorialSeen = true;
        }
        tutorialScreen.SetActive(false);
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
