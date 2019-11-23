using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadHighscores : MonoBehaviour
{
    string line;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Load from file
        string path = Application.dataPath + "/Resources/JSONFiles/highscores.json";
        Debug.Log(path);

        List<Highscore> leaderboard = new List<Highscore>();

        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != null)
        {
            Debug.Log(line);
            Highscore score = new Highscore();
            JsonUtility.FromJsonOverwrite(line, score);
            leaderboard.Add(score);
        }

        // Find min
        int idx = 0;
        while (leaderboard.Count != 0 && counter <= 5)
        {
            float minTime = float.MaxValue;
            for (int j = 0; j < leaderboard.Count; j++)
            {
                if (leaderboard[j].time < minTime)
                {
                    minTime = leaderboard[j].time;
                    idx = j;
                }
            }
            string minutes = Mathf.Floor((leaderboard[idx].time % 3600) / 60).ToString("00");
            string seconds = (leaderboard[idx].time % 60).ToString("00");
            transform.GetChild(counter).GetChild(1).GetComponent<Text>().text = minutes + ":" + seconds;
            transform.GetChild(counter).GetChild(2).GetComponent<Text>().text = leaderboard[idx].difficulty;

            leaderboard.RemoveAt(idx);
            counter++;
        }

        //     // Set the max to the leaderboard

        //     i++;
    }
}
