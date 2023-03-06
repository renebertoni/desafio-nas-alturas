using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static Action GameOver;

    void Start()
    {
        Time.timeScale = 1;    
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
        GameOver?.Invoke();
    }

    private void OnRestartGame()
    {
        SceneManager.LoadScene(Constants.LEVEL_01);
    }
}
