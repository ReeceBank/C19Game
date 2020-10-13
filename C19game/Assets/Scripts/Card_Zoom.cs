using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Zoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;

    public void Start()
    {
        Canvas = GameObject.Find("Zoom Area");

    }

    public void OnholdEnter()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        zoomCard = Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.name = "Zoom_card";
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

       RectTransform rect = zoomCard.GetComponent<RectTransform>();
       rect.sizeDelta = new Vector2(600, 900);
        
    }

    public void OnholdExit()
    {

        Destroy(zoomCard);
          

    }

}
