using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social_D : MonoBehaviour
{
    public Slider SD;
    public float currentD = 3.5f;
    public float maxD = 3.5f;
    public float multipier;
    public Image Fill;
    

    [SerializeField]
    public Text level;

    void Awake()
    {
        SD = GetComponent<Slider>();
        multipier = 1f;
    }
    void Update()
    {

        SD.value = currentD;
        SD.maxValue = maxD;

        if (currentD >= 2.5)
        {
            multipier = 1;
            Fill.color = Color.green;
        }
        if (currentD <= 2.4 )
        {
            multipier = 2;
            Fill.color = Color.red;
        }
       
        level.text = currentD + " m";
    }
    public void changeDistance(int dHP)
    {
        if (currentD + dHP > 30)
        {
            currentD = 30;
            // do hp dmg

        }
        else if (currentD + dHP < 0)
        {

            currentD = 0;


        }
        else
        {
            currentD += dHP;
        }


    }
    public void setD(int maxHP)
    {
        maxD = maxHP;
    }
    public void setcurrentD(int currentHP)
    {
        currentD = currentHP;
    }
}
