using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeCards : MonoBehaviour
{
    //corona symptoms cards
    public GameObject fever;
    public GameObject fatigue;
    public GameObject cough;

    //fine symptom cards
    public GameObject fine;

    //other symptoms cards
    public GameObject hair;
    public GameObject feet;
    public GameObject thirst;

    public GameObject cardDisplay;

    //variable to log if corona symptomatic
    public bool coronaSymptomatic;

    List<GameObject> deck = new List<GameObject>();

    /*
     * populates a symptom ard deck, randomly displays 3 cards and ...
     * ...assigns each card a value indicating whether they are a coronavirus symptom card
     */
    void Awake()
    {
        //add cards to deck
        deck.Add(fever);
        deck.Add(fatigue);
        deck.Add(cough);
        deck.Add(fine);
        deck.Add(hair);
        deck.Add(feet);
        deck.Add(thirst);

        //generate a random card in a card space
        for (var i = 0; i < 1; i++)
        {
            int index = Random.Range(0, deck.Count);

            //if the index is 0,1 or 2 then its a corona virus symptom
            if (index == 0)
            {
                coronaSymptomatic = true;
            }

            else if (index==1)
            {
                coronaSymptomatic = true;
            }

            else if (index==2)
            {
                coronaSymptomatic = true;
            }

            //if the index is any other number then not coronavirus symptomatic
            else {
                coronaSymptomatic = false;
            }

            //place card
            GameObject symptomCard = Instantiate(deck[index], new Vector3(0, 0, 0), Quaternion.identity);
            symptomCard.transform.SetParent(cardDisplay.transform, false);

        }
    }
}
