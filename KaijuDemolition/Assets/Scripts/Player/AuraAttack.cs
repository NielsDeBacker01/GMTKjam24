using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;      
    [SerializeField] Player player;

    private void FixedUpdate()
    {
        if(player.AuraLevel > 0)
        {
            objectToToggle.SetActive(true);
            objectToToggle.transform.localScale = new Vector3(player.AuraLevel + 0.25f, player.AuraLevel + 0.25f, 1);
        }
        else
        {
            objectToToggle.SetActive(false);
        }   
    }
}
