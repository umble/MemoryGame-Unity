using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Gameplay : MonoBehaviour
{
    private bool playing;
    private int difficulty;
    private string stringDiff;
    private int pairLeft;
    private GameObject firstCard, secondCard;
    public GameObject time;
    public GameObject finishPanel;
    public Transform correctAns;
    public Text nameAns;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        // Initialize
        difficulty = PlayerPrefs.GetInt("Difficulty", 1);
        firstCard = null;
        secondCard = null;
        playing = true;

        switch (difficulty)
        {
            case 1:
                pairLeft = 6;
                stringDiff = "Easy";
                break;
            case 2:
                pairLeft = 10;
                stringDiff = "Medium";
                break;
            case 3:
                pairLeft = 15;
                stringDiff = "Hard";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pairLeft == 0)
        {
            playing = false;
        }

        if (playing)
        {
            if (firstCard != null && secondCard != null)
            {
                string tagFirst = firstCard.transform.GetChild(1).tag;
                string tagSecond = secondCard.transform.GetChild(1).tag;

                if (tagFirst == tagSecond)
                {
                    // Update Correct Answer
                    correctAns.GetComponent<RawImage>().texture = firstCard.transform.GetChild(1).GetComponent<RawImage>().texture;
                    nameAns.text = tagFirst;

                    // Deactivate Cards
                    firstCard.SendMessage("DeactivateCard", true);
                    secondCard.SendMessage("DeactivateCard", true);
                    pairLeft -= 1;
                    firstCard = null;
                    secondCard = null;
                }
                Debug.Log(pairLeft);
            }
        }
        else
        {
            // Stop the time and show it
            time.SendMessage("PauseTime");
            float finalTime = time.GetComponent<Stopwatch>().GetTime();
            finishPanel.SetActive(true);
            finishPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = time.GetComponent<Text>().text;

            // Save the time to leaderboard
            Highscore saveScore = new Highscore(stringDiff, finalTime);
            string path = Application.persistentDataPath;
            string json = JsonUtility.ToJson(saveScore);
            File.AppendAllText(path + "/highscores.json", json + System.Environment.NewLine);

            // So the save file only run 1 time
            playing = true;
            pairLeft += 1;
        }
    }

    public void OpenCard(Transform card)
    {
        if (firstCard == null)
        {
            firstCard = card.gameObject;
            Debug.Log("First card opened");
        }
        else if (secondCard == null)
        {
            secondCard = card.gameObject;
            Debug.Log("Second card opened");
        }
        else
        {
            firstCard.SendMessage("DeactivateCard", false);
            secondCard.SendMessage("DeactivateCard", false);
            firstCard = null;
            secondCard = null;
            OpenCard(card);
            Debug.Log("Something happened");
        }
    }

    void WaitPlease()
    {
        Debug.Log("Waiting");
    }

}
