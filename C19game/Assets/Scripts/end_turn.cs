using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class end_turn : MonoBehaviour
{
    //ai brain, what determines what cards do what, for the enemy
    public AiBrain aiBrain;
    //Sceneloader
    public SceneLoader endscene;
    // Player general card objects  --------- remove
    public GameObject Mask;
    public GameObject Sanitizer;
    public GameObject Iron;
    public GameObject WashM;
    public GameObject WashH;
    public GameObject ShoppingCart;
    public GameObject avoid_crowd;
    public GameObject Bed_apart;

    //reeces new cards:
    public GameObject CallAhead;
    public GameObject CoveredSneeze;
    public GameObject DishwashingLiquid;
    public GameObject FaceMask;
    public GameObject GoodHygene;
    public GameObject HandSanitiser;
    public GameObject HospitalVisit;
    public GameObject PhysicalDistance;
    public GameObject SoapWash1;
    public GameObject SoapWash2;
    public GameObject SoapWash3;
    public GameObject ThinkOfTheChildren;
    public GameObject WashDryIron;

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
    //all core game sliders
    public HealthBarController healthBar;
    public Social_D social_D;
    public ROI_Bar roi;

    public int enemyCardNum;
    public int cardIndex;
    //enemy and player decks
    List<GameObject> deck = new List<GameObject>();
    List<GameObject> enemyDeck = new List<GameObject>();

    List<GameObject> enemyCards = new List<GameObject>();
    List<GameObject> enemyCardBack = new List<GameObject>();
    void Start()
    {
        //get the scene name
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);

        if (scene.name.Contains("ShoppingLevel"))
        {
            //add shopping related cards
            ShoppingCart.name = "Shop";
            //deck.Add(ShoppingCart);
        }
        if (scene.name.Contains("QuarantineLevel"))
        {
            //add quaratine related cards
            Bed_apart.name = "Bed";
            deck.Add(Bed_apart);
        }
        if (scene.name.Contains("SchoolLevel"))
        {

        }


        //gets the brain script from the brain object
        aiBrain = GameObject.Find("AiBrain").GetComponent<AiBrain>();

        //set player card IDs --------- remove
        Mask.name = "Mask";
        Sanitizer.name = "Sanitizer";
        WashH.name = "Wash_H";
        WashM.name = "Wash_M";
        Iron.name = "Iron";

        //set reeces cards:
        loadupDeckGeneral();

        //adds user cards to a deck ------- remove
        /*
        deck.Add(Mask);
        deck.Add(Sanitizer);
        deck.Add(Iron);
        deck.Add(WashM);
        deck.Add(WashH);
        */
        //add reeces cards to the deck

        //set enemy card ID
        dirty.name = "dirtyCart";
        ignorant.name = "Ignorant";
        itchy.name = "Itchy";
        unclean.name = "UncleanedSurface";
        unwashed.name = "unwashedMask";
        cardBack.name = "cardback";

        //adds enemy cards to a deck
        
        enemyDeck.Add(dirty);
        enemyDeck.Add(ignorant); 
        enemyDeck.Add(itchy); 
        enemyDeck.Add(unclean); 
        enemyDeck.Add(unwashed);
        

        cards = GameObject.FindGameObjectsWithTag("Card");

        //create the grey boxes (which stop the player from draging cards they shouldnt
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

        //disable end turn button during enemy turn
        GameObject endturn = GameObject.Find("EndTurnButton");
        Button buttn = endturn.GetComponent<Button>();
        buttn.interactable = false;

        //disable the player area
        Grey_playerarea.SetActive(true);
        //Grey_enemyarea.SetActive(false);

        //destory a card in the hand so it looks like a card is played
        Destroy(enemyCardBack[enemyCardNum]);
        //Waits to display the enemy card for 3 seconds
        yield return new WaitForSeconds(3);
        
        //Then destroys said enemy card after its been shown
        Destroy(zoomCard);


        //Finds the Hp bar -------------------------------------------------------------(ROI and SocialDistansce need to still go here
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        roi = GameObject.Find("SliderROI").GetComponent<ROI_Bar>();
        social_D = GameObject.Find("Social_D").GetComponent<Social_D>();
        float multiplier = social_D.multipier; //multiplier on effects (changes depending on distance)

        //enemy plays
        //when a specific card is played it affects the system differently
        //pass the brain a game object
        aiBrain.playEffect(enemyCards[enemyCardNum]);

        //wait for 0.5 more seconds so the player can see their changed stats
        yield return new WaitForSeconds(0.5f);

        //detroy a card in enemy hand and in their deck, since its been played
        Destroy(enemyCards[enemyCardNum]);


        //decrement enemy card number. This determins how many card the enemy plays. is set in the editor slider.
        if (enemyCardNum +1 > 0)
        {
            enemyCardNum--;
        }

        Score_counter.card_score += 20;
        Score_counter.dist = social_D.currentD;
        Score_counter.ROI = roi.currentROI;
        Score_counter.hp = healthBar.currentHealth;

        //enable the playerarea, so player can play cards again
        Grey_playerarea.SetActive(false);

        //enable endturn button
        buttn.interactable = true;
        Action_point AP = GameObject.Find("Action_points").GetComponent<Action_point>();
        AP.reset_points();

        //win condition 
        if (enemyCardNum +1== 0)
        {
            endscene.LoadWin();
        }
    }
    //method to load up the player deck with general cards. You will have to define them in constructors first.
    public void loadupDeckGeneral()
    {
        CallAhead.name = "CallAhead";
        CoveredSneeze.name = "CoveredSneeze";
        DishwashingLiquid.name = "DishwashingLiquid";
        FaceMask.name = "FaceMask";
        GoodHygene.name = "GoodHygene";
        HandSanitiser.name = "HandSanitiser";
        HospitalVisit.name = "HospitalVisit";
        PhysicalDistance.name = "PhysicalDistance";
        SoapWash1.name = "SoapWash1";

        //soap2 and soap3 are spawn tokens of soap1 and then soap2 respectivly. its a progressive chain
        SoapWash2.name = "SoapWash2";
        SoapWash3.name = "SoapWash3";

        ThinkOfTheChildren.name = "ThinkOfTheChildren";
        WashDryIron.name = "WashDryIron";

        deck.Add(CallAhead);        
        deck.Add(CoveredSneeze);
        deck.Add(DishwashingLiquid);
        deck.Add(FaceMask);
        deck.Add(GoodHygene);
        deck.Add(HandSanitiser);
        deck.Add(HospitalVisit);
        deck.Add(PhysicalDistance);
        deck.Add(SoapWash1);
        deck.Add(Sanitizer);
        deck.Add(ThinkOfTheChildren);
        deck.Add(WashDryIron);
    }

}
