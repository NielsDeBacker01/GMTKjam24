using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Stage1City");
    }

    public void Options()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
