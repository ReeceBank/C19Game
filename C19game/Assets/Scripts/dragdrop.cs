using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragdrop : MonoBehaviour
{
    private GameObject canvas;
    private bool isDrag = false;
    private bool overzone = false;
    private GameObject dropzone;
    private Vector2 startPosition;
    private GameObject startParent;
    public HealthBarController healthBar;
    public Social_D social_D;
    public ROI_Bar roi;
    public Action_point AP;

    private void Awake()
    {
        canvas = GameObject.Find("Main Canvas");
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        roi = GameObject.Find("SliderROI").GetComponent<ROI_Bar>();
        social_D = GameObject.Find("Social_D").GetComponent<Social_D>();
        AP = GameObject.Find("Action_points").GetComponent<Action_point>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        overzone = true;
        dropzone = collision.gameObject;
    }

    public void startDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDrag = true;
    }

    public void endDrag()
    {
        isDrag = false;
        //if the card is above dropzone
        if (overzone && AP.get() > 0)
        {
            transform.SetParent(dropzone.transform, false);
            playeffect();
            AP.reduce();
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    public void playeffect()
    {
        /*
         * code the effects of cards played
         * */
        // just using +5 as a place holder
        if (gameObject.name.Contains("CallAhead"))
        {
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("CoveredSneeze"))
        {
            roi.changeROI(-10);
            social_D.changeDistance(+0.5f);
        }
        else if(gameObject.name.Contains("DishwashingLiquid"))
        {
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("FaceMask"))
        {
            roi.changeROI(-10);
        }
        else if (gameObject.name.Contains("GoodHygene"))
        {
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("HandSanitiser"))
        {
            roi.changeROI(-10);
        }
        else if (gameObject.name.Contains("HospitalVisit"))
        {
            healthBar.changeHealth(+5);
            social_D.changeDistance(+0.5f);
        }
        else if (gameObject.name.Contains("PhysicalDistance"))
        {
            social_D.changeDistance(+1);
        }
        else if (gameObject.name.Contains("SoapWash1"))
        {
            
        }
        else if (gameObject.name.Contains("SoapWash2"))
        {
            
        }
        else if (gameObject.name.Contains("SoapWash3"))
        {
            roi.changeROI(-15);
        }
        else if (gameObject.name.Contains("ThinkOfTheChildren"))
        {
            roi.changeROI(-5);
            social_D.changeDistance(+0.5f);
        }
        else if (gameObject.name.Contains("WashDryIron"))
        {
            
        }
        
        switch (gameObject.name.Substring(0,gameObject.name.Length - 7))
        {
            case "Shop":
                social_D.changeDistance(+1);
                break;
            case "WipeDown":
                roi.changeROI(-10);
                break;
            case "GoodVentilation":
                roi.changeROI(-5);
                social_D.changeDistance(+0.5f);
                break;
            case "OneKnifeOneForkOneSpoon":
                roi.changeROI(-10);
                break;
            case "PositiveEnergy":
                roi.changeROI(-5);
                social_D.changeDistance(+0.5f);
                break;
            case "SelfCheckup":
                roi.changeROI(-5);
                healthBar.changeHealth(+5);
                break;
            case "SelfIsolation":
                roi.changeROI(-5);
                social_D.changeDistance(+1);
                break;
            case "SleepApart":
                roi.changeROI(-5);
                social_D.changeDistance(+0.5f);
                break;
            case "WhenToWorry":
                roi.changeROI(-5);
                
                break;
            case "AvoidCrowds":
                roi.changeROI(-5);
                social_D.changeDistance(+1);
                break;
        }

        Score_counter.card_score += 10;
        Destroy(gameObject);
    }


    
}
