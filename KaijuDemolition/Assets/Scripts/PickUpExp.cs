using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExp : MonoBehaviour
{
    public int expAmount = 10;
    private PlayerExp playerExp;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerCore");
        if (player != null)
        {
            playerExp = player.GetComponent<PlayerExp>();
        }
    }

    public void Initialize(float enemySize)
    {
        expAmount = (int)(expAmount * enemySize);
        this.transform.localScale = new Vector3((float)(0.1 * enemySize),(float)(0.1 * enemySize),1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            if (playerExp != null)
            {
                playerExp.AddExperience(expAmount); 
            }
            Destroy(gameObject); 
        }
    }
}
