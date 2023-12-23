using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Eating : MonoBehaviour
{
    public Transform cam;
    private bool isdistanceclose = false;
    public float limit;

    
    private void Start()
    {

    }
    private void Update()
    {
        float distance0;
        distance0 = (cam.position - transform.position).magnitude;
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
                PlayerInfo.iseatingjunk = true;
                PlayerInfo.isfirsteat = true;
                gameObject.SetActive(false);
            }
        }
    }
    
}