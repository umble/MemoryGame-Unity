using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public void SetDiff(int diff)
    {
        PlayerPrefs.SetInt("Difficulty", diff);
    }

}
