using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Zoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    //gets and sets canvas
    public void Start()
    {
        Canvas = GameObject.Find("Zoom Area");

    }

    //when the card is held, zoom in on the card
    public void OnholdEnter()
    {

        zoomCard = Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.name = "Zoom_card";
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

       RectTransform rect = zoomCard.GetComponent<RectTransform>();
       rect.sizeDelta = new Vector2(600, 900);
        
    }

    //detroyed zoomed card image when card is not held
    public void OnholdExit()
    {

        Destroy(zoomCard);
          

    }

}
