using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    bool active;
    GameObject infotext;
    private void Start()
    {
        active = true;
        infotext = GameObject.Find("InfoFooter");
        infotext.SetActive(false);
    }

    public void InfoClick()
    {
        infotext.SetActive(active);
        active = !(active);
    }
}
