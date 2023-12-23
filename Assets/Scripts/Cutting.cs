using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cutting : MonoBehaviour
{
    public Transform player22;
    private bool isdistanceclose = false;
    public float limit;


    private void Start()
    {

    }
    private void Update()
    {
        float distance0;
        distance0 = (player22.position - transform.position).magnitude;
        if (distance0 < limit)
        {
            isdistanceclose = true;
        }
        else
        {
            isdistanceclose = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isdistanceclose)
            {

                StartCoroutine(CutDelay(1.5f));
                
            }
        }
    }
    private IEnumerator CutDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Counttrees.treescut += 1;
        gameObject.SetActive(false);
    }
}
    
