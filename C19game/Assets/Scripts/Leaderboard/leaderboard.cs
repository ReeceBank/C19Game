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

        //AddScore(1000000, "test");


        /*
        entryList = new List<Entry>()
        {
            new Entry{score = 12345, name = "dave"},
            new Entry{score = 4132, name = "dave1"},
            new Entry{score = 1234543, name = "dave2"},
            new Entry{score = 5431, name = "dave3"},
            new Entry{score = 6543456, name = "dave4"},
            new Entry{score = 8658678, name = "dave5"},
        };*/

        
        string jsonString = PlayerPrefs.GetString("table");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);
        

        //sort
        for(int i =0; i < scores.entries.Count; i++)
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


        //entryList = scores.entries;

        transformList = new List<Transform>();
        foreach(Entry entry in scores.entries)
        {
            CreateTransform(entry, entryContainer, transformList);
        }

        /*
        Scores scores = new Scores { entries = entryList };
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("table", json);
        PlayerPrefs.Save();*/
        Debug.Log(PlayerPrefs.GetString("table"));
        

    }

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

    public void AddScore(int score, string name)
    {
        Entry entry = new Entry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("table");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);

        scores.entries.Add(entry);

        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("table", json);
        PlayerPrefs.Save();
    }


    [System.Serializable]
    public class Entry
    {
        public int score;
        public string name;

    }

    public class Scores
    {
        public List<Entry> entries;
    }

}

