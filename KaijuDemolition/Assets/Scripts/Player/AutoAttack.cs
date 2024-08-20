using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;    
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
            sfx.volume = volume.sfx;
            sfx.Play();
            yield return new WaitForSeconds(player.getBaseAttackActiveTime());
            objectToToggle.SetActive(false);
            yield return new WaitForSeconds(player.getAttackCooldown());
        }
    }
}
