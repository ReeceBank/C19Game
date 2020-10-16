using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    [SerializeField]
    public Text share_text;

    /*
     * on click we get error message
     */
    public void click()
    {
        StartCoroutine(Error_message());
    }

    /*
     *display error message 
     */
    IEnumerator Error_message()
    {
        share_text.text = "GooglePlay login Failed";
        yield return new WaitForSeconds(3);
        share_text.text = "";
    }
}
