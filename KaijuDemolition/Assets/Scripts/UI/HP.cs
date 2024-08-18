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
        slider.ChangeBar(player.baseMaxHP);
        slider.SetBar(player.HP);
        if(player.HP <= 0)
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
