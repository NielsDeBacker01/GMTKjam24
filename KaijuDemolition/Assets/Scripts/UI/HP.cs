using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HP : MonoBehaviour
{
    public Player player;
    public UIControls UIControls;
    public GameObject gameOverScreen;
    public BarSlider slider;
    void Start()
    {
        Unpause();
        player = GameObject.FindGameObjectWithTag("PlayerCore").GetComponent<Player>();
    }
    
    void FixedUpdate()
    {   
        slider.ChangeBar(player.getMaxHP());
        slider.SetBar(player.getCurrentHP());
        if(player.getCurrentHP() <= 0)
        {
            UIControls.startMenuControls(UIControls.MENU.gameOver);
            Pause();
        }
    }    

    void Pause()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    void Unpause()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
    }
}
