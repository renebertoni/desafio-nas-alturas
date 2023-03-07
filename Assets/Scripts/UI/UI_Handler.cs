using UnityEngine;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameHandler _gameHandler;
    [SerializeField] UI_Counter _uiCounter;
    [SerializeField] UI_Score _uiScore;

    void Start()
    {
        _gameOver.SetActive(false);
        _uiCounter.SetCounter(_gameHandler.Score);
    }

    void OnEnable()
    {
        GameHandler.GameOver += OnGameOver;
        ObstaclePointField.AddScore += OnAddScore;
    }

    void OnDisable()
    {
        GameHandler.GameOver -= OnGameOver;
        ObstaclePointField.AddScore -= OnAddScore;
    }

    void OnGameOver(int recordScore)
    {
        _gameOver.SetActive(true);
        _uiScore.SetScore(recordScore);
    }

    void OnAddScore()
    {
        _gameHandler.SetScore(1);
        _uiCounter.SetCounter(_gameHandler.Score);
    }
}
