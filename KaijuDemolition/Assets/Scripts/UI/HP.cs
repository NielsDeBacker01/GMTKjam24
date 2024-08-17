using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
