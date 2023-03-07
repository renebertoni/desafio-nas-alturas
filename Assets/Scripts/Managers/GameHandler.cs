using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action<int> GameOver;

    public int Score = 0;
    public int Record = 0;

    void Start()
    {
        Time.timeScale = 1;
        Record = LoadScore(); 
    }

    void OnEnable()
    {
        ObjectCollision.Crash += OnGameOver;
        PlayerInputs.RestartGame += OnRestartGame;
    }

    void OnDisable()
    {
        ObjectCollision.Crash -= OnGameOver;
        PlayerInputs.RestartGame -= OnRestartGame;
    }

    void OnGameOver()
    {
        Time.timeScale = 0;
        SaveScore();
        GameOver?.Invoke(LoadScore());
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene(Constants.LEVEL_01);
    }

    void SaveScore()
    {
        if(Score > Record)
        {
            PlayerPrefs.SetInt(Constants.SCORE, Score);
        }
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt(Constants.SCORE);
    }

    public void SetScore(int value)
    {
        Score += value;
    }
}
