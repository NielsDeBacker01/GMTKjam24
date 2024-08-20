using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;      
    [SerializeField] Player player;
    [SerializeField] float active;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        int counter = 0;
        while (true)
        {
            if(player.BeamLevel > 0 && counter > 0)
            {
                objectToToggle.SetActive(true);
            }
            yield return new WaitForSeconds(active);
            objectToToggle.SetActive(false);
            yield return new WaitForSeconds(player.getBeamCooldown());
            counter++;
        }
    }
}
