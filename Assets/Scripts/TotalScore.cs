using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }
    void Update()
    {
        PlayerPrefs.SetInt("Score", scoreValue);
        score.text = "Total Score: " + scoreValue.ToString();
    }

    
}
