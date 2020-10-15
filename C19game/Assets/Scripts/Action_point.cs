using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_point : MonoBehaviour
{

    public int points;
    public Image AP_image;

    [SerializeField]
    public Text text;
    // Start is called before the first frame update
    void Awake()
    {
        points = 3;
        AP_image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = points + "/3";
    }

    public int get()
    {
        return points;
    }

    public void reduce()
    {
        points--;
    }

    public void reset_points()
    {
        points = 3;
    }

}
