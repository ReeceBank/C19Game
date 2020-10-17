using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragdrop : MonoBehaviour
{
    //private  endTurn;
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


    /*
     * gets and sets infection slider, risk of infection slider, social distance slider and action points
     */
    private void Awake()
    {
        //endTurn = GameObject.Find("EndTurnButton").GetComponent<end_turn>;
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

    //deals with cards collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        overzone = true;
        dropzone = collision.gameObject;
    }

    //gets the start of the card drag
    public void startDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDrag = true;
    }

    /*
     * handles end of drag events, such as card plays
     */
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

    /*
    * code the effects of cards played
    */
    //these are the general player cards. these cards can have synergy
    public void playeffect()
    {
        if (gameObject.name.Contains("CallAhead"))
        {
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("CoveredSneeze"))
        {
            //unclean hands
            if (BuffEffects.cleanHands == true) // your hands are now filthy since you sneezed and need to wash.
            {
                BuffEffects.cleanHands = false;
            }
            //covered sneeze
            if (BuffEffects.coveredSneeze == false) //covered sneeze toggle to make synergy
            {
                BuffEffects.coveredSneeze = true;
            }
            roi.changeROI(-10);
            social_D.changeDistance(+0.5f);
        }
        else if(gameObject.name.Contains("DishwashingLiquid"))
        {
            //cleans hands
            if(BuffEffects.cleanHands == false)
            {
                BuffEffects.cleanHands = true;
            }

            //synergy with coveredsneeze cards
            if (BuffEffects.coveredSneeze == true) //covered sneeze synergises with handwashing
            {
                roi.changeROI(-5);
            }
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("FaceMask"))
        {
            if (BuffEffects.faceMask == false)
            {
                BuffEffects.faceMask = true;
            }
            roi.changeROI(-10);
        }
        else if (gameObject.name.Contains("GoodHygene"))
        {
            //cleans hands
            if (BuffEffects.cleanHands == false)
            {
                BuffEffects.cleanHands = true;
            }

            //synergy with coveredsneeze cards
            if (BuffEffects.coveredSneeze == true) //covered sneeze synergises with handwashing
            {
                roi.changeROI(-5);
            }
            roi.changeROI(-5);
        }
        else if (gameObject.name.Contains("HandSanitiser"))
        {
            //cleans hands
            if (BuffEffects.cleanHands == false)
            {
                BuffEffects.cleanHands = true;
            }
            //synergy with coveredsneeze cards
            if (BuffEffects.coveredSneeze == true) //covered sneeze synergises with handwashing
            {
                roi.changeROI(-5);
            }
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
            SoapProgress.soap1Played = true;
        }
        else if (gameObject.name.Contains("SoapWash2"))
        {
            SoapProgress.soap2Played = true;
        }
        else if (gameObject.name.Contains("SoapWash3"))
        {
            roi.changeROI(-25);
        }
        else if (gameObject.name.Contains("ThinkOfTheChildren"))
        {
            healthBar.changeHealth(+5);
            roi.changeROI(-5);
            social_D.changeDistance(+0.5f);
        }
        else if (gameObject.name.Contains("WashDryIron"))
        {

            if (BuffEffects.faceMask)
            {
                healthBar.changeHealth(+10);
                roi.changeROI(-5);
                BuffEffects.faceMask = false;
            }
        }

        //these are the level specific uniques, they dont have synergy
        switch (gameObject.name.Substring(0,gameObject.name.Length - 7))
        {
            case "Shop":
                social_D.changeDistance(+1);
                break;
            case "WipeDown": //wipedown is *techinically* a hand wash so i made it clean hands just for fun hidden synergy
                if(BuffEffects.cleanHands == false) { BuffEffects.cleanHands = true; }
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
                social_D.changeDistance(+1f);
                break;
            case "WhenToWorry": //this card is actually a bad card that can fill you hand. adds variety.
                roi.changeROI(5);
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
