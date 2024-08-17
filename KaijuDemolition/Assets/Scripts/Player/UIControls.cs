using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIControls: MonoBehaviour
{

    private float optionNumber = 1;
    private float menuSize = 1;
    public enum MENU
    {
        gameOver, title
    }
    private MENU menu;
    private bool menuActive;

    public void Start()
    {
        menuActive = false;
    }

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
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                            menuActive = false;
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
    }

}