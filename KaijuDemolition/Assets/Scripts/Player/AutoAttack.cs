using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] private GameObject objectToToggle;
    [SerializeField] private float activeTime = 0.5f;
    [SerializeField] private float cooldown = 1.5f;

    private void Start()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        while (true)
        {
            objectToToggle.SetActive(true);
            yield return new WaitForSeconds(activeTime);
            objectToToggle.SetActive(false);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
