using UnityEngine;

public class UI_Handler : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;

    void Start()
    {
        _gameOver.SetActive(false);
    }

    void OnEnable()
    {
        GameHandler.GameOver += OnGameOver;
    }

    void OnDisable()
    {
        GameHandler.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _gameOver.SetActive(true);
    }
}
