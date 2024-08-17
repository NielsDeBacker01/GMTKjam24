using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HP : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public Player player;
    public UIControls UIControls;
    public GameObject gameOverScreen;
    void Start()
    {
        Unpause();
        player = GameObject.FindGameObjectWithTag("PlayerCore").GetComponent<Player>();
    }
    
    void FixedUpdate()
    {
        HPText.text = "HP: "  + player.HP;
        if(player.HP <= 0)
        {
            Pause();
            UIControls.startMenuControls(UIControls.MENU.gameOver);
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
