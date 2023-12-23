using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickUpMusroom : MonoBehaviour
{
    
    public Transform player22;
    private bool isdistanceclose = false;
    public float limit;
   


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
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isdistanceclose)
            {
                gameObject.SetActive(false);
                musrromCount.musroom += 10f;

            }
        }
    }
}
