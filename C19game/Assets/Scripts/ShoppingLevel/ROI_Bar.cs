using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROI_Bar : MonoBehaviour
{
    public Slider ROI;
    public int currentROI = 0;
    public int maxROI = 30;

    [SerializeField]
    public Text level;

    void Awake()
    {
        ROI = GetComponent<Slider>();

    }
    void Update()
    {

        ROI.value = currentROI;
        ROI.maxValue = maxROI;
        
        if (currentROI >= 20)
        {
            level.text = "HIGH";
        }
        if (currentROI <= 19 && currentROI >= 10)
        {
            level.text = "MED";
        }
        if (currentROI <= 9)
        {
            level.text = "LOW";
        }

    }
    public void changeROI(int dHP)
    {
        if (currentROI + dHP > 30)
        {
            currentROI = 30;
            // do hp dmg

        }
        else if (currentROI + dHP < 0)
        {
            
            currentROI = 0;

            
        }
        else
        {
            currentROI += dHP;
        }


    }
    public void setMaxROI(int maxHP)
    {
        maxROI = maxHP;
    }
    public void setCurrentROI(int currentHP)
    {
        currentROI = currentHP;
    }
}
