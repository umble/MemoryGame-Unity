using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCards : MonoBehaviour
{
    GameObject card;
    int difficulty;
    int rows = 3;
    int cols = 4;
    float scale = 0.2f;
    float space = 115;
    float xPos;
    float yPos;

    // Constanta
    const float xPosEz = -172.5f;
    const float yPosEz = 115f;
    const float xPosMed = -231f;
    const float yPosMed = 172.5f;
    const float xPosHard = -240f;
    const float yPosHard = 187.5f;

    void Awake()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (difficulty)
        {
            case 1:
                rows = 3;
                cols = 4;
                xPos = xPosEz;
                yPos = yPosEz;
                scale = 0f;
                space = 115;
                break;
            case 2:
                rows = 4;
                cols = 5;
                xPos = xPosMed;
                yPos = yPosMed;
                scale = 0f;
                space = 115;
                break;
            case 3:
                rows = 5;
                cols = 6;
                xPos = xPosHard;
                yPos = yPosHard;
                scale = 0.2f;
                space = 95;
                break;
            default:
                rows = 3;
                cols = 4;
                xPos = xPosEz;
                yPos = yPosEz;
                scale = 0f;
                space = 115;
                break;
        }
        int xStart = 400;
        int yStart = 250;
        card = Resources.Load<GameObject>("Prefabs/Card");
        for (var col = 0; col < cols; col++)
        {
            for (var row = 0; row < rows; row++)
            {
                GameObject newCard = Instantiate(card);
                newCard.transform.SetParent(transform, false);
                newCard.transform.localPosition = new Vector3((xStart + xPos) + (col * space), (yStart + yPos) - (row * space), 0);
                newCard.transform.localScale -= new Vector3(scale, scale, 0);
                // Instantiate(card, new Vector3(xStart, yStart, 0), Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetColumns(int col)
    {
        this.cols = col;
    }

    int GetColumns()
    {
        return this.cols;
    }


    void SetRows(int row)
    {
        this.rows = row;
    }

    int GetRows()
    {
        return this.rows;
    }

}
