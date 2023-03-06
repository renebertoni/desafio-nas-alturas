using UnityEngine;
using TMPro;
using System;

public class UI_Counter : MonoBehaviour
{
    public static Action<string> PlayAudio;

    TMP_Text _counter;
    int _points = 0;

    void Awake()
    {
        _counter = GetComponent<TMP_Text>();
        _counter.text = _points.ToString();
    }

    void OnEnable()
    {
        ObstaclePointField.AddScore += OnAddScore;
    }

    void OnDisable()
    {
        ObstaclePointField.AddScore -= OnAddScore;
    }

    private void OnAddScore()
    {
        _points++;
        _counter.text = _points.ToString();
        PlayAudio?.Invoke(Constants.SCORE);
    }
}
