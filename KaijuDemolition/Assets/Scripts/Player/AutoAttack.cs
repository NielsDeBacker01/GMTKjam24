using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;    
    [SerializeField] private GameObject objectToToggle2;    
    [SerializeField] Player player;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioValues volume;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            objectToToggle.SetActive(true);
            if(player.ArmsLevel == 1)
            {
                objectToToggle2.SetActive(true);
            }
            sfx.volume = volume.sfx;
            sfx.Play();
            yield return new WaitForSeconds(player.getBaseAttackActiveTime());
            objectToToggle.SetActive(false);
            objectToToggle2.SetActive(false);
            yield return new WaitForSeconds(player.getAttackCooldown());
        }
    }
}
