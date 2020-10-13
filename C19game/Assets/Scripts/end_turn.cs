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

    public GameObject dirty;
    public GameObject ignorant;
    public GameObject itchy;
    public GameObject unclean;
    public GameObject unwashed;

    public GameObject PlayerArea;
    public GameObject EnemyArea;

    public GameObject[] cards;
    public HealthBarController healthBar;

    public int enemyCardNum;
    List<GameObject> deck = new List<GameObject>();
    List<GameObject> enemyDeck = new List<GameObject>();

    List<GameObject> enemyCards = new List<GameObject>();

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

        enemyDeck.Add(dirty);
        enemyDeck.Add(ignorant); 
        enemyDeck.Add(itchy); 
        enemyDeck.Add(unclean); 
        enemyDeck.Add(unwashed);


        cards = GameObject.FindGameObjectsWithTag("Card");

        for (var i = 0; i < 4; i++)
        {
            GameObject enemyCard = Instantiate(enemyDeck[Random.Range(0, enemyDeck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyArea.transform, false);

            enemyCards.Add(enemyCard);
        }

        for (var i = 0 ; i < 4; i++)
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

       
        Destroy(enemyCards[enemyCardNum]);
        if(enemyCardNum > 0)
        {
            enemyCardNum--;
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
