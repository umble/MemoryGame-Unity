using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Stopwatch : MonoBehaviour
{
    Text text;
    float currentTime;
    [SerializeField] float speed = 1;
    bool playing;
    private string minutes;
    private string seconds;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing && currentTime < 3600)
        {
            currentTime += Time.deltaTime * speed;
            minutes = Mathf.Floor((currentTime % 3600) / 60).ToString("00");
            seconds = (currentTime % 60).ToString("00");
            text.text = minutes + ":" + seconds;
        }
        else
        {
            text.text = minutes + ":" + seconds;
            playing = false;
        }
    }

    public void PauseTime()
    {
        playing = false;
    }

    public void StartTime()
    {
        playing = true;
    }

    public float GetTime()
    {
        return currentTime;
    }
}
