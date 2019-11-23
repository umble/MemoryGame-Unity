using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Highscore
{
    public string difficulty;
    public float time;

    public Highscore(string difficulty, float time)
    {
        this.difficulty = difficulty;
        this.time = time;
    }

    public Highscore(float time)
    {
        this.time = time;
    }

    public Highscore() { }

    public void SetDifficulty(string difficulty)
    {
        this.difficulty = difficulty;
    }

    public string GetDifficulty()
    {
        return this.difficulty;
    }

    public void SetTime(float time)
    {
        this.time = time;
    }

    public float GetTime()
    {
        return this.time;
    }

}
