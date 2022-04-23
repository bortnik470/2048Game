using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public static void Move(int _direction, Rigidbody _rigidbody, int _speed)
    {
        Vector3 _movingCoord;
        if (_direction > 0) _direction = 1;
        else if (_direction < 0) _direction = -1;
        _movingCoord = new Vector3(_direction, 0, 0);
        _rigidbody.MovePosition(_rigidbody.position + _movingCoord * Time.deltaTime * _speed);
    }
}
