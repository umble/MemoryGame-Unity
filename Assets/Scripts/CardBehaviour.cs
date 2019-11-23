using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    private GameObject back;
    private GameObject canvas;
    private bool opened;

    // Start is called before the first frame update
    void Start()
    {
        back = transform.GetChild(2).gameObject;
        canvas = transform.parent.parent.parent.gameObject;
        opened = false;
    }

    public void ShowCard()
    {
        if (!opened)
        {
            Debug.Log("Open The Card!");
            canvas.SendMessage("OpenCard", transform, SendMessageOptions.DontRequireReceiver);
            back.GetComponent<RawImage>().color = Color.clear;
            opened = true;
        }
    }

    void DeactivateCard(bool deactive)
    {
        opened = deactive;
        if (!opened)
        {
            back.GetComponent<RawImage>().color = Color.white;
        }
    }
}
