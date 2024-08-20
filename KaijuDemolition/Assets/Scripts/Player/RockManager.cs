using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    [SerializeField] private GameObject ring1;      
    [SerializeField] private GameObject ring2;      
    [SerializeField] private GameObject ring3;      
    [SerializeField] Player player;

    private void FixedUpdate()
    {
        if(player.BoulderLevel < 1)
        {
            ring1.SetActive(false);
            ring2.SetActive(false);
            ring3.SetActive(false);
        }
        else if(player.BoulderLevel < 2)
        {
            ring1.SetActive(true);
            ring2.SetActive(false);
            ring3.SetActive(false);
        }
        else if(player.BoulderLevel < 4)
        {
            ring1.SetActive(false);
            ring2.SetActive(true);
            ring3.SetActive(false);
        }
        else
        {
            ring1.SetActive(false);
            ring2.SetActive(false);
            ring3.SetActive(true);
        }
    }
}
