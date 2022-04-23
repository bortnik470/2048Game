using UnityEngine;
using System.IO;
using System.Collections;
using TMPro;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _StartButton;
    [SerializeField] TextMeshProUGUI _PauseButton;
    [SerializeField] ScoreChanger _scoreChanger;

    IEnumerator GetJsonData(string jsonUrl)
    {
        WWW www = new WWW(jsonUrl);

        yield return www;

        _nameValues = JsonUtility.FromJson<NameValues>(www.text);
    }

    private class NameValues
    {
        public string Start;
        public string Score;
        public string Pause;
    }

    private NameValues _nameValues;

    public void ChangeLanguage(string _langName)
    {
        string _jsonPath = Application.streamingAssetsPath + $"/{_langName}.json";

        StartCoroutine(GetJsonData(_jsonPath));

        _StartButton.text = _nameValues.Start;
        _PauseButton.text = _nameValues.Pause;
        _scoreChanger.ChangeLang(_nameValues.Score);
    }
}
