using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame() {
        if (TotalScore.scoreValue >= PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", TotalScore.scoreValue);
        }
        Debug.Log("High Score : " + PlayerPrefs.GetInt("HighScore"));
        clearScores();
        SceneManager.LoadScene("GameOverScene");
    }
    void Start()
    {
    
    }

    void Update()
    {
        
    }

    private void clearScores() {
        WhiteScore.scoreValue = 0;
        RedScore.scoreValue = 0;
        BlueScore.scoreValue = 0;
        BlackScore.scoreValue = 0;
    }
}
