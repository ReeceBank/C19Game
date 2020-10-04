using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragdrop : MonoBehaviour
{
    private GameObject canvas;
    private bool isDrag = false;
    private bool overzone = false;
    private GameObject dropzone;
    private Vector2 startPosition;
    private GameObject startParent;
    private HealthBarController healthBar;

    //C edit

    private void Awake()
    {
        canvas = GameObject.Find("Main Canvas");
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        overzone = true;
        dropzone = collision.gameObject;
    }



    public void startDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDrag = true;
    }

    public void endDrag()
    {
        isDrag = false;
        //if the card is above dropzone
        if (overzone)
        {
            transform.SetParent(dropzone.transform, false);
            playeffect();
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }

    public void playeffect()
    {
        /*
         * code the effects of cards played
         * */
        healthBar.changeHealth(-1);
        Destroy(gameObject);
        //C edit
    }
    
}
