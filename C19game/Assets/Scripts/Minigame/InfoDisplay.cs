using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    bool active;
    GameObject infotext;

    /*
     * finds information and makes it invisible 
     */
    private void Start()
    {
        active = true;
        infotext = GameObject.Find("InfoFooter");
        infotext.SetActive(false);
    }

    /*
     * On click will display/hide information
     */
    public void InfoClick()
    {
        infotext.SetActive(active);
        active = !(active);
    }
}
