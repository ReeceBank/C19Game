using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Zoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject zoomCard;
    private bool click = false;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnholdEnter()
    {
        
        zoomCard = Instantiate(gameObject, new Vector2(400, 1280 / 2 + 200), Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(600, 900);
        

    }

    public void OnholdExit()
    {
        
        Destroy(zoomCard);        
    }
}
