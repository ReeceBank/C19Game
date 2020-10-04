using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class URLOpener : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenURL()
    {
        Application.OpenURL("https://sacoronavirus.co.za/");
    }
}
