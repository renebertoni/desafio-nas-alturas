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

    void OnGameOver(int score, int record)
    {
        _gameOver.SetActive(true);
        _uiScore.SetScore(record);
        _uiScore.SetMedal(score, record);
    }

    void OnAddScore()
    {
        _gameHandler.SetScore(1);
        _uiCounter.SetCounter(_gameHandler.Score);
    }
}
