using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class floatingHealthBar : MonoBehaviour
{
    public Slider slider;
    public float enemyhealth, enemymaxhealth;

    Transform myTransform;
    Transform parentOfParent;
    void Start()
    {
        myTransform = transform;

        // Get the parent of the parent
        parentOfParent = myTransform.parent.parent;

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyhealth < 0)
        {
            enemyhealth = 0f;
            parentOfParent.gameObject.SetActive(false);
        }
        slider.value = enemyhealth / enemymaxhealth;
    }
}
