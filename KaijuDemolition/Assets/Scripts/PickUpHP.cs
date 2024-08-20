using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHP : MonoBehaviour
{
    public float hpAmount;
    private GameObject playerObject;
    private Player player;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("PlayerCore");
        player = playerObject.GetComponent<Player>();
    }

    public void Initialize(float hp)
    {
        hpAmount *= hp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            if (playerObject != null)
            {
                player.setCurrentHP(hpAmount);
            }
            Destroy(gameObject);
        }
    }
}
