﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score_controller : MonoBehaviour
{


    public string input_name ;
    public int score;
    GameObject inputFieldGo;
    InputField inputFieldCo;
    public TextMeshProUGUI score_txt;
    
    // Start is called before the first frame update
    void Awake()
    {
        //set the score value
        try
        {
            score = 0;
            float temp = (Score_counter.card_score + Score_counter.hp * 100 + Score_counter.ROI * 50 + Score_counter.dist * 100) * Score_counter.diff_multi ;
            score = (int)temp;
            score_txt = GetComponent<TextMeshProUGUI>();
            score_txt.text = "" + score;
        }
        catch
        {

        }
        //get input field
        inputFieldGo = GameObject.Find("Name_field");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        input_name = inputFieldCo.text.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        input_name = inputFieldCo.text.ToString();
        //Debug.Log(input_name);
    }

    // add the score to the leaderboard
    // now adds 9999 temp
    public void Add()
    {
        Save(score, input_name);
        SceneManager.LoadScene("Leaderboard");
    }

    //method to save score
    public void Save(int score, string name)
    {
        Entry entry = new Entry { score = score, name = name };

        string jsonString;
        Scores scores;
        //check for a json file
        // if it doesnt exist create one
        if (PlayerPrefs.GetString("table") == "") 
        {
            List<Entry> temp = new List<Entry>();

            temp.Add(entry);
            string tmp = JsonUtility.ToJson(temp);
            PlayerPrefs.SetString("table", tmp);
            PlayerPrefs.Save();
        }

        //add the score
        jsonString = PlayerPrefs.GetString("table");
        scores = JsonUtility.FromJson<Scores>(jsonString);
        scores.entries.Add(entry);

        //sort the list
        for (int i = 0; i < scores.entries.Count; i++)
        {
            for (int j = i + 1; j < scores.entries.Count; j++)
            {
                if (scores.entries[j].score >= scores.entries[i].score)
                {
                    Entry tmp = scores.entries[i];
                    scores.entries[i] = scores.entries[j];
                    scores.entries[j] = tmp;
                }
            }
        }
        if (scores.entries.Count > 10)
        {
            scores.entries.RemoveRange(10, scores.entries.Count - 10);
        }

        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("table", json);
        PlayerPrefs.Save();

    }

    // a entry class
    [System.Serializable]
    public class Entry
    {
        public int score;
        public string name;

    }

    // a class to store entries
    public class Scores
    {
        public List<Entry> entries;
    }
}
