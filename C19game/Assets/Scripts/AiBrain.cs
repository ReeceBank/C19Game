using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBrain : MonoBehaviour
{

    public HealthBarController healthBar;
    public Social_D social_D;
    public ROI_Bar roi;
    private float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        //find all 3 main bars
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        roi = GameObject.Find("SliderROI").GetComponent<ROI_Bar>();
        social_D = GameObject.Find("Social_D").GetComponent<Social_D>();
        multiplier = social_D.multipier; //multiplier on effects (changes depending on distance)
    }
    private void Update()
    {
        multiplier = social_D.multipier;
    }


    //this method takes a game object. is meant to be used in the shopping level
    public void playEffect(GameObject gameObject)
    {
        if (gameObject.name.Contains("AsymptomaticCarrier"))
        {
            
            roi.changeROI((int)(10 * multiplier));
            social_D.changeDistance(-0.5f);
        }

        else if (gameObject.name.Contains("ChestPain"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI((int)(5 * multiplier));
        }

        else if (gameObject.name.Contains("DifficultyBreathing"))
        {
            roi.changeROI((int)(15 * multiplier));
        }

        else if (gameObject.name.Contains("ItchyFace"))
        {
            if (BuffEffects.faceMask == true)
            {
                BuffEffects.faceMask = false;
            }
            roi.changeROI((int)(10 * multiplier));
        }

        else if (gameObject.name.Contains("MinorSymptoms"))
        {
            roi.changeROI((int)(5 * multiplier));
        }
        else if (gameObject.name.Contains("StrangeFever"))
        {
            roi.changeROI((int)(10 * multiplier));
        }

        else if (gameObject.name.Contains("UncleanSurface"))
        {
            if(BuffEffects.faceMask == true) // must not put on a facemask with unclean hands
            {
                BuffEffects.faceMask = false;
            }
            if (BuffEffects.cleanHands == true) // your hands arnt clean
            {
                BuffEffects.cleanHands = false;
            }
            roi.changeROI(15);
        }

        else if (gameObject.name.Contains("UnderlyingConditions"))
        {
            healthBar.changeHealth(-5);
            roi.changeROI((int)(5 * multiplier));
            social_D.changeDistance(-0.5f);
        }

        //for the self isolation level
        else if (gameObject.name.Contains("Boredom"))
        {
            healthBar.changeHealth(-10);
        }

        //for the school level
        else if (gameObject.name.Contains("CrowdedHallways"))
        {            
            roi.changeROI((int)(15 * multiplier));
            social_D.changeDistance(-1);
        }

        //for the shop level
        else if (gameObject.name.Contains("IgnorantCustomer"))
        {
            roi.changeROI((int)(15 * multiplier));
            social_D.changeDistance(-1f);
        }
        else if (gameObject.name.Contains("TP"))
        {
            //because people hoarded TP at the start of the pandemic for no reason
        }
    }
}
