using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_controller : MonoBehaviour
{

    public leaderboard lead;
    public string name ;
    public int score;
    GameObject inputFieldGo;
    InputField inputFieldCo;

    // Start is called before the first frame update
    void Start()
    {
        inputFieldGo = GameObject.Find("Name_field");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();
        name = inputFieldCo.text.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inputFieldCo.text);
        name = inputFieldCo.text.ToString();
    }

    // add the score to the leaderboard
    // now adds 9999 temp
    public void Add()
    {
        Save(9999,name);
    }

    //method to save score
    public void Save(int score, string name)
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
