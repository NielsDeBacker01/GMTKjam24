using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;    
    [SerializeField] private float cooldown;
    [SerializeField] Player player;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            objectToToggle.SetActive(true);
            yield return new WaitForSeconds(player.baseAttackActiveTime);
            objectToToggle.SetActive(false);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
