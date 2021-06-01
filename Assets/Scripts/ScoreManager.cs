using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator highScoreAnim;
    private int currentScore;
    private int highScore;
    private bool hasTriggeredHighScore = false;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
        highScore = PlayerPrefs.GetInt("high_score", 0);
    }

    public void ClearScore()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
        highScore = PlayerPrefs.GetInt("high_score", 0);
        hasTriggeredHighScore = false;
    }

    public int GetScore()
    {
        return currentScore;
    }
    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            // high score animation
            if (!hasTriggeredHighScore)
            {
                highScoreAnim.SetTrigger("HighScore_trig");
                hasTriggeredHighScore = true;
            }
            highScore = currentScore;
            PlayerPrefs.SetInt("high_score", highScore);
        }
    }
}
