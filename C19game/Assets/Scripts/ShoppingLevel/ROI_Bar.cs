using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROI_Bar : MonoBehaviour
{
    public Slider ROI;
    public HealthBarController healthBar;
    public int currentROI = 15;
    public int maxROI = 30;

    [SerializeField]
    public Text level;

    /*
     * get and set the ROI slider
     * get and set the healthbar slider
     */
    void Awake()
    {
        ROI = GetComponent<Slider>();
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
    }

    /*
     * gets current risk of infection value
     * sets text on slidere based on current value
     */
    void Update()
    {

        ROI.value = currentROI;
        ROI.maxValue = maxROI;
        
        if (currentROI >= 20)
        {
            level.text = "HIGH!!!";
        }
        if (currentROI <= 19 && currentROI >= 10)
        {
            level.text = "MEDIUM";
        }
        if (currentROI <= 9)
        {
            level.text = "LOW";
        }

    }
    /*
     * Determines the current ROI value
     * affects health bar if value too high
     */
    public void changeROI(int dHP)
    {
        //when the players risk of infection is at maxiumum, the player takes hp damage when they take more ROI damage
        if (currentROI + dHP > 30)
        {
            currentROI = 30;
            healthBar.changeHealth(-10);
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

    /*
     * set maximum risk of infection value
     */
    public void setMaxROI(int maxHP)
    {
        maxROI = maxHP;
    }

    /*
     *set current risk of infection value 
     */
    public void setCurrentROI(int currentHP)
    {
        currentROI = currentHP;
    }
}
