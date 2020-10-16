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

    /*
     * Gets social distance slider and sets a multiplier value
     */
    void Awake()
    {
        SD = GetComponent<Slider>();
        multipier = 1f;
    }

    /*
     * gets the user social distance value an...
     * ...multiplies card effects accordingly
     */
    void Update()
    {

        SD.value = currentD;
        SD.maxValue = maxD;

        if (currentD >= 2.5f)
        {
            //makes all card have normal level of effects when at more than 2.5m
            multipier = 1f;
            Fill.color = Color.green;
        }
        else if (currentD < 1.5f )
        {
            //makes all cards have stronger effects when at or below 1.5m, pretty much will get covid if you get to 1.5m
            multipier = 3f;
            Fill.color = Color.red;
        }
        else // for when its less than 2.5 but more than 1.0
        {
            //makes all cards have normal level of effects when between 2.5 and 1.0
            multipier = 1f;
            Fill.color = Color.yellow;
        }
       
        level.text = currentD + " m";
    }

    /*
     * Changes the social distance value
     */
    public void changeDistance(float changedD)
    {
        if (currentD + changedD > 3.5f)
        {
            currentD = 3.5f;
        }
        else if (currentD + changedD < 1.0f)
        {
            currentD = 1.0f;
        }
        else
        {
            currentD += changedD;
        }


    }

    /*
     * multiplier by which we multiply card effects
     */
    public int multiply(int value)
    {
        return (int)(multipier * value);
    }

    /*
     * Sets max distance
     */
    public void setD(float changedD)
    {
        maxD = changedD;
    }

    /*
     * sets surrecnt distance
     */
    public void setcurrentD(float changedD)
    {
        currentD = changedD;
    }
}
