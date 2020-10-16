using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderboard : MonoBehaviour
{

    public Transform entryContainer;
    public Transform entryTemplate;
    public List<Entry> entryList;
    public List<Transform> transformList;


    public void Awake()
    {
        entryContainer = transform.Find("Container");
        entryTemplate = entryContainer.Find("Template");

        entryTemplate.gameObject.SetActive(false);



        Scores scores;
        //Check if the file exists

        if(PlayerPrefs.GetString("table") == "") // if it doesnt create one
        {


            entryList = new List<Entry>()
            {
            new Entry{score = 0, name = "---"},
            };

            scores = new Scores { entries = entryList };
            string json = JsonUtility.ToJson(scores);
            PlayerPrefs.SetString("table", json);
            PlayerPrefs.Save();
        }
        else
        {
            string jsonString = PlayerPrefs.GetString("table");
            //Debug.Log("exist");
            scores = JsonUtility.FromJson<Scores>(jsonString);
        }


        //sort the scores
        for (int i =0; i < scores.entries.Count; i++)
        {
            for(int j = i + 1; j < scores.entries.Count; j++)
            {
                if(scores.entries[j].score > scores.entries[i].score)
                {
                    Entry tmp = scores.entries[i];
                    scores.entries[i] = scores.entries[j];
                    scores.entries[j] = tmp;
                }
            }
        }



        
        //show only the top 10 scores    
        for(int i = 0; i < 10; i++)
        {
            CreateTransform(scores.entries[i], entryContainer, transformList);
        }

        /*
        transformList = new List<Transform>();
        foreach(Entry entry in tempList)
        {
            CreateTransform(entry, entryContainer, transformList);
        }*/



    }

    //display the scores
    public void CreateTransform(Entry entry, Transform container, List<Transform> list)
    {
        float templateHeight = 60f;


        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * list.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = list.Count + 1;
        string rankS;
        switch (rank)
        {
            default:
                rankS = rank + "th";
                break;

            case 1: rankS = "1st"; break;
            case 2: rankS = "2nd"; break;
            case 3: rankS = "3rd"; break;

        }
        entryTransform.Find("Pos_entry").GetComponent<Text>().text = rankS;

        int score = entry.score;

        entryTransform.Find("Score_entry").GetComponent<Text>().text = score + "";

        string name = entry.name;
        entryTransform.Find("Name_entry").GetComponent<Text>().text = "" + name;

        entryTransform.Find("back").gameObject.SetActive(rank % 2 == 1);

        list.Add(entryTransform);
    }

    //Add a score to the scores list
    public void AddScore(int score, string name)
    {
        Entry entry = new Entry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("table");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);

        scores.entries.Add(entry);

        //sort the list
        for (int i = 0; i < scores.entries.Count; i++)
        {
            for (int j = i + 1; j < scores.entries.Count; j++)
            {
                if (scores.entries[j].score > scores.entries[i].score)
                {
                    Entry tmp = scores.entries[i];
                    scores.entries[i] = scores.entries[j];
                    scores.entries[j] = tmp;
                }
            }
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

    // return a string[] contain the name and score of the highest score
    public string[] get_highscore()
    {
        string[] temp = new string[2];
        Scores scores;
        if (PlayerPrefs.GetString("table") == "") // if it doesnt create one
        {
            //Debug.Log("doesnt creating one");

            entryList = new List<Entry>()
            {
            new Entry{score = 0, name = "---"},
            };

            scores = new Scores { entries = entryList };
            string json = JsonUtility.ToJson(scores);
            PlayerPrefs.SetString("table", json);
            PlayerPrefs.Save();
        }
        else
        {
            string jsonString = PlayerPrefs.GetString("table");
            //Debug.Log("exist");
            scores = JsonUtility.FromJson<Scores>(jsonString);
        }


        //sort
        for (int i = 0; i < scores.entries.Count; i++)
        {
            for (int j = i + 1; j < scores.entries.Count; j++)
            {
                if (scores.entries[j].score > scores.entries[i].score)
                {
                    Entry tmp = scores.entries[i];
                    scores.entries[i] = scores.entries[j];
                    scores.entries[j] = tmp;
                }
            }
        }

        temp[0] = scores.entries[0].name;
        temp[1] = scores.entries[0].score.ToString();

        return temp;
    }

    //flushes the scores
    public void flush()
    {
        string jsonString = PlayerPrefs.GetString("table");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);
        scores.entries.Clear();
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("table", json);
        PlayerPrefs.Save();
    }


}

