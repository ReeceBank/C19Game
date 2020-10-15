using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{

    

    [SerializeField]
    public Text share_text;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        StartCoroutine(Error_message());
    }

    IEnumerator Error_message()
    {
        share_text.text = "GooglePlay login Failed";
        yield return new WaitForSeconds(3);
        share_text.text = "";
    }
}
