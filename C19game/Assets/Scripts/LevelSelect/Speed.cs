using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //if the player has chosen a speed then it defaults to their chosen speed
        if (PlayerPrefs.HasKey("Speed"))
        {
            StaticSpeed.speedmultiplier = PlayerPrefs.GetInt("speed");
        }
        //if the player hasnt chosen a speed then it defaults to 3 and saves it.
        else
        {
            StaticSpeed.speedmultiplier = 3;
            PlayerPrefs.SetInt("speed", 3);
            PlayerPrefs.Save();
        }
    }


    public void clickspeed1()
    {
        StaticSpeed.speedmultiplier = 1;
        PlayerPrefs.SetInt("speed", 1);
        PlayerPrefs.Save();
    }
    public void clickspeed3()
    {
        StaticSpeed.speedmultiplier = 3;
        PlayerPrefs.SetInt("speed", 3);
        PlayerPrefs.Save();
    }
    public void clickspeed6()
    {
        StaticSpeed.speedmultiplier = 6;
        PlayerPrefs.SetInt("speed", 6);
        PlayerPrefs.Save();
    }
}
