using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 10f;
    Text countdownText;
    float playerInitialGravityScale;
    
    void Start()
    {
        currentTime = startingTime;
        countdownText = GetComponent<Text>();
        playerInitialGravityScale = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0) {
            currentTime = startingTime;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = playerInitialGravityScale;
            FindObjectOfType<GameManager>().EndGame();
        }
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().gravityScale += 0.04f * Time.deltaTime;
        countdownText.text = "Timer: " + currentTime.ToString("0");
    }
}
