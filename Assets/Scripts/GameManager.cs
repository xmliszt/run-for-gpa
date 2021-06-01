using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject result;
    public GameObject score;
    public TMP_Text menuScore;
    public TMP_Text resultText;

    private void Awake()
    {
        menu.SetActive(true);
        result.SetActive(false);
        score.SetActive(false);
        menuScore.text = "High Score: " + PlayerPrefs.GetInt("high_score", 0);
    }

    public void StartGame()
    {
        menu.SetActive(false);
        result.SetActive(false);
        score.SetActive(true);
        FindObjectOfType<SpawnManager>().StartSpawn();
        FindObjectOfType<ShakeCamera>().StartShaking();
    }

    public void GameOver()
    {
        menu.SetActive(false);
        result.SetActive(true);
        score.SetActive(false);
        int myScore = FindObjectOfType<ScoreManager>().GetScore();
        int highScore = PlayerPrefs.GetInt("high_score", 0);
        resultText.text = "Your Score: " + myScore.ToString() + " | High Score: " + highScore.ToString();
        FindObjectOfType<ShakeCamera>().StopShaking();
    }

    public void BackHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
