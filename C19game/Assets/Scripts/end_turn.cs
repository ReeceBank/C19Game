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
    public HealthBarController healthBar;


    List<GameObject> deck = new List<GameObject>();


    void Start()
    {
        Mask.name = "Mask";
        Sanitizer.name = "Sanitizer";
        ShoppingCart.name = "Shop";
        WashH.name = "Wash_H";
        WashM.name = "Wash_M";
        Iron.name = "Iron";
        deck.Add(Mask);
        deck.Add(Sanitizer);
        deck.Add(Iron);
        deck.Add(WashM);
        deck.Add(WashH);
        deck.Add(ShoppingCart);

        cards = GameObject.FindGameObjectsWithTag("Card");
        for (var i = cards.Length; i < 4; i++)
        {

            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

        }
        Debug.Log("The names of these three objects are " + Mask.name + Sanitizer.name);
    }

    public void Click()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
        for(var i = cards.Length ; i< 4; i++)
        {
            
            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            
        }

        //enemy plays
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        healthBar.changeHealth(-10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
