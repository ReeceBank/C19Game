using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_slide : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;
    public GameObject panel11;

    public int i;

    List<GameObject> panelList = new List<GameObject>();
    List<GameObject> otherPanelList = new List<GameObject>();

    /*
     * moves to the next panel
     */
    public void openNextPanel()
    {
        //adds panels to a list
        panelList.Add(panel1);
        panelList.Add(panel2);
        panelList.Add(panel3);
        panelList.Add(panel4);
        panelList.Add(panel5);
        panelList.Add(panel6);
        panelList.Add(panel7);
        panelList.Add(panel8);
        panelList.Add(panel9);
        panelList.Add(panel10);
        panelList.Add(panel11);

        GameObject panel;
        int listSize = panelList.Count;

        //makes next panel appear
        if (i < listSize)
        {
            panel = panelList[i];

            if (panel != null)
            {
                panel.SetActive(true);
                panelList[i - 1].SetActive(false);
            }
        }

    }

    /*
     * moves to a previous panel
     */
    public void openPreviousPanel()
    {
        //add panels to a list
        otherPanelList.Add(panel1);
        otherPanelList.Add(panel2);
        otherPanelList.Add(panel3);
        otherPanelList.Add(panel4);
        otherPanelList.Add(panel5);
        otherPanelList.Add(panel6);
        otherPanelList.Add(panel7);
        otherPanelList.Add(panel8);
        otherPanelList.Add(panel9);
        otherPanelList.Add(panel10);
        otherPanelList.Add(panel11);

        //list of panels
        int listSize = otherPanelList.Count;

        //panels to move to and move from
         GameObject prev_panel = otherPanelList[i-2];
         GameObject current_panel = otherPanelList[i-1];

         if (current_panel != null)
         {
            current_panel.SetActive(false);
            prev_panel.SetActive(true);
         }
    }
}
