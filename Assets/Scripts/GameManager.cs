using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public float timeRemaining = 60f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextFinal;
    public TextMeshProUGUI timeText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI bestScoreText;

    private int bestScore;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            GameOver();
        }

        timeText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SubtractScore(int value)
    {
        score -= value;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        scoreTextFinal.text = "Your Score: " + score.ToString();
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
