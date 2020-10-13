using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickLogic : MonoBehaviour
{
    public SceneLoader sceneLoader;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.Find("SceneSwitch").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    //determines click logic for each button to half script size
    public void YesClick()
    {
        if (GetResult()) //calls above function to see if button clicked is Yes
        {
            Debug.Log("CORRECT!");
            //ph moves to shop level if correct
            sceneLoader.LoadOneForward();
        }
        else
        {
            Debug.Log("WRONG!!!!!!!!");
            //ph moves to info scene if wrong
            sceneLoader.LoadInfoScene();
        }

    }

    public void NoClick() //inverse logic for when the button clicked is No
    {
        if (!GetResult())
        {
            Debug.Log("CORRECT!");
            //ph moves to shop level if correct
            sceneLoader.LoadOneForward();
        }
        else
        {
            Debug.Log("WRONG!!!!!!!!");
            //ph moves to info scene if wrong
            sceneLoader.LoadInfoScene();
        }

    }
}
