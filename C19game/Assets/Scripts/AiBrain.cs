using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrain : MonoBehaviour
{

    public HealthBarController healthBar;
    public Social_D social_D;
    public ROI_Bar roi;
    // Start is called before the first frame update
    void Start()
    {
        //find all 3 main bars
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        roi = GameObject.Find("SliderROI").GetComponent<ROI_Bar>();
        social_D = GameObject.Find("Social_D").GetComponent<Social_D>();
    }

    
    //this method takes a game object. is meant to be used in the shopping level
    public void playEffect(GameObject gameObject)
    {
        if (gameObject.name.Contains("AsymptomaticCarrier"))
        {
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("ChestPain"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI(5);
        }

        else if (gameObject.name.Contains("DifficultyBreathing"))
        {
            roi.changeROI(5);
        }

        else if (gameObject.name.Contains("ItchyFace"))
        {
            roi.changeROI(10);
        }

        else if (gameObject.name.Contains("MinorSymptoms"))
        {
            roi.changeROI(5);
        }
        else if (gameObject.name.Contains("StrangeFever"))
        {
            roi.changeROI(5);
        }

        else if (gameObject.name.Contains("UncleanSurface"))
        {
            roi.changeROI(5);
        }

        else if (gameObject.name.Contains("UnderlyingConditions"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("Boredom"))
        {
            healthBar.changeHealth(-10);
        }
        else if (gameObject.name.Contains("CrowdedHallways"))
        {            
            roi.changeROI(10);
            social_D.changeDistance(-1);
        }
        else if (gameObject.name.Contains("IgnorantCustomer"))
        {

            roi.changeROI(10);
            social_D.changeDistance(-1f);
        }
        else if (gameObject.name.Contains("TP"))
        {

        }
    }
    //this method takes a game object. is meant to be used in the self isolation level
    public void playSelfEffect(GameObject gameObject)
    {

    }
    //this method takes a game object. is meant to be used in the school level
    public void playSchoolEffect(GameObject gameObject)
    {

    }
}
