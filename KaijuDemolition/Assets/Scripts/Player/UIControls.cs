using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIControls: MonoBehaviour
{

    [SerializeField] PlayerValuesReset reset;
    //private float optionNumber = 1;
    //private float menuSize = 1;
    /*public enum MENU
    {
        gameOver, title
    }
    private MENU menu;*/
    //private bool menuActive;
    public GameObject pauseScreen;
    public Player player;
    public GameObject optionsScreen;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public BarSlider slider;
    [SerializeField] private AudioManager audioManager;
    public void Start()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        victoryScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("PlayerCore").GetComponent<Player>();
        //menuActive = false;
    }

    //currently unused
    /*
    public void startMenuControls(MENU menu)
    {
        menuActive = true;
        this.menu = menu;
        switch(menu)
        {
            case MENU.gameOver:
                menuSize = 1;
                break;
            case MENU.title:
                break;
        }
    }

    public void Select(InputAction.CallbackContext context)
    {   
        if(menuActive)
        {
            switch(menu)
            {
                case MENU.gameOver:
                    switch(optionNumber)
                    {
                        case 1:
                            //Restart();
                            break;
                    }
                    break;
                case MENU.title:
                    break;
            }
        }
    }

    public void Navigate(InputAction.CallbackContext context)
    {
        if(menuActive)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            if(movementInput.y > 0)
            {
                optionNumber += 1;
                if(optionNumber > menuSize)
                {
                    optionNumber = 1;
                }
            }

            if(movementInput.y < 0)
            {
                optionNumber -= 1;
                if(optionNumber <= 0)
                {
                    optionNumber = menuSize;
                }
            }
        }
    }*/

    public void Restart()
    {
        reset.Initialize();
        SceneManager.LoadScene("Stage1City");
        //menuActive = false;
    }

    public void Pause()
    {
        if(Time.timeScale == 0)
        {
            Unpause();
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        ExitOptions();
        pauseScreen.SetActive(false);
    }

    public void Victory()
    {
        Time.timeScale = 0;
        victoryScreen.SetActive(true);
    }

    public void PostGame()
    {
        Time.timeScale = 1;
        victoryScreen.SetActive(false);
    }
    
    void FixedUpdate()
    {   
        slider.ChangeBar(player.getMaxHP());
        slider.SetBar(player.getCurrentHP());
        if(player.getCurrentHP() <= 0)
        {
            //startMenuControls(UIControls.MENU.gameOver);
            audioManager.playPlayerDeathSound();
            GameOver();
        }
    }    

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    void Continue()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
    }

    void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    void ExitOptions()
    {
        optionsScreen.SetActive(false);
    }
}