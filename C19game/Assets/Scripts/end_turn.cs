using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_turn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mask;
    public GameObject Sanitizer;
    public GameObject Iron;
    public GameObject WashM;
    public GameObject WashH;
    public GameObject ShoppingCart;
    public GameObject PlayerArea;
    public GameObject[] cards;

    List<GameObject> deck = new List<GameObject>();


    void Start()
    {
        deck.Add(Mask);
        deck.Add(Sanitizer);
        deck.Add(Iron);
        deck.Add(WashM);
        deck.Add(WashM);
        deck.Add(ShoppingCart);

        cards = GameObject.FindGameObjectsWithTag("Card");
        for (var i = cards.Length; i < 4; i++)
        {

            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

        }

    }

    public void Click()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
        for(var i = cards.Length ; i< 4; i++)
        {
            
            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
