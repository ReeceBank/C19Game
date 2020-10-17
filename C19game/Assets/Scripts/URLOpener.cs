using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class URLOpener : MonoBehaviour
{
    // Start is called before the first frame update
    /*
     * Opens link to sa corona virus website
     */
    public void OpenURL()
    {
        Application.OpenURL("https://sacoronavirus.co.za/");
    }
}
