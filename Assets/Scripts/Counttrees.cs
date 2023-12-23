using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Counttrees : MonoBehaviour
{
    public static float treescut;
    public TMP_Text text1;
    public GameObject textact;
    bool isfirst = true;
    private void Update()
    {
        text1.text = treescut.ToString();
        if(treescut >= 5 && isfirst)
        {
            textact.SetActive(true);
            StartCoroutine(DeactivateText(1.5f));
        }
    }
    private IEnumerator DeactivateText(float delay)
    {
        yield return new WaitForSeconds(delay);
        textact.SetActive(false);
        isfirst = false;
    }
}
