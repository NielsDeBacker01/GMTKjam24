using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    public Player player;
    
    // Update is called once per frame
    void Update()
    {
        HPText.text = "HP: "  + player.HP;
    }
}
