using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public TMP_Text totalScoreText;
    public TMP_Text rottenEggText;
    public TMP_Text whiteEggText;
    public TMP_Text shitText;
    public TMP_Text clock;

    public int gameTime = 60;

    private int rottenEgg = 0;
    private int whiteEgg = 0;
    private int shit = 0;
    private int totalScore = 0;

    private Timer timer;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = gameTime;
        timer.Run();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }
    public void AddRottenEgg(int score)
    {
        totalScore += score;
        totalScoreText.text = "Score: " + totalScore;
        rottenEgg++;
        rottenEggText.text = "x" + rottenEgg;
    }
    public void AddWhiteEgg(int score)
    {
        totalScore += score;
        totalScoreText.text = "Score: " + totalScore;
        whiteEgg++;
        whiteEggText.text = "x" + whiteEgg;
    }
    public void AddShit(int score)
    {
        totalScore += score;
        totalScoreText.text = "Score: " + totalScore;
        shit++;
        shitText.text = "x" + shit;
    }
    private void Update()
    {
        if (timer.Finished)
        {
            SceneManager.LoadScene("Scence02");
        }
        else
        {
            int remainTime = gameTime - (int)Math.Ceiling(timer.GetElapsedTime());
            clock.text = "" + remainTime;
        }
    }
}
