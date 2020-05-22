using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI Setting")]
    public Text itemText;
    public Text gameTimerText;

    [Header("Scene Setting")]
    public int LoseSceneIndex;
    public int WinSceneIndex;

    [Header("Time Setting")]
    public float gameTimer = 60f;
    private const int timeUp = 0;

    [Header("Game Setting")]
    public bool isGameOver = false;

    private static int itemCount = 0;

    private void Start()
    {
        AudioManager.instance.Play("RainSound");
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Update UI
        gameTimerText.text = "TIME LEFT = " + timerString;
        itemText.text = "ITEM LEFT = " + itemCount.ToString();

        if (gameTimer <= timeUp)
        {
            SceneManager.LoadScene(LoseSceneIndex);
        }
        
        if (itemCount == 0 && !isGameOver)
        {
            StartCoroutine(Youwin());
            Debug.Log("play you win");
        }
    }

    public void AddItem()
    {
        itemCount++;
    }

    public void RemoveItem()
    {
        itemCount--;
    }

    public int GetItemCount()
    {
        return itemCount;
    }
    IEnumerator Youwin()
    {
        AudioManager.instance.Play("YouWinSound");
        Time.timeScale = 0;
        isGameOver = true;

        //GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
