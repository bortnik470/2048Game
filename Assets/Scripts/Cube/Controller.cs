using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] private int _yForcePower = 5;

    private int _valueCounter = 0;

    private Rigidbody _rigidbody;
    private CubeChager _cubeChanger;
    private MeshRenderer _meshRenderer;
    private TextMeshPro[] _cubeValueText;

    void Start()
    {
        _cubeChanger = GameObject.FindGameObjectWithTag("RuleController").GetComponent<CubeChager>();
        _cubeValueText = GetComponentsInChildren<TextMeshPro>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public int GetValue() { return _valueCounter; }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.transform.gameObject.CompareTag("Cube") &&
                contact.otherCollider.transform.gameObject.GetComponent<Controller>().GetValue() == _valueCounter)
            {
                bool _isMaxValue = false;
                _cubeChanger.ChangeValue(ref _valueCounter, _cubeValueText, _meshRenderer, ref _isMaxValue);

                Destroy(contact.otherCollider.transform.gameObject);
                _rigidbody.AddForce(Vector3.up * _yForcePower, ForceMode.Impulse);

                if (_isMaxValue)
                    Destroy(this);
            }
        }
    }
}
