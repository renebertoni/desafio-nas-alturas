using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action<int, int> GameOver;

    [HideInInspector] public int Score { get; private set; }
    [HideInInspector] public int Record { get; private set; }

    void Start()
    {
        Time.timeScale = 1;
        Score = 0;
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
        GameOver?.Invoke(Score, LoadScore());
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
