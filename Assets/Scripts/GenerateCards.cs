using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateCards : MonoBehaviour
{
    // Changable variable
    private GameObject card;
    private int difficulty;
    private int rows = 3;
    private int cols = 4;
    private float scale = 0.2f;
    private float space = 115;
    private float xPos;
    private float yPos;
    private IList<Object> prevCardList, currentCardList;
    private Object[] cardsTexture;

    // Constanta for cards position
    private const float xPosEz = -172.5f;
    private const float yPosEz = 115f;
    private const float xPosMed = -231f;
    private const float yPosMed = 172.5f;
    private const float xPosHard = -240f;
    private const float yPosHard = 187.5f;

    void Awake()
    {
        // Get diffculty 
        difficulty = PlayerPrefs.GetInt("Difficulty", 1);

        // Get object texture from resource
        cardsTexture = Resources.LoadAll("Images/Animals", typeof(Texture2D));
        prevCardList = new List<Object>();
        currentCardList = new List<Object>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Prepare gameboard current difficulty
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

        // Create list for something
        for (int i = 0; i < (rows * cols) / 2; i++)
        {
            prevCardList.Add(cardsTexture[i]);
        }

        // Generate cards, xStart and yStart for handling first position card
        int xStart = 400;
        int yStart = 250;
        card = Resources.Load<GameObject>("Prefabs/Card");
        for (var col = 0; col < cols; col++)
        {
            for (var row = 0; row < rows; row++)
            {
                // Generate card
                GameObject newCard = Instantiate(card);
                newCard.transform.SetParent(transform, false);
                newCard.transform.localPosition = new Vector3((xStart + xPos) + (col * space), (yStart + yPos) - (row * space), 0);
                newCard.transform.localScale -= new Vector3(scale, scale, 0);

                // Give card random texture with tag
                int randomIdx = new System.Random().Next(prevCardList.Count);
                newCard.transform.GetChild(1).GetComponent<RawImage>().texture = prevCardList[randomIdx] as Texture2D;
                if (!currentCardList.Contains(prevCardList[randomIdx]))
                {
                    currentCardList.Add(prevCardList[randomIdx]);
                    Object temp = prevCardList[randomIdx];
                    prevCardList.RemoveAt(randomIdx);
                    prevCardList.Add(temp);
                }
                else
                {
                    prevCardList.RemoveAt(randomIdx);
                }
            }
        }
    }

    void ShuffleList(List<Object> list)
    {
        // while(list.Count != 0)
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
