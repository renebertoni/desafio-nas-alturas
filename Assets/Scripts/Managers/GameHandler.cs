using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action<int, int> GameOver;

    [HideInInspector] public int Score { get; private set; }
    [HideInInspector] public int Record { get; private set; }

    [SerializeField] bool _multiplayer;
    string _gameMode;

    void Start()
    {
        Time.timeScale = 1;
        Score = 0;
        Record = LoadScore();
        _gameMode = _multiplayer ? Constants.SCORE_MULTIPLAYER : Constants.SCORE;
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
        SceneManager.LoadScene(Constants.LEVEL_02);
    }

    void SaveScore()
    {
        if(Score > Record)
        {
            PlayerPrefs.SetInt(_gameMode, Score);
        }
    }

    int LoadScore()
    {
        return PlayerPrefs.GetInt(_gameMode);
    }

    public void SetScore(int value)
    {
        Score += value;
    }
}
