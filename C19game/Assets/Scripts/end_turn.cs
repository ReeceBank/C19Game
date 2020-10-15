using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class end_turn : MonoBehaviour
{
    // Player card objects
    public GameObject Mask;
    public GameObject Sanitizer;
    public GameObject Iron;
    public GameObject WashM;
    public GameObject WashH;
    public GameObject ShoppingCart;

    //enemy card objects
    public GameObject dirty;
    public GameObject ignorant;
    public GameObject itchy;
    public GameObject unclean;
    public GameObject unwashed;
    public GameObject cardBack;

    //enemy and player playing area
    public GameObject PlayerArea;
    public GameObject EnemyArea;

    public GameObject Grey_playerarea;
    public GameObject Grey_enemyarea;

    public GameObject[] cards;
    public HealthBarController healthBar;

    public int enemyCardNum;
    public int cardIndex;
    //enemy and player decks
    List<GameObject> deck = new List<GameObject>();
    List<GameObject> enemyDeck = new List<GameObject>();

    List<GameObject> enemyCards = new List<GameObject>();
    List<GameObject> enemyCardBack = new List<GameObject>();
    void Start()
    {
        //get player card IDs
        Mask.name = "Mask";
        Sanitizer.name = "Sanitizer";
        ShoppingCart.name = "Shop";
        WashH.name = "Wash_H";
        WashM.name = "Wash_M";
        Iron.name = "Iron";

        //adds user cards to a deck
        deck.Add(Mask);
        deck.Add(Sanitizer);
        deck.Add(Iron);
        deck.Add(WashM);
        deck.Add(WashH);
        deck.Add(ShoppingCart);

        //adds enemy cards to a deck
        enemyDeck.Add(dirty);
        enemyDeck.Add(ignorant); 
        enemyDeck.Add(itchy); 
        enemyDeck.Add(unclean); 
        enemyDeck.Add(unwashed);


        cards = GameObject.FindGameObjectsWithTag("Card");

        //create the grey boxes 
        Grey_enemyarea = GameObject.Find("Grey_enemyarea");

        Grey_playerarea = GameObject.Find("Grey_playerarea");
        Grey_playerarea.SetActive(false);

        //fill enemy hand with cards
        for (var i = 0; i < 4; i++)
        {
            GameObject enemyCard = Instantiate(enemyDeck[Random.Range(0, enemyDeck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            GameObject enemyCardBacks = Instantiate(cardBack, new Vector3(0, 0, 0), Quaternion.identity);
            enemyCardBacks.transform.SetParent(EnemyArea.transform, false);

            enemyCards.Add(enemyCard);
            enemyCardBack.Add(enemyCardBacks);
        }

        //fill player hand with cards
        for (var i = 0 ; i < 4; i++)
        {
            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);

        }

    }

    public void Click()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");

        //on click the user recieves a new card
        for(var i = cards.Length ; i< 4; i++)
        {
            
            GameObject playerCard = Instantiate(deck[Random.Range(0, deck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);
            
        }

        //and enemy plays a card
        StartCoroutine(Enemy_Play_with_Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Enemy_Play_with_Delay()
    {
        // Code before the pause

        //create a zoomed card
        GameObject zoomCard = Instantiate(enemyCards[enemyCardNum], new Vector3(0, 0, 0), Quaternion.identity);
        zoomCard.transform.SetParent(GameObject.Find("Zoom Area").transform, false);
        zoomCard.name = "Zoom_card";
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(600, 900);

        //disable end turn button
        GameObject endturn = GameObject.Find("EndTurnButton");
        Button buttn = endturn.GetComponent<Button>();
        buttn.interactable = false;

        //disable the player area
        Grey_playerarea.SetActive(true);
        Grey_enemyarea.SetActive(false);

        yield return new WaitForSeconds(3); // Wait or a number of seconds
        
        // Code after the pause
        Destroy(zoomCard); // destroy zoomed card

        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();

        //enemy plays
        //when a specific card is played it affects the system differently
        if (enemyCards[enemyCardNum].name.Contains("dirtyCart"))
        {
            healthBar.changeHealth(-5);
        }

        else if (enemyCards[enemyCardNum].name.Contains("Ignorant"))
        {
            healthBar.changeHealth(-5);
        }

        else if (enemyCards[enemyCardNum].name.Contains("Itchy"))
        {
            healthBar.changeHealth(-10);
        }

        else if (enemyCards[enemyCardNum].name.Contains("UncleanedSurface"))
        {
            healthBar.changeHealth(-5);
        }

        else if (enemyCards[enemyCardNum].name.Contains("unwashedMask"))
        {
            healthBar.changeHealth(-10);
        }
        
        //detroy card in enemy hand
        Destroy(enemyCards[enemyCardNum]);
        Destroy(enemyCardBack[enemyCardNum]);
        //decrement enemy card number
        if (enemyCardNum > 0)
        {
            enemyCardNum--;
        }

        //enable the playerarea
        Grey_playerarea.SetActive(false);
        Grey_enemyarea.SetActive(true);

        //enable endturn button
        buttn.interactable = true;

    }

}
