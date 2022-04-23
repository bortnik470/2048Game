using UnityEngine;
using TMPro;

public class CubeChager : MonoBehaviour
{
    [SerializeField] private Material[] _availableMaterials;
    private ScoreChanger _scoreChanger;

    private void Start()
    {
        _scoreChanger = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreChanger>();
    }

    public void ChangeValue(ref int _valueCounter, TextMeshPro[] _textsForChange, MeshRenderer _meshRenderer, ref bool _isMaxValue)
    {
        int _nextValue = int.Parse(_textsForChange[0].text) * 2;

        foreach (TextMeshPro _textMesh in _textsForChange)
            _textMesh.text = _nextValue.ToString();

        _scoreChanger.ChangeScore(_nextValue);
        _meshRenderer.material = _availableMaterials[_valueCounter];
        _valueCounter++;

        if (_availableMaterials[_valueCounter] == null)
            _isMaxValue = true;
    }
}
