using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text gameTimerText;
    float gameTimer = 60f;
    private const int timeUp = 0;

    void Update()
    {
        gameTimer -= Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}",minutes,seconds);

        gameTimerText.text = "Time Left = " + timerString; 

        if (gameTimer <= timeUp)
        {
            SceneManager.LoadScene(0);
        }
    }
}
