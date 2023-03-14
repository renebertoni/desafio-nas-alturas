using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHandler : MonoBehaviour
{
    public static Action Revive;

    [SerializeField] GameObject _player;
    [SerializeField] PlayerRevive _playerRevive;
    [SerializeField] ObstacleHandler _obstacleHandler;
    [SerializeField] GameObject _blockScreen;
    [SerializeField] TMP_Text _blockCounter;
    [SerializeField] List<GameObject> _enviroment;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _playerRigidbody;
    private int _currentRespawnScore;
    private bool _playerIsDead;


    void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerRigidbody = _player.GetComponent<Rigidbody2D>();
        _currentRespawnScore = _playerRevive.reviveScoreAmount;
    }

    void OnEnable()
    {
        ObjectCollision.Crash += OnCrash;
        ObstaclePointField.AddScore += OnScore;
    }

    void OnDisable()
    {
        ObjectCollision.Crash -= OnCrash;
        ObstaclePointField.AddScore -= OnScore;
    }

    private void OnCrash(GameObject obj)
    {
        if(obj == _player)
        {
            _currentRespawnScore = _playerRevive.reviveScoreAmount;
            _playerIsDead = TogglePlayerIsDead();
            DisablePlayer();
            BlockScreen(_playerIsDead);
        }
    }

    void DisablePlayer()
    {
        ToggleMovement(false);
        _obstacleHandler.DisableObstacles();
    }

    void EnablePlayer()
    {
        ToggleMovement(true);
        _playerMovement.RestartPosition();
        _obstacleHandler.GenerateObstacles();
    }

    void ToggleMovement(bool status)
    {
        _playerMovement.enabled = status;
        _playerRigidbody.simulated = status;
        foreach (var item in _enviroment)
        {
            item.GetComponent<Translation>().ToggleMovement(status);
        }
    }

    void OnScore()
    {
        if(_playerIsDead)
        {
            _currentRespawnScore--;
            _blockCounter.text = _currentRespawnScore.ToString();

            if(_currentRespawnScore <= 0)
            {
                _playerIsDead = TogglePlayerIsDead();
                EnablePlayer();
                BlockScreen(_playerIsDead);
                _currentRespawnScore = _playerRevive.reviveScoreAmount;
                Revive?.Invoke();
            }
        }
    }

    void BlockScreen(bool status)
    {
        _blockScreen.SetActive(status);
        _blockCounter.text = _currentRespawnScore.ToString();
    }

    bool TogglePlayerIsDead()
    {
        return !_playerIsDead;
    }
}
