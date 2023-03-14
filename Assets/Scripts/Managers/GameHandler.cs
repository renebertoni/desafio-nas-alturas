using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action<int, int> GameOver;

    [HideInInspector] public int Score { get; private set; }
    [HideInInspector] public int Record { get; private set; }
    private int _playersAmount;
    private string _gameMode;
    private string _sceneName;

    void Start()
    {
        Time.timeScale = 1;
        Score = 0;
        _playersAmount = GameObject.FindGameObjectsWithTag(Constants.PLAYER).Length;
        _gameMode = _playersAmount <= 1 ? Constants.SCORE : Constants.SCORE_MULTIPLAYER;
        _sceneName = SceneManager.GetActiveScene().name;
        Record = LoadScore();
    }

    void OnEnable()
    {
        ObjectCollision.Crash += OnCrash;
        PlayerInputs.RestartGame += OnRestartGame;
        PlayerHandler.Revive += OnRevive;
    }

    void OnRevive()
    {
        _playersAmount++;
    }

    void OnDisable()
    {
        ObjectCollision.Crash -= OnCrash;
        PlayerInputs.RestartGame -= OnRestartGame;
        PlayerHandler.Revive -= OnRevive;
    }

    void DoGameOver()
    {
        Time.timeScale = 0;
        SaveScore();
        GameOver?.Invoke(Score, LoadScore());
    }

    void OnCrash(GameObject player)
    {
        if(--_playersAmount <= 0)
        {
            DoGameOver();
        }
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene(_sceneName);
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
