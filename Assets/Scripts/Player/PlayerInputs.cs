using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public static Action Fly;
    public static Action RestartGame;

    bool _gameOver;

    [SerializeField] InputActionReference FlyInput;

    void OnEnable()
    {
        FlyInput.action.performed += DoFly;
        GameHandler.GameOver += OnGameOver;
    }

    void OnDisable()
    {
        FlyInput.action.performed -= DoFly;
        GameHandler.GameOver -= OnGameOver;
    }

    void DoFly(InputAction.CallbackContext obj)
    {
        if(!_gameOver)
            Fly?.Invoke();
        else
            RestartGame?.Invoke();
    }
    void OnGameOver(int score, int record)
    {
        _gameOver = true;
    }
}
