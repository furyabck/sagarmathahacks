using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class musrromCount : MonoBehaviour
{
    public static float musroom;
    public TMP_Text text1;
    
    
    private void Update()
    {
        text1.text = musroom.ToString();
        
    }
    
}
