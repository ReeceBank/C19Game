using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Social_D : MonoBehaviour
{
    public Slider SD;
    public float currentD = 2.0f;
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

        if (currentD >= 2.5f)
        {
            multipier = 0.5f;
            Fill.color = Color.green;
        }
        else if (currentD < 1.5f )
        {
            multipier = 2f;
            Fill.color = Color.red;
        }
        else // for when its less than 2.5 but more than 1.5
        {
            multipier = 1f;
            Fill.color = Color.yellow;
        }
       
        level.text = currentD + " m";
    }
    public void changeDistance(float changedD)
    {
        if (currentD + changedD > 3.5f)
        {
            currentD = 3.5f;
        }
        else if (currentD + changedD < 1.5f)
        {
            currentD = 1.5f;
        }
        else
        {
            currentD += changedD;
        }


    }
    public void setD(float changedD)
    {
        maxD = changedD;
    }
    public void setcurrentD(float changedD)
    {
        currentD = changedD;
    }
}
