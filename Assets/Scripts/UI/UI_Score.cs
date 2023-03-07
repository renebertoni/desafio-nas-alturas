using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    TMP_Text _scoreText;

    void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
