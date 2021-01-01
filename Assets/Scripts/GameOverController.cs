using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    void Start()
    {
        Text scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        Text highScoreText = GameObject.FindWithTag("HighScoreText").GetComponent<Text>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        PlayerPrefs.SetInt("Score", 0);
        TotalScore.scoreValue = 0;
    }

    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
}
