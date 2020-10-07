using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickNo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
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
        bool result = valueOne || valueTwo || valueThree;

        if (result)
        {
            Debug.Log("WRONG!!!!!!!!!!");
        }
        else
        {
            Debug.Log("CORRECT");
        }
    }
}
