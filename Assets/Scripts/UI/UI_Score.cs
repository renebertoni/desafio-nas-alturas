using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] Image _medalImage;
    [SerializeField] SpriteStorage _spriteStorage;

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void SetMedal(int score, int record)
    {
        var scoreRate = Mathf.Clamp((float) score / record, 0, 1);
        _medalImage.sprite = _spriteStorage.GetSprite( GetMedalName(scoreRate) );
    }

    string GetMedalName(float scoreRate)
    {
        if(scoreRate >= 1f)
            return Constants.MEDAL_GOLD;
        else if (scoreRate >= 0.6f)
            return Constants.MEDAL_SILVER;
        else
            return Constants.MEDAL_BRONZE;
    }
}
