using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInfo : MonoBehaviour
{
    public Image HealthBar;
    public  float Health, MaxHealth;
    public GameObject fore, back;
    public float AttackCost;

    public static bool isattackingyes , iseatingyes = false , iseatingjunk = false;
    public static bool isfirsteat = true;

    RectTransform rectTransform1;
    RectTransform rectTransform2;
    void Start()
    {
        rectTransform1 = fore.GetComponent<RectTransform>();
        rectTransform2 = back.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarFunc();
        
    }
    void HealthBarFunc()
    {
        
        

        if (isattackingyes)
        {
            Health -= AttackCost * Time.deltaTime;
        }
        if (iseatingyes && musrromCount.musroom > 0f)
        {
            Health += 3f;
            musrromCount.musroom -= 1;
        }
        if(iseatingjunk && isfirsteat)
        {
            Health += 30f;
            isfirsteat = false;
            MaxHealth = 80f;
            rectTransform1.sizeDelta = new Vector2(130f, rectTransform1.sizeDelta.y);
            rectTransform2.sizeDelta = new Vector2(130f, rectTransform1.sizeDelta.y);
        }

        if (Health < 0)
        {
            Health = 0f;
        }
        HealthBar.fillAmount = Health / MaxHealth;
        
    }
    
}
