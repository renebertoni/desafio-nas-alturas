using UnityEngine;
using TMPro;
using System;

public class UI_Counter : MonoBehaviour
{
    public static Action<string> PlayAudio;

    TMP_Text _counter;

    void Awake()
    {
        _counter = GetComponent<TMP_Text>();
        _counter.text = "0";
    }

    public void SetCounter(int value)
    {
        _counter.text = value.ToString();
        PlayAudio?.Invoke(Constants.SCORE);
    }
}
