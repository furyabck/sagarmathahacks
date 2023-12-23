using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireforcamp : MonoBehaviour
{
    public Transform player22;
    private bool isdistanceclose = false;
    public float limit;
    public GameObject fire;
    

    
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isdistanceclose)
            {
                if (Counttrees.treescut >= 3)
                {
                    fire.SetActive(true);
                    Counttrees.treescut -= 3;
                }
                

            }
        }
        if(Input.GetKeyDown(KeyCode.H))
            {
            if (fire.activeSelf)
            {
                PlayerInfo.iseatingyes = true;
            }
            else
            {
                PlayerInfo.iseatingyes = false;
            }
            

        }
    }
    
}
