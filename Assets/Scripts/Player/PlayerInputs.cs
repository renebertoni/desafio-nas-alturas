using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public static Action<GameObject> Fly;
    public static Action RestartGame;

    GameObject _player;
    bool _gameOver;

    [SerializeField] InputActionReference FlyInput;

    void OnEnable()
    {
        this._player = this.gameObject;
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
            Fly?.Invoke(this._player);
        else
            RestartGame?.Invoke();
    }
    void OnGameOver(int score, int record)
    {
        _gameOver = true;
    }
}
