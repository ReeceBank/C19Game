using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickLogic : MonoBehaviour
{
    public SceneLoader sceneLoader;
    
    /* 
     * The start method find the SceneSwitch game object and assigned it to the sceneLoader variable
     */
    void Start()
    {
        sceneLoader = GameObject.Find("SceneSwitch").GetComponent<SceneLoader>();
    }

    /*
     * Determines the whether cars displayed represent a covid symptomatic person
     */
    public bool GetResult()
    {
        //access the boolean values of each card presented
        GameObject cardAreaOne = GameObject.Find("symptomOne");
        placeCards cardPlayedOne = cardAreaOne.GetComponent<placeCards>();
        bool valueOne = cardPlayedOne.coronaSymptomatic;

        GameObject cardAreaTwo = GameObject.Find("symptomTwo");
        placeCards cardPlayedTwo = cardAreaTwo.GetComponent<placeCards>();
        bool valueTwo = cardPlayedTwo.coronaSymptomatic;

        GameObject cardAreaThree = GameObject.Find("SymptomThree");
        placeCards cardPlayedThree = cardAreaThree.GetComponent<placeCards>();
        bool valueThree = cardPlayedThree.coronaSymptomatic;

        //logic operation to determine correctness of answer
        bool result = (valueOne || valueTwo || valueThree);
        return result;

    }

    /*
     * When the yes button is clicked, get correctness evauluation
     * Takes user to game screen if correct and info screen if incorrect
     */
    public void YesClick()
    {
        if (GetResult()) //calls above function to see if button clicked is Yes
        {
            //moves to shop level if correct
            sceneLoader.LoadOneForward();
        }
        else
        {
            //moves to info scene if wrong
            sceneLoader.LoadInfoScene();
        }

    }

    /*
     * When the no button is clicked, get correctness evauluation
     * Takes user to game screen if correct and info screen if incorrect
     */
    public void NoClick()
    {
        if (!GetResult())
        {
            //moves to shop level if correct
            sceneLoader.LoadOneForward();
        }
        else
        {
            //moves to info scene if wrong
            sceneLoader.LoadInfoScene();
        }

    }
}
