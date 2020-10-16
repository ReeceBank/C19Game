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
        if (gameObject.name.Contains("dirtyCart"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("Ignorant"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("Itchy"))
        {
            healthBar.changeHealth(-10);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("UncleanedSurface"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("unwashedMask"))
        {
            healthBar.changeHealth(-10);
            roi.changeROI(5);
            social_D.changeDistance(-0.5f);
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
