using UnityEngine;
using UnityEngine.EventSystems;

public class ActionController : MonoBehaviour
{
    private CreateNewCube _createNewCube;
    private Rigidbody _rigidbody;

    private float _startTouchX = 0;

    [SerializeField] private int _speed = 10;
    [SerializeField] private int _xForcePower = 10;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _createNewCube = GameObject.FindGameObjectWithTag("RuleController").GetComponent<CreateNewCube>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }

            DoAction();
        }
    }

    private void DoAction()
    {
        Touch _touch = Input.GetTouch(0);
        float _xDirection = 0;

        switch (_touch.phase) {
            case TouchPhase.Began:
                _startTouchX = _touch.position.x;
                break;
            case TouchPhase.Moved:
                _xDirection = _touch.position.x - _startTouchX;
                MoveCube.Move((int)_xDirection, _rigidbody, _speed);
                _startTouchX = _touch.position.x;
                break;
            case TouchPhase.Ended:
                EndFase();
                break;
        }
    }

    private void EndFase()
    {
        _rigidbody.AddForce(Vector3.forward * _xForcePower, ForceMode.VelocityChange);
        _createNewCube.CreateCube();
        Destroy(this);
    }
}
