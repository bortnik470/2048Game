using UnityEngine;
using TMPro;

public class ScoreChanger : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _currentScore = 0;
    private string _scoreLang = "Start";

    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        ChangeScore(0);
    }

    public void ChangeLang(string _newName)
    {
        _scoreLang = _newName;
        _scoreText.text = _scoreLang + ": " + _currentScore;
    }

    public void ChangeScore(int _valueToAdd)
    {
        _currentScore += _valueToAdd;

        _scoreText.text = _scoreLang + ": " + _currentScore;
    }
}
